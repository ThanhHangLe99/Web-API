using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ICategoryRepository
    {
        List<CategoryModel> GetData();
        CategoryModel GetDatabyID(string id);
        bool Create(CategoryModel model);
        bool Update(CategoryModel model);
        bool Delete(string id);
        List<CategoryModel> Search(int pageIndex, int pageSize, out long total, string category_name);
    }
}
