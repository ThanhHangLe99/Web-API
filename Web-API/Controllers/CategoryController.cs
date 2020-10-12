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
    }
}
