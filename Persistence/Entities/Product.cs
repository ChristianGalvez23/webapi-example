using System;

namespace EventsPlace.Persistence.Entities {
    public class Product : EntityBase {
        public Product () {

        }
        public float Price { get; set; }
        public DateTime Date { get; set; }
    }
}