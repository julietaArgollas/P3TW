using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class ListProduct:Entity
    {
        public string ListName { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public string Type { get; set; }
    }
}
