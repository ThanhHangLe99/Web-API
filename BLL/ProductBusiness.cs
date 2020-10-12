using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
  public  class ProductBusiness : IProductBusiness
    {
        private IProductRepository _res;
        public ProductBusiness(IProductRepository CategoryRes)
        {
            _res = CategoryRes;
        }
        public bool Create(ProductModel model)
        {
            return _res.Create(model);
        }
        public ProductModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ProductModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string category_id)
        {
            return _res.Search(pageIndex, pageSize, out total, category_id);
        }
    }
}
