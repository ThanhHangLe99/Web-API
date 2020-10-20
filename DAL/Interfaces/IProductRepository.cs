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
        List<ProductModel> GetDataAll(int page_index, int page_size, out long total);
        List<ProductModel> GetDataNew();
        List<ProductModel> GetTuongTu(int id);
        List<ProductModel> Search(int pageIndex, int pageSize, out long total, string category_id);
    }
}
