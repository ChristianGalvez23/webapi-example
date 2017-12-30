using System;

namespace EventsPlace.models {
    public class ProductResource {
        public ProductResource () {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }

    }
}