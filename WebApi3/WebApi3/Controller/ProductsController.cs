using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi3.Models;

namespace WebApi3.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
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

        //Add new product
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            products.Add(product);
        }

        //Delete product

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            products = products.Except(product).ToList();
        }

        //Update product
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Product product)
        {
            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();

            products.Add(product);
        }
    }
}