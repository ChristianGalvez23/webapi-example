using AutoMapper;
using EventsPlace.models;
using EventsPlace.Persistence.Entities;

namespace EventsPlace.Mapper {
    public class ConfigurationProfile : Profile {
        public ConfigurationProfile () {
            CreateMap<Product, ProductResource> ();
            CreateMap<ProductResource, Product> ();
        }
    }
}