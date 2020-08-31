using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi2.Models;

namespace webApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>()
        {
            new Product
            {
                Id=1006368,
                Name="Austin and barbeque AABQ wifi Food thermometer",
                Description="Thermometer wifi for optimal innerTemperature",
                Price=399  
            },
            new Product
            {
                Id=1009334,
                Name="Andesson electric tandare ECL 1.1",
                Description="Electric stormsaker tandare  helt utan gas and bransle",
                Price=89
            },
            new Product
            {
                Id=1002266,
                Name="Weber nostick spray",
                Description="BBQ som motverkar att ravaror fastnar pa gallret",
                Price=99
            }


        };

        [HttpGet]//Get all products
       
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)//get specific product
        {
            var product = products.Find(product => product.Id == id);
            return product;
        }


    }
}