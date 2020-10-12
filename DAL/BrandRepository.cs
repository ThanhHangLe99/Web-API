using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class BrandRepository : IBrandRepository
    {
        private IDatabaseHelper _dbHelper;
        public BrandRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<BrandModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_brand_get_data");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BrandModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
