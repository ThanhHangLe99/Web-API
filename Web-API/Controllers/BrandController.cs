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
    public class BrandController : ControllerBase
    {
        private readonly IBrandBusiness _BrandBusiness;
        public BrandController(IBrandBusiness BrandBusiness)
        {
            _BrandBusiness = BrandBusiness;
        }

        [Route("get-brand")]
        [HttpGet]
        public IEnumerable<BrandModel> GetAllBrand()
        {
            return _BrandBusiness.GetData();
        }
    }
}
