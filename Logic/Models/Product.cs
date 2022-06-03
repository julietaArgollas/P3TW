using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
    }
}
