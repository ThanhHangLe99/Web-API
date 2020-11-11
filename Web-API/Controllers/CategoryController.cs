using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryBusiness _CategoryBusiness;
        public CategoryController(ICategoryBusiness CategoryBusiness)
        {
            _CategoryBusiness = CategoryBusiness;
        }

        [Route("get-category")]
        [HttpGet]
        public IEnumerable<CategoryModel> GetAllCategory()
        {
            return _CategoryBusiness.GetData();
        }

        [Route("delete-category")]
        [HttpPost]
        public IActionResult DeleteCategory([FromBody] Dictionary<string, object> formData)
        {
            string category_id = "";
            if (formData.Keys.Contains("category_id") && !string.IsNullOrEmpty(Convert.ToString(formData["category_id"]))) { category_id = Convert.ToString(formData["category_id"]); }
            _CategoryBusiness.Delete(category_id);
            return Ok();
        }

        [Route("create-category")]
        [HttpPost]
        public CategoryModel CreateCategory([FromBody] CategoryModel model)
        {
            model.category_id = Guid.NewGuid().ToString();
            model.parent_category_id = "1";
            _CategoryBusiness.Create(model);
            return model;
        }

        [Route("update-category")]
        [HttpPost]
        public CategoryModel UpdateCategory([FromBody] CategoryModel model)
        {

            _CategoryBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public CategoryModel GetDatabyID(string id)
        {
            return _CategoryBusiness.GetDatabyID(id);
        }

        [Route("search-category")]
        [HttpPost]
        public ReponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ReponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string category_name = "";
                if (formData.Keys.Contains("category_name") && !string.IsNullOrEmpty(Convert.ToString(formData["category_name"]))) { category_name = Convert.ToString(formData["category_name"]); }
                long total = 0;
                var data = _CategoryBusiness.Search(page, pageSize, out total, category_name);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}