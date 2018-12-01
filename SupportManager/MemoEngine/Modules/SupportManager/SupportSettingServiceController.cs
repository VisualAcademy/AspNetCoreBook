using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemoEngine
{
    public class SupportSettingServiceController : ApiController
    {
        private SupportSettingRepository _repository;

        public SupportSettingServiceController()
        {
            _repository = new SupportSettingRepository();
        }

        /// <summary>
        /// 출력 전용 Web API
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SupportSetting> Get()
        {
            return _repository.GetAll().AsEnumerable(); 
        }

        /// <summary>
        /// 상세 보기 전용 Web API
        /// </summary>
        public HttpResponseMessage Get(string boardName, int boardNum)
        {
            var model = _repository.GetById(boardName, boardNum);

            if (model == null)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "항목이 없습니다.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}