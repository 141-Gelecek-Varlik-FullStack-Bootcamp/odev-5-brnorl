using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using odev3.API.Attribute;
using odev3.DB.Models;
using odev3.Models.Product;
using odev3.Service.Product;
using System.Linq;
using System.Collections.Generic;
using odev3.Models.Pagination;

namespace odev3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PageController : ControllerBase
    {
        private readonly IProductService productService;

        public PageController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public IActionResult GetProductPage([FromQuery] PaginationFilter filter)
        {//en başta ürün listesi alınır.


            return Ok(productService.GetPaged(filter.PageNumber, filter.PageSize));
        }

    }
}