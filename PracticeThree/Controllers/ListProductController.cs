using Logic.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeThree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListProductController : ControllerBase
    {
        private ListProductManager _listProductManager;
        public ListProductController(ListProductManager listProductManager)
        {
            _listProductManager = listProductManager;
        }
        [HttpGet]
        [Route("GetListProduct")]
        public IActionResult GetListProduct()
        {
            return Ok(_listProductManager.GetListProduct());
        }


        [HttpPost]
        [Route("CreateListProduct")]
        public IActionResult CreateListProduct([FromBody] Logic.Models.ListProduct listProduct)
        {
            return Ok(_listProductManager.CreateListProduct(listProduct));
        }

        [HttpPut]
        [Route("UpdateListProduct")]
        public IActionResult UpdateListProduct([FromBody] Logic.Models.ListProduct listProduct)
        {
            return Ok(_listProductManager.UpdateListProduct(listProduct));
        }

    }
}
