using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLX.Models.Admin
{
    public class ProductSubCategoryModeljoin
    {
        public int productSubCategoryId { get; set; }
        public string productCategoryName { get; set; }

        public int productCategoryId { get; set; }
        public string productSubCategoryName { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
    }
}