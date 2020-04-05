using AutoMapper;
using supermarket.API.Domain.Models;
using supermarket.API.Resources;

namespace supermarket.API.Mapping {
    public class ResourceToModelProfile: Profile {
        public ResourceToModelProfile(){
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
        }

    }
}