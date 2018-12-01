using Dapper;
using MemoEngine.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace MemoEngine.Repositories
{
    public class UserRepository
    {
        /// <summary>
        /// Dapper 사용을 위한 Database 개체 생성
        /// </summary>
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        /// <summary>
        /// 회원 추가
        /// /Account/Register 페이지에서 사용
        /// /Register.aspx 페이지에서 사용
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserViewModel AddUser(UserViewModel user)
        {
            using (var txScope = new TransactionScope())
            {
                // 매개변수 준비
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DomainID", user.DomainID);
                parameters.Add("@Name", user.Name);
                parameters.Add("@Description", user.Description);

                parameters.Add("@Password", user.Password);
                parameters.Add("@Email", user.Email);
                parameters.Add("@Blocked", user.Blocked);
                parameters.Add("@GroupUID", 3); // 회원가입시 무조건 Users 권한 부여(3)

                // parameters.Add("@UID", value: user.UID, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@UID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                parameters.Add("@PhoneNumber", user.PhoneNumber);
                parameters.Add("@Address", user.Address);
                parameters.Add("@Gender", user.Gender);
                parameters.Add("@BirthDate", user.BirthDate);
                parameters.Add("@Country", user.Country);

                // 저장: 저장 프로시저 실행
                this.db.Execute("AddUser", parameters, commandType: CommandType.StoredProcedure);

                // 반환형 매개변수 값 받기
                user.UID = parameters.Get<int>("@UID"); 

                txScope.Complete();

                return user; 
            }
        }

        /// <summary>
        /// 특정 아이디(DomainID)에 해당하는 사용자의 암호 변경
        /// dbo/Stored Procedures/Membership/05_ChangePassword.sql
        /// </summary>
        /// <param name="password">기존 암호</param>
        /// <param name="passwordNew">변경할 암호</param>
        /// <param name="userId">DomainID(UserId)</param>
        /// <returns>업데이트되면 1 그렇지 않으면 0 반환</returns>
        public int ChangePasswordByDomainId(
            string password, string passwordNew, string userId)
        {
            SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("ChangePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OriginalPassword", password);
            cmd.Parameters.AddWithValue("@NewPassword", passwordNew);
            cmd.Parameters.AddWithValue("@DomainID", userId);
                        
            con.Open();
            int r = cmd.ExecuteNonQuery();// 변경 1 그렇지 않으면 0 반환
            con.Close();

            return r; 
        }


        /// <summary>
        /// 로그인 처리
        /// /Account/Login 페이지에서 사용
        /// /Login.aspx 페이지에서 사용
        /// </summary>
        /// <param name="domainId">아이디</param>
        /// <param name="password">비밀번호</param>
        /// <param name="lastLoginIp">IP주소</param>
        /// <param name="originLastLoginIp">마지막 IP주소</param>
        /// <param name="originLastLoginDate">마지막 로그인 시간</param>
        /// <returns>아이디와 암호가 맞으면 1 그렇지 않으면 0을 반환</returns>
        public int LoginUser(string domainId, string password, string lastLoginIp, out string originLastLoginIp, out DateTime originLastLoginDate)
        {
            SqlConnection objCon    = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandText = "LoginUser"; // 저장 프로시저 업데이트
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@DomainID", domainId);
            objCmd.Parameters.AddWithValue("@Password", password); // 클리어 텍스트
            objCmd.Parameters.AddWithValue("@LastLoginIP", lastLoginIp);

            // 첫번째 모양
            objCmd.Parameters.Add("@OriginLastLoginIP", SqlDbType.NVarChar, 15);
            objCmd.Parameters["@OriginLastLoginIP"].Direction = ParameterDirection.Output;

            // 두번째 모양(권장)
            SqlParameter objPrm = new SqlParameter("@OriginLastLoginDate", SqlDbType.DateTime);
            objPrm.Direction = ParameterDirection.Output;
            objCmd.Parameters.Add(objPrm);

            // 실행 후 결과 값 받기
            objCon.Open();

            // 단일 값(하나의 결과 값)을 받을 때 최적 : ExecuteScalar()
            int result = Convert.ToInt32(objCmd.ExecuteScalar());

            // 저장 프로시저에서 반환되어져 온 값을 세션에 담기
            originLastLoginIp = objCmd.Parameters["@OriginLastLoginIP"].Value.ToString();
            originLastLoginDate = (objPrm.Value == null) ? DateTime.Now : Convert.ToDateTime(objPrm.Value);

            objCon.Close();

            return result;
        }






        /// <summary>
        /// 특정 사용자의 DomainID(UserID)로 해당 사용자의 모든 정보를 반환
        /// </summary>
        public UserViewModel GetUser(string domainId)
        {
            string sql = "Select * From Users Where DomainID = @DomainID";
            return this.db.Query<UserViewModel>(
                sql, new { DomainID = domainId }).SingleOrDefault();
        }










        /// <summary>
        /// 프로필 정보 업데이트
        /// </summary>
        /// <param name="model">UserViewModel 개체</param>
        /// <returns>업데이트 되었으면 1 그렇지 않으면 0</returns>
        public int UpdateUserProcess(UserViewModel model)
        {
            SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("UpdateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Description", model.Description);
            cmd.Parameters.AddWithValue("@DomainID", model.DomainID);
            cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
            cmd.Parameters.AddWithValue("@Address", model.Address);
            cmd.Parameters.AddWithValue("@Gender", model.Gender);
            cmd.Parameters.AddWithValue("@BirthDate", model.BirthDate);
            cmd.Parameters.AddWithValue("@Country", model.Country);

            con.Open();
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return result;
        }














        /// <summary>
        /// 특정 회원의 정보 삭제(회원 탈퇴)
        /// 
        /// 저장 프로시저: /MemoEngine.Database/dbo/Stored Procedures/04_DeleteUser.sql
        /// </summary>
        /// <param name="strDomainID">Sesseion["UserID"]</param>
        public void DeleteUser(string strDomainID)
        {
            SqlConnection objCon = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString);
            objCon.Open();

            SqlCommand objCmd = new SqlCommand("DeleteUser", objCon);
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@DomainID", strDomainID);

            objCmd.ExecuteNonQuery();// 삭제

            objCon.Close();
        }





















































        #region IsCorrectPasswordByUID: 특정 사용자의 UID와 Password에 해당하는 정보가 있으면 참을 반환
        /// <summary>
        /// 특정 사용자의 UID와 Password에 해당하는 정보가 있으면 참을 반환, 즉, 특정 사용자의 암호가 맞는지 확인
        /// </summary>
        /// <param name="uid">Users.UID</param>
        /// <param name="password">Users.Password</param>
        /// <returns>참 또는 거짓</returns>
        public bool IsCorrectPasswordByUID(int uid, string password)
        {
            bool result = false;

            string sql = 
                "Select Count(*) From Users " 
                + " Where UID = @UID And Password = @Password";

            int cnt = this.db.Query<int>(
                sql, new { UID = uid, Password = password }).Single();

            if (cnt > 0)
            {
                result = true;
            }

            return result;
        } 
        #endregion

















































































































        // 출력
        public List<UserViewModel> GetUserViewModels()
        {
            string sql = "Select Id, Name, Content, CreationDate From UserViewModels Order By Id Asc";
            return this.db.Query<UserViewModel>(sql).ToList();
        }

        // 상세
        public UserViewModel GetUserViewModelById(int id)
        {
            string sql = "Select * From UserViewModels Where Id = @Id";
            return this.db.Query<UserViewModel>(sql, new { Id = id }).SingleOrDefault();
        }

        // 수정
        public UserViewModel UpdateUserViewModel(UserViewModel model)
        {
            string sql = "Update UserViewModels Set Name = @Name, Content = @Content Where Id = @Id";
            this.db.Execute(sql, model);
            return model;
        }

        // 삭제
        public void RemoveUserViewModel(int id)
        {
            string sql = "Delete UserViewModels Where Id = @Id";
            this.db.Execute(sql, new { id });
        }
    }
}