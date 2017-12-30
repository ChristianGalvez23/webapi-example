using System;

namespace EventsPlace.Persistence.Entities {
    public class Animal : EntityBase {
        public Animal () {

        }
        public string Breed { get; set; }
        public DateTime DateArrive { get; set; }

    }
}