using System;
using MemoEngine.Models;

namespace MemoEngine.Market
{
    public partial class CategoryAdd : System.Web.UI.Page
    {
        private CategoryRepository _repository;

        public CategoryAdd()
        {
            _repository = new CategoryRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            // 카테고리 리스트를 GridView 컨트롤에 출력(바인딩)
            ctlCategoryList.DataSource = _repository.GetCategories();
            ctlCategoryList.DataBind();
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {            
            _repository.AddCategory(txtCategoryName.Text.Replace("--", ""));
            DisplayData();
        }
    }
}