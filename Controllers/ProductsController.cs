using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventsPlace.models;
using EventsPlace.Persistence.Entities;
using EventsPlace.Persistence.Implementation;
using EventsPlace.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventsPlace.Controllers {
    public class ProductsController : Controller {
        private IRepository<Product> products;
        private IMapper mapper;

        public ProductsController (IRepository<Product> repository, IMapper mapper) {
            this.products = repository;
            this.mapper = mapper;
        }

        [HttpGet ("/products/list")]
        public IActionResult GetList () {
            return Ok (this.products.SelectAll ());
        }

        [HttpPost ("/products/add")]
        public IActionResult AddNewProduct ([FromBody] ProductResource p) {
            if (p == null) {
                return BadRequest ("Error: Bad Request -> " + p);
            }
            p.Date = DateTime.Now;
            Product productMapped = this.mapper.Map<Product> (p);
            this.products.Insert (productMapped);
            return Ok (this.products.SelectAll ());
        }

        [HttpPost ("products/update")]
        public IActionResult UpdateById ([FromBody] ProductResource newProduct) {
            this.products.Update (this.mapper.Map<Product> (newProduct));
            return Ok (this.products.SelectAll ());
        }

        [HttpPost ("products/remove/{id}")]
        public IActionResult RemoveById (int id) {
            this.products.Delete (id);
            return Ok (this.products.SelectAll ());
        }
    }
}