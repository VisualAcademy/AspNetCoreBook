using MemoEngine.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MemoEngine.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductRepository repo;

        public ProductsController()
        {
            repo = new ProductRepository();
        }

        // GET api/products
        //[a] 기본값으로 반환
        //public IEnumerable<Product> Get()
        //{
        //    return repo.GetAllProducts();
        //}
        //[b] 액션 반환값 사용
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAllProducts());
        }

        // GET api/products?search=컴퓨터
        public IEnumerable<Product> Get(string search)
        {         
            return repo.GetProductsBySearchStringDapper(search);
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