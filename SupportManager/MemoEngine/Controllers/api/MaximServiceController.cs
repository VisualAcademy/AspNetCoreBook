using MemoEngine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemoEngine.Controllers
{
    /// <summary>
    /// 명언(Maxim) 제공 서비스: /api/maximservice/
    /// 기본 뼈대 만드는 것은 Web API 스캐폴딩으로 구현 후 각각의 코드를 구현
    /// </summary>
    public class MaximServiceController : ApiController
    {
        MaximServiceRepository repo = new MaximServiceRepository();

        // GET: api/MaximService
        public IEnumerable<Maxim> Get()
        {
            return repo.GetMaxims().AsEnumerable();
        }

        // GET: api/MaximService/5
        public Maxim Get(int id)
        {
            // 데이터 조회
            Maxim maxim = repo.GetMaximById(id);
            if (maxim == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));

                // 또 다른 표현 방법
                //return Request.CreateErrorResponse(
                //    HttpStatusCode.NotFound, "항목이 없습니다.");
            }
            //else
            //{
            //    // 반환값을 HttpResponseMessage로 설정했을 때에는 아래 방법도 가능
            //    Request.CreateResponse<Maxim>(HttpStatusCode.OK, maxim);
            //}
            return maxim;
        }

        ///// <summary>
        ///// 상세 보기 전용 Web API 코드 샘플 
        ///// </summary>
        //public HttpResponseMessage Get(string boardName, int boardNum)
        //{
        //    var model = _repository.GetById(boardName, boardNum);

        //    if (model == null)
        //    {
        //        return Request.CreateErrorResponse(
        //            HttpStatusCode.NotFound, "항목이 없습니다.");
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, model);
        //}

        // POST: api/MaximService
        public HttpResponseMessage Post([FromBody]Maxim maxim)
        {
            if (ModelState.IsValid)
            {
                // 데이터 입력
                repo.AddMaxim(maxim);

                HttpResponseMessage response = 
                    Request.CreateResponse(HttpStatusCode.Created, maxim);
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { id = maxim.Id }));
                    //new Uri(Request.RequestUri + maxim.Id.ToString());
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT: api/MaximService/5
        public HttpResponseMessage Put(int id, [FromBody]Maxim maxim)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, ModelState);
            }
            if (id != maxim.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
            try
            {
                // 데이터 수정
                repo.UpdateMaxim(maxim); 
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        // DELETE: api/MaximService/5
        public HttpResponseMessage Delete(int id)
        {
            Maxim maxim = repo.GetMaximById(id); 
            if (maxim == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }                        
                        
            try
            {
                // 데이터 삭제
                repo.RemoveMaxim(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, maxim);
        }
    }
}
