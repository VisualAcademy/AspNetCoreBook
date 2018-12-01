using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DotNetNote.Models
{
    /// <summary>
    /// 모델 클래스
    /// </summary>
    public class Four
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Note { get; set; }
    }

    /// <summary>
    /// 인터페이스 
    /// </summary>
    public interface IFourRepository
    {
        Four Add(Four model);
        List<Four> GetAll();
        Four GetById(int id);
    }

    public class FourRepository : IFourRepository
    {
        private IConfiguration _config;
        private IDbConnection db; 

        public FourRepository(IConfiguration config)
        {
            _config = config;
            db = new SqlConnection(
                _config
                    .GetSection("ConnectionStrings")
                        .GetSection("DefaultConnection").Value);
        }

        public Four Add(Four model)
        {
            string sql = @"
                Insert Into Fours (Note) Values (@Note);
                Select Cast(SCOPE_IDENTITY() As Int);
            ";
            var id = db.Query<int>(sql, model).Single();
            model.Id = id;
            return model;
        }

        public List<Four> GetAll()
        {
            string sql = "Select * From Fours Order By Id Asc";
            return db.Query<Four>(sql).ToList();
        }

        public Four GetById(int id)
        {
            string sql = "Select * From Fours  Where Id = @Id";
            return db.Query<Four>(sql, new { Id = id }).Single();
        }
    }

    [Route("api/[controller]")]
    public class FourServiceController : Controller
    {
        private IFourRepository _repository;

        public FourServiceController(IFourRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var fours = _repository.GetAll();
                if (fours == null)
                {
                    return NotFound($"아무런 데이터가 없습니다.");
                }
                return Ok(fours);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Produces("application/json", Type = typeof(Four))]
        [Consumes("application/json")]
        public IActionResult Post([FromBody]Four model)
        {
            try
            {
                // 모델 유효성 검사
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400 에러 출력
                }
                var m = _repository.Add(model);
                return CreatedAtAction("Get", new { id = m.Id }, m); // 201
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpGet("{id:int}")]
        public Four Get(int id)
        {
            return _repository.GetAll().Where(m => m.Id == id).Single();
        }
    }
}
