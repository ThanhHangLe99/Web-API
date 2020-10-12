//using BLL.Interfaces;
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
    public class CategoryRepository : ICategoryRepository
    {
        private IDatabaseHelper _dbHelper;
        public CategoryRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<CategoryModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_category_get_data");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CategoryModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        List<CategoryModel> ICategoryRepository.GetData()
        {
            throw new NotImplementedException();
        }
    }
}
