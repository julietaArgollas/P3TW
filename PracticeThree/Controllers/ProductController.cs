using Logic.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeThree.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductManager _productManager;
        public ProductController(ProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        [Route("Getproducts")]
        public IActionResult GetProduct()
        {
            return Ok(_productManager.GetProduct());
        }
        /*
        [HttpPost]
        [Route("CreateProducts")]
        public IActionResult CreateProduct([FromBody] Logic.Models.Product product)
        {
            return Ok(_productManager.CreateProduct(product));
        }

        [HttpPut]
        [Route("UpdateProducts")]
        public IActionResult UpdateProduct([FromBody] Logic.Models.Product product)
        {
            return Ok(_productManager.UpdateProduct(product));
        }
        */
    }
}
