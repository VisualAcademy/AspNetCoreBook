using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DotNetNote.Models
{
    public interface IIdeaRepository
    {
        List<Idea> GetAll();
        Idea Add(Idea model);
    }

    public class IdeaRepository : IIdeaRepository
    {
        private IConfiguration _config;
        private SqlConnection db;

        public IdeaRepository(IConfiguration config)
        {
            _config = config;

            db = new SqlConnection(
                _config.GetSection("ConnectionStrings").GetSection(
                    "DefaultConnection").Value);
        }

        public List<Idea> GetAll()
        {
            string sql = "Select * From Ideas";
            return db.Query<Idea>(sql).ToList();
        }

        public Idea Add(Idea model)
        {
            var sql =
                "Insert Into Ideas (Note) Values (@Note); " +
                "Select Cast(SCOPE_IDENTITY() As Int);";

            var id = db.Query<int>(sql, model).Single();

            model.Id = id;
            return model;
        }
    }
}
