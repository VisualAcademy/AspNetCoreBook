using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MemoEngine.ViewModels;
using System.Transactions;

namespace MemoEngine.Repositories
{
    public class GroupRepository
    {
        /// <summary>
        /// Dapper 사용을 위한 Database 개체 생성
        /// </summary>
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);



        //Select DomainID As GroupID From Domains
        //Where Domains.UID IN (1, 3)


        //Select Membership.GroupUID From Membership Join Users 
        //    On Membership.UserUID = Users.UID 
        //Where Users.DomainID = 'Administrator'; -- Administrators(1), Users(3)


        //Select DomainID As GroupID From Domains
        //Where Domains.UID IN (
        //    Select Membership.GroupUID From Membership Join Users 
        //    On Membership.UserUID = Users.UID 
        //    Where Users.DomainID = 'Administrator'
        //)
        /// <summary>
        /// 지정된 사용자 계정이 소속되어 있는 그룹 리스트를 반환
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string[] GetGroupListsByUserId(int id)
        {
            string sql = "Select DomainID As GroupID From Domains Where Domains.UID IN (Select Membership.GroupUID From Membership Join Users On Membership.UserUID = Users.UID Where Users.UID = @UID)";
            return this.db.Query<String>(sql, new { UID = id }).ToList().ToArray();
        }



    }
}