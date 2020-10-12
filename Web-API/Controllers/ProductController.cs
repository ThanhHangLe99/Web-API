using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusiness _productBusiness;
        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [Route("create-product")]
        [HttpPost]
        public ProductModel CreateProduct([FromBody] ProductModel model)
        {
            _productBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ProductModel GetDatabyID(string id)
        {
            return _productBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ProductModel> GetDatabAll()
        {
            return _productBusiness.GetDataAll();
        }

        [Route("search")]
        [HttpPost]
        public ReponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ReponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string category_id = "";
                if (formData.Keys.Contains("category_id") && !string.IsNullOrEmpty(Convert.ToString(formData["category_id"]))) { category_id = Convert.ToString(formData["category_id"]); }
                long total = 0;
                var data = _productBusiness.Search(page, pageSize, out total, category_id);
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
