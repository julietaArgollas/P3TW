using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Product:Entity
    {
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
    }
}
