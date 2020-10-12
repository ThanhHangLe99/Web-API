//using BLL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ICategoryRepository
    {
        List<CategoryModel> GetData();
    }
}
