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
        [Route("get-all/{page_index}/{page_size}")]
        [HttpGet]
        public IEnumerable<ProductModel> GetDatabAll(int page_index, int page_size)
        {
            long total = 0;
            var kq = _productBusiness.GetDataAll(page_index, page_size, out total);
            foreach (var item in kq)
            {
                item.total = total;
            }
            return kq;
        }

        [Route("get-new")]
        [HttpGet]
        public IEnumerable<ProductModel> GetDatabNew()
        {
            return _productBusiness.GetDataNew();
        }

        [Route("get-tuongtu/{id}")]
        [HttpGet]
        public IEnumerable<ProductModel> GetTuongTu(int id)
        {
            return _productBusiness.GetTuongTu(id);
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

        [Route("search1")]
        [HttpPost]
        public ReponseModel Search1([FromBody] Dictionary<string, object> formData)
        {
            var response = new ReponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string brand_id = "";
                if (formData.Keys.Contains("brand_id") && !string.IsNullOrEmpty(Convert.ToString(formData["brand_id"]))) { brand_id = Convert.ToString(formData["brand_id"]); }
                long total = 0;
                var data = _productBusiness.Search1(page, pageSize, out total, brand_id);
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
