using System;
using Reply.Entity;
using Reply.Dsl;
using System.Transactions;
using System.Collections.Generic;
using System.Data; 

namespace Reply.Bsl
{
    public class ReplyBiz
    {
        #region 입력 : InsertReply()
        public int InsertReply(ReplyEntity re)
        {
            int result = -1;
            using (TransactionScope scope = 
                new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                ReplyDac rd = new ReplyDac();
                result = rd.InsertReply(re);

                scope.Complete(); 
            }
            return result; 
        }
        #endregion

        #region 출력
        public List<ReplyEntity> SelectReply()
        {
            // 반환 용도로 리스트제네릭클래스 변수 선언
            List<ReplyEntity> lst = new List<ReplyEntity>();
            // Dac단에서 DataSet 받기
            DataSet ds = (new ReplyDac()).SelectReply();
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            { // 반환된 레코드 수만큼 반복            
                ReplyEntity re = new ReplyEntity();

                re.Num = Convert.ToInt32(dt.Rows[i]["Num"]);
                re.Name = dt.Rows[i]["Name"].ToString();
                re.Email = dt.Rows[i]["Email"].ToString();
                re.Title = dt.Rows[i]["Title"].ToString();
                re.PostDate = Convert.ToDateTime(dt.Rows[i]["PostDate"]);
                re.PostIP = dt.Rows[i]["PostIP"].ToString();
                re.Content = dt.Rows[i]["Content"].ToString();
                re.Password = dt.Rows[i]["Password"].ToString();
                re.ReadCount = Convert.ToInt32(dt.Rows[i]["ReadCount"].ToString());
                re.Encoding = dt.Rows[i]["Encoding"].ToString();
                re.Homepage = dt.Rows[i]["Homepage"].ToString();
                //re.ModifyDate = Convert.ToDateTime(dt.Rows[i]["ModifyDate"]);
                //re.ModifyIP = dt.Rows[i]["ModifyIP"].ToString();
                re.Ref = Convert.ToInt32(dt.Rows[i]["Ref"]);
                re.Step = Convert.ToInt32(dt.Rows[i]["Step"]);
                re.RefOrder = Convert.ToInt32(dt.Rows[i]["RefOrder"]);

                lst.Add(re);
            }

            return lst;
        } 
        #endregion

        #region 상세
        public ReplyEntity SelectReplyByNum(int num) {
            // 1개 레코드 타입 변수 선언
            ReplyEntity re = new ReplyEntity();
            // 데이터가 있으면, 엔터티에 담기
            using (IDataReader dr = (new ReplyDac()).SelectReplyByNum(num))
            {
                if (dr.Read()) {
                    re.Num = Convert.ToInt32(dr["Num"]);
                    re.Name = dr["Name"].ToString();
                    re.Email = dr["Email"].ToString();
                    re.Title = dr["Title"].ToString();
                    re.PostDate = Convert.ToDateTime(dr["PostDate"]);
                    re.PostIP = dr["PostIP"].ToString();
                    re.Content = dr["Content"].ToString();
                    re.Password = dr["Password"].ToString();
                    re.ReadCount = Convert.ToInt32(dr["ReadCount"].ToString());
                    re.Encoding = dr["Encoding"].ToString();
                    re.Homepage = dr["Homepage"].ToString();
                    if (dr.IsDBNull(11)) {
                        re.ModifyDate = DateTime.MinValue;
                    }
                    else {
                        re.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                    }                    
                    re.ModifyIP = dr["ModifyIP"].ToString();
                    re.Ref = Convert.ToInt32(dr["Ref"]);
                    re.Step = Convert.ToInt32(dr["Step"]);
                    re.RefOrder = Convert.ToInt32(dr["RefOrder"]);
                }
                dr.Close(); // DataReader가 클로즈되는 순간에 DAC에서 Open()된 커넥션 종료
            }
            // 결과값 반환
            return re;
        } 
        #endregion

        #region 수정
        public int UpdateReply(ReplyEntity entity)
        {
            int result = -1;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                result = (new ReplyDac()).UpdateReply(entity);

                scope.Complete(); 
            }
            
            return result; 
        }
        #endregion

        #region 삭제
        public int DeleteReply(int num, string password)
        {
            ReplyDac rd = new ReplyDac();
            return rd.DeleteReply(num, password); 
        }
        #endregion

        #region 검색
        public DataTable SelectReplyByWord(string searchField, string searchQuery)
        {
            // Dac단 그대로 호출 : Dac -> Biz -> Web, DAC -> Web
            return (new ReplyDac()).SelectReplyByWord(searchField, searchQuery); 
        }
        #endregion

        #region 답변
        public int InsertReply(ReplyEntity re, int parentNum)
        {
            return (new ReplyDac()).InsertReply(re, parentNum); 
        }
        #endregion
    }
}
