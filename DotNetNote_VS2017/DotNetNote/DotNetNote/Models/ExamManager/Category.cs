using System.Collections.Generic;

namespace DotNetNote.Models
{
    public class Category
    {
        public string Name { get; set;  }

        private IList<Product> _products = new List<Product>();

        public IList<Product> Products
        {
            get { return _products;  }
            set { _products = value; }
        }
    }
}
