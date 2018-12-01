using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Models
{
    public class ProductRepository
    {
        private IDbConnection db;

        public ProductRepository()
        {
            db = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }


        /// <summary>
        /// 상품 반환: ProductList.aspx 페이지에서 사용
        /// </summary>
        /// <returns>전체 상품 리스트</returns>
        public List<Product> GetAllProducts()
        {
            string sql = "Select * From Products";
            return db.Query<Product>(sql).ToList();
        }



        /// <summary>
        /// 8.28.3
        /// 상품 검색 결과 : 넘겨져 온 검색어에 따른 상품리스트
        /// SearchResults.aspx에서 사용
        /// </summary>
        /// <param name="searchString">검색할 상품명</param>
        /// <returns>상품 검색 결과 리스트</returns>
        public SqlDataReader GetProductsBySearchString(string searchString)
        {
            #region ADO.NET 클래스 사용
            // 커넥션
            SqlConnection objCon =
                new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            // 커멘드
            SqlCommand objCmd = new SqlCommand("ProductSearch", objCon);
            objCmd.CommandType = CommandType.StoredProcedure;

            // 파라미터
            SqlParameter parameterSearch = new SqlParameter("@Search", SqlDbType.NVarChar, 255);
            parameterSearch.Value = searchString;
            objCmd.Parameters.Add(parameterSearch);

            // 명령 실행
            objCon.Open();
            SqlDataReader result = objCmd.ExecuteReader(CommandBehavior.CloseConnection);

            // 데이터리더 개체 반환
            return result;
            #endregion
            //return (SqlDataReader)DatabaseFactory.CreateDatabase("ConnectionString").ExecuteReader("ProductSearch", searchString);
        }



        /// <summary>
        /// 상품 검색 결과 : 넘겨져 온 검색어에 따른 상품리스트
        /// SearchResults.aspx에서 사용
        /// </summary>
        /// <param name="searchString">검색할 상품명</param>
        /// <returns>상품 검색 결과 리스트</returns>
        public List<Product> GetProductsBySearchStringDapper(string searchString)
        {
            return db.Query<Product>("ProductSearch", new { Search = searchString }, commandType: CommandType.StoredProcedure).ToList();
        }








        /// <summary>
        /// 상품 추가: ProductAdd.aspx 페이지에서 사용
        /// </summary>
        /// <param name="ProductName">분류명</param>
        public void AddProduct(Product product)
        {
            string sql = "";
            db.Execute(sql, product);

            //// Database 클래스의 인스턴스 생성
            //Database db = DatabaseFactory.CreateDatabase("ConnectionString");
            //// DbCommand 클래스의 인스턴스 생성
            //DbCommand dbCommand = db.GetStoredProcCommand("ProductsAdd");
            //// 파라미터 추가 : Input/Output
            //db.AddInParameter(dbCommand, "CategoryId", DbType.Int32, product.CategoryId);
            //db.AddInParameter(dbCommand, "ModelNumber", DbType.String, product.ModelNumber);
            //db.AddInParameter(dbCommand, "ModelName", DbType.String, product.ModelName);
            //db.AddInParameter(dbCommand, "Company", DbType.String, product.Company);
            //db.AddInParameter(dbCommand, "OriginPrice", DbType.Int32, product.OriginPrice);
            //db.AddInParameter(dbCommand, "SellPrice", DbType.Int32, product.SellPrice);
            //db.AddInParameter(dbCommand, "EventName", DbType.String, product.EventName);
            //db.AddInParameter(dbCommand, "ProductImage", DbType.String, product.ProductImage);
            //db.AddInParameter(dbCommand, "Explain", DbType.Int32, product.Explain);
            //db.AddInParameter(dbCommand, "Description", DbType.String, product.Description);
            //db.AddInParameter(dbCommand, "Encoding", DbType.String, product.Encoding);
            //db.AddInParameter(dbCommand, "ProductCount", DbType.Int32, product.ProductCount);
            //db.AddInParameter(dbCommand, "Mileage", DbType.Int32, product.Mileage);
            //db.AddInParameter(dbCommand, "Absence", DbType.Int32, product.Absence);
            //db.AddOutParameter(dbCommand, "ProductId", DbType.Int32, 8);
            //// 실행
            //db.ExecuteNonQuery(dbCommand);
            //return Convert.ToInt32(db.GetParameterValue(dbCommand, "ProductId"));

        }








        /// <summary>
        /// 전체 카테고리 리스트
        /// CategoryList.ascx에서 사용
        /// </summary>
        /// <returns>카테고리 리스트</returns>
        public SqlDataReader GetProductCategories()
        {
            #region ADO.NET 클래스 사용
            SqlConnection objCon =
                new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objCon.Open();

            SqlCommand objCmd = new SqlCommand("ProductCategoryList", objCon);
            objCmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader result = objCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
            #endregion
            //return (SqlDataReader)DatabaseFactory.CreateDatabase("ConnectionString").ExecuteReader(CommandType.StoredProcedure, "ProductCategoryList");
        }

        /// <summary>
        /// 카테고리에 따른 상품 리스트
        /// ProductsList.aspx에서 사용
        /// </summary>
        /// <param name="intCategoryID">카테고리 번호</param>
        /// <returns>카테고리에 따른 상품 리스트(데이터리더)</returns>
        public SqlDataReader GetProducts(int intCategoryID)
        {
            #region ADO.NET 클래스 사용
            SqlConnection objCon = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objCon.Open();

            SqlCommand objCmd = new SqlCommand("ProductsByCategory", objCon);
            objCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCategoryID = new SqlParameter("@CategoryId", SqlDbType.Int, 4);
            parameterCategoryID.Value = intCategoryID;
            objCmd.Parameters.Add(parameterCategoryID);

            SqlDataReader result =
                objCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
            #endregion
            //return (SqlDataReader)DatabaseFactory.CreateDatabase("ConnectionString").ExecuteReader("ProductsByCategory", intCategoryID);
        }

        /// <summary>
        /// 상품 상세 정보 반환 
        /// Product.aspx에서 사용
        /// </summary>
        /// <param name="intProductID">상품 번호</param>
        /// <returns>Product 형식의 데이터</returns>
        public Product GetProduct(int intProductID)
        {
            #region ADO.NET 클래스 사용
            // 커넥션
            SqlConnection objCon =
                new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            // 커멘드
            SqlCommand objCmd = new SqlCommand("ProductDetail", objCon);
            objCmd.CommandType = CommandType.StoredProcedure;

            // 파라미터 추가
            SqlParameter parameterProductID =
                new SqlParameter("@ProductId", SqlDbType.Int, 4);
            parameterProductID.Value = intProductID;
            objCmd.Parameters.Add(parameterProductID);

            SqlParameter parameterOriginPrice =
                new SqlParameter("@OriginPrice", SqlDbType.Int, 8);
            parameterOriginPrice.Direction = ParameterDirection.Output;
            objCmd.Parameters.Add(parameterOriginPrice);

            SqlParameter parameterSellPrice =
                new SqlParameter("@SellPrice", SqlDbType.Int, 8);
            parameterSellPrice.Direction = ParameterDirection.Output;
            objCmd.Parameters.Add(parameterSellPrice);

            SqlParameter parameterModelNumber =
                new SqlParameter("@ModelNumber", SqlDbType.NVarChar, 50);
            parameterModelNumber.Direction = ParameterDirection.Output;
            objCmd.Parameters.Add(parameterModelNumber);

            SqlParameter parameterModelName =
                new SqlParameter("@ModelName", SqlDbType.NVarChar, 50);
            parameterModelName.Direction = ParameterDirection.Output;
            objCmd.Parameters.Add(parameterModelName);

            SqlParameter parameterCompany =
                new SqlParameter("@Company", SqlDbType.NVarChar, 50);
            parameterCompany.Direction = ParameterDirection.Output;
            objCmd.Parameters.Add(parameterCompany);

            SqlParameter parameterProductImage =
                new SqlParameter("@ProductImage", SqlDbType.NVarChar, 50);
            parameterProductImage.Direction = ParameterDirection.Output;
            objCmd.Parameters.Add(parameterProductImage);

            SqlParameter parameterDescription =
                new SqlParameter("@Description", SqlDbType.NVarChar, 4000);
            parameterDescription.Direction = ParameterDirection.Output;
            objCmd.Parameters.Add(parameterDescription);

            SqlParameter parameterProductCount =
                new SqlParameter("@ProductCount", SqlDbType.Int, 8);
            parameterProductCount.Direction = ParameterDirection.Output;
            objCmd.Parameters.Add(parameterProductCount);

            objCon.Open();
            objCmd.ExecuteNonQuery();
            objCon.Close();

            // Product 형식변수에 저장
            Product myProduct = new Product();

            myProduct.ModelNumber = (string)parameterModelNumber.Value;
            myProduct.ModelName = (string)parameterModelName.Value;
            myProduct.Company = (string)parameterCompany.Value;
            myProduct.OriginPrice = (int)parameterOriginPrice.Value;
            myProduct.SellPrice = (int)parameterSellPrice.Value;
            myProduct.ProductImage = ((string)parameterProductImage.Value).Trim();
            myProduct.Description = Convert.ToString(parameterDescription.Value);
            myProduct.ProductCount = (int)parameterProductCount.Value;

            return myProduct;
            #endregion
            //// Database 클래스의 인스턴스 생성
            //Database db = DatabaseFactory.CreateDatabase("ConnectionString");
            //// DbCommand 클래스의 인스턴스 생성
            //DbCommand dbCommand = db.GetStoredProcCommand("ProductDetail");
            //// 파라미터 추가 : Input/Output
            //db.AddInParameter(dbCommand, "ProductId", DbType.Int32, intProductID);
            //db.AddOutParameter(dbCommand, "OriginPrice", DbType.Int32, 8);
            //db.AddOutParameter(dbCommand, "SellPrice", DbType.Int32, 8);
            //db.AddOutParameter(dbCommand, "ModelNumber", DbType.String, 50);
            //db.AddOutParameter(dbCommand, "ModelName", DbType.String, 50);
            //db.AddOutParameter(dbCommand, "Company", DbType.String, 50);
            //db.AddOutParameter(dbCommand, "ProductImage", DbType.String, 50);
            //db.AddOutParameter(dbCommand, "Description", DbType.String, 4000);
            //db.AddOutParameter(dbCommand, "ProductCount", DbType.Int32, 8);
            //// 실행
            //db.ExecuteNonQuery(dbCommand);
            //// Product 형식변수에 저장
            //Product myProduct = new Product();
            //myProduct.ModelNumber = db.GetParameterValue(dbCommand, "ModelNumber").ToString();
            //myProduct.ModelName = db.GetParameterValue(dbCommand, "ModelName").ToString();
            //myProduct.Company = db.GetParameterValue(dbCommand, "Company").ToString();
            //myProduct.OriginPrice = Convert.ToInt32(db.GetParameterValue(dbCommand, "OriginPrice"));
            //myProduct.SellPrice = Convert.ToInt32(db.GetParameterValue(dbCommand, "SellPrice"));
            //myProduct.ProductImage = db.GetParameterValue(dbCommand, "ProductImage").ToString();
            //myProduct.Description = db.GetParameterValue(dbCommand, "Description").ToString();
            //myProduct.ProductCount =
            //    Convert.ToInt32(db.GetParameterValue(dbCommand, "ProductCount"));
            //return myProduct;
        }

        /// <summary>
        /// 이미 구매한 제품과 같이 구매한 상품리스트를 반환
        /// AlsoBought.ascx에서 사용
        /// </summary>
        /// <param name="intProductID">상품번호</param>
        /// <returns>연관 상품 리스트</returns>
        public SqlDataReader GetProductsAlsoPurchased(int intProductID)
        {
            #region ADO.NET 클래스 사용
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objCon.Open();

            SqlCommand objCmd = new SqlCommand("CustomerAlsoBought", objCon);
            objCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterProductID = new SqlParameter("@ProductId", SqlDbType.Int, 4);
            parameterProductID.Value = intProductID;
            objCmd.Parameters.Add(parameterProductID);

            SqlDataReader result = objCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
            #endregion
            //return (SqlDataReader)DatabaseFactory.CreateDatabase("ConnectionString").ExecuteReader("CustomerAlsoBought", intProductID);
        }

        /// <summary>
        /// 지난 일주일동안 가장 인기있었던 제품리스트
        /// PopularItems.ascx에서 사용
        /// </summary>
        /// <returns>상품 리스트</returns>
        public SqlDataReader GetMostPopularProductsOfWeek()
        {
            #region ADO.NET 클래스 사용
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand objCmd = new SqlCommand("ProductsMostPopular", objCon);

            objCmd.CommandType = CommandType.StoredProcedure;

            objCon.Open();
            SqlDataReader result = objCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
            #endregion
            //return (SqlDataReader)DatabaseFactory.CreateDatabase("ConnectionString"
            //    ).ExecuteReader(CommandType.StoredProcedure, "ProductsMostPopular");
        }

    }
}
