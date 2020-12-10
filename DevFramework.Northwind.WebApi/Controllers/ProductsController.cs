using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using BasicAuthentication;

namespace DevFramework.Northwind.WebApi.Controllers
{
    //[BasicAuthentication]
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
 
        public List<Product> Get()
        {
            return _productService.GetAll();
        }
        [HttpPost]
        [Route("api/products/getbyid")]
        public Product Post([FromBody] Product product)
        {
            return _productService.GetById(Convert.ToInt32(product.ProductId));
        }
    }
}
