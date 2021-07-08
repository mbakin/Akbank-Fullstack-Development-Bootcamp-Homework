﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperPOC_DBDesign.Models;

namespace DapperPOC_DBDesign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;


        public ProductController()
        {
            productRepository = new ProductRepository();

        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.GetById(id);
        }
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(product);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            product.ProductId = id;
            if (ModelState.IsValid)
            {
                productRepository.Update(product);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}
