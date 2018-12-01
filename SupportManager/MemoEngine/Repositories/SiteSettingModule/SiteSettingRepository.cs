using SiteSetting.Models.SiteSettingModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

namespace SiteSetting.Repositories.SiteSettingModule
{
    public class SiteSettingRepository
    {
        // DB 접근 개체 생성
        private IDbConnection context = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        
        public SiteSettingModel AddSiteSettting(SiteSettingModel setting)
        {
            string sql = 
                @"
                    Insert Into SiteSettings (ShowMenu1) Values (@ShowMenu1);
                    Select Cast(SCOPE_IDENTITY() As Int);
                ";
            int id = this.context.Query<int>(sql, setting).Single(); 
            
            setting.Id = id;

            return setting;
        }

        public bool IsShowMenu1()
        {
            string sql = "Select Top 1 ShowMenu1 From SiteSettings Order By Id Desc";
            return  this.context.Query<bool>(sql).SingleOrDefault(); 
        }
    }
}