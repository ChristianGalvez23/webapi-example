using System;
using AutoMapper;
using EventsPlace.models;
using EventsPlace.Persistence.Entities;
using EventsPlace.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventsPlace.Controllers {
    public class AnimalsController : Controller {
        private IRepository<Animal> animals;
        private IMapper mapper;
        public AnimalsController (IRepository<Animal> animals, IMapper mapper) {
            this.animals = animals;
            this.mapper = mapper;
        }

        [HttpGet ("/animals/list")]
        public IActionResult GetList () {
            return Ok (this.animals.SelectAll ());
        }

        [HttpPost ("/animals/add")]
        public IActionResult AddNewProduct ([FromBody] AnimalResource p) {
            if (p == null) {
                return BadRequest ("Error: Bad Request -> " + p);
            }
            p.DateArrive = DateTime.Now;
            Animal animalMapped = this.mapper.Map<Animal> (p);
            this.animals.Insert (animalMapped);
            return Ok (this.animals.SelectAll ());
        }

        [HttpPost ("animals/update")]
        public IActionResult UpdateById ([FromBody] AnimalResource newProduct) {
            this.animals.Update (this.mapper.Map<Animal> (newProduct));
            return Ok (this.animals.SelectAll ());
        }

        [HttpPost ("animals/remove/{id}")]
        public IActionResult RemoveById (int id) {
            this.animals.Delete (id);
            return Ok (this.animals.SelectAll ());
        }
    }
}