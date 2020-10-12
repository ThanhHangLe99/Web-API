using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
     public class CategoryModel
    {
        public string parent_category_id { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public string seq_mum{ get;set;}

        public short? url { get; set; }
        public List<CategoryModel> children { get; set; }
        public string type { get; set; }

    }
}
