using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IProductRepository
    {
        bool Create(ProductModel model);
        ProductModel GetDatabyID(string id);
        List<ProductModel> GetDataAll();
        List<ProductModel> Search(int pageIndex, int pageSize, out long total, string category_id);
    }
}
