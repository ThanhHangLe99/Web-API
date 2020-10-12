using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IBrandBusiness
    {
        List<BrandModel> GetData();
    }
}
