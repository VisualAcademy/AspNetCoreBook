using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Models
{
    public class CategoryRepository
    {
        private IDbConnection db = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        /// <summary>
        /// 카테고리 추가: CategoryAdd.aspx 페이지에서 사용
        /// </summary>
        /// <param name="categoryName">분류명</param>
        public void AddCategory(string categoryName)
        {
            string sql = "Insert Into Categories (CategoryName) Values (@CategoryName);";
            db.Execute(sql, new { CategoryName = categoryName });
        }

        /// <summary>
        /// 카테고리 반환: CategoryList.aspx 페이지에서 사용
        /// </summary>
        /// <returns>전체 카테고리 리스트(내림차순)</returns>
        public List<Category> GetCategories()
        {
            string sql = "Select CategoryId, CategoryName From Categories Order By CategoryId Desc";
            return db.Query<Category>(sql).ToList();
        }
    }
}
