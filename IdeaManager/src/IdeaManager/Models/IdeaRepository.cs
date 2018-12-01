using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace IdeaManager.Models
{
    public class IdeaRepository : IIdeaRepository
    {
        private SqlConnection db;
        private IConfiguration _config;

        public IdeaRepository(IConfiguration config)
        {
            _config = config;

            db = new SqlConnection(
                _config.GetSection("ConnectionStrings")
                    .GetSection("DefaultConnection").Value);
        }

        public List<Idea> GetAll()
        {
            string sql = "Select * From Ideas";
            return db.Query<Idea>(sql).ToList(); 
        }

        public Idea Add(Idea model)
        {
            var sql = @"
                Insert Into Ideas (Note) Values(@Note);
                Select Cast(SCOPE_IDENTITY() As Int);
            ";

            var id = db.Query<int>(sql, model).Single();

            model.Id = id;

            return model; 
        }
    }
}
