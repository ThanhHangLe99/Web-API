using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IBrandRepository
    {
        List<BrandModel> GetData();
    }
}
