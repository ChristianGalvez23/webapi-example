using System;

namespace EventsPlace.models {
    public class AnimalResource {
        public AnimalResource () {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime DateArrive { get; set; }
    }
}