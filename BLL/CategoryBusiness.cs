using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
  public  class CategoryBusiness : ICategoryBusiness
    {
        private ICategoryRepository _res;
        public CategoryBusiness(ICategoryRepository CategoryRes)
        {
            _res = CategoryRes;
        }

        public List<CategoryModel> GetData()
        {
            var allCategory = _res.GetData();
            var lstParent = allCategory.Where(ds => ds.parent_category_id == null).OrderBy(s => s.seq_mum).ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allCategory, item);
            }
            return lstParent;
        }
        public List<CategoryModel> GetHiearchyList(List<CategoryModel> lstAll, CategoryModel node)
        {
            var lstChilds = lstAll.Where(ds => ds.parent_category_id == node.category_id).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.OrderBy(s => s.category_id).ToList();
        }
    }
}
