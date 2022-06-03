using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class ListProduct
    {
        public Guid Id { get; set; }
        public string ListName { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public string Type { get; set; }
    }
}
