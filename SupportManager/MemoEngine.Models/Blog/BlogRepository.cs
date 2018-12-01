using System.Collections.Generic;
using System.Linq;

namespace MemoEngine.Models
{
    public class BlogRepository
    {
        public List<Blog> GetAllInMemory()
        {
            List<Blog> blogList = new List<Blog>() {
                new Blog() { BlogId = 1, Name = "닷넷코리아", Url = "http://www.dotnetkorea.com" },
                new Blog() { BlogId = 2, Name = "데브렉", Url = "http://www.devlec.com" },
                new Blog() { BlogId = 3, Name = "태오닷넷", Url = "http://www.taeyo.net" }
            };
            return blogList;
        }
        
        public IEnumerable<Blog> SortByName(List<Blog> blogList)
        {
            return blogList.OrderBy(b => b.Name).ThenBy(b => b.Url);
        }

        public IEnumerable<Blog> SortByNameDescending(List<Blog> blogList)
        {
            //return blogList.OrderByDescending(b => b.Name).ThenByDescending(b => b.Url);
            return SortByName(blogList).Reverse();
        }

        public IEnumerable<string> GetNames(List<Blog> blogList)
        {
            return blogList.Select(b => b.Name);
        }

        public dynamic GetNamesAndUrl(List<Blog> blogList)
        {
            return blogList.Select(b => new { Name = b.Name, b.Url }); // 익명 타입 => dynamic에 담기
        }
    }


    public class BlogRepositoryDemo
    {
        public List<Blog> GetAllInMemory()
        {
            List<Blog> blogList = new List<Blog>() {
                new Blog() { BlogId = 1, Name = "닷넷코리아", Url = "http://www.dotnetkorea.com" },
                new Blog() { BlogId = 2, Name = "데브렉", Url = "http://www.devlec.com" },
                new Blog() { BlogId = 3, Name = "태오닷넷", Url = "http://www.taeyo.net" }
            };
            return blogList;
        }

        public IEnumerable<Blog> GetBlogByNameStart(string startName)
        {
            var blogs = from b in GetAllInMemory()
                        where b.Name.Contains("닷")
                        orderby b.Name
                        select b;
            return blogs; 
        }
    }
}

