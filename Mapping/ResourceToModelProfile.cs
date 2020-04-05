using AutoMapper;
using mockshop.API.Domain.Models;
using mockshop.API.Resources;

namespace mockshop.API.Mapping {
    public class ResourceToModelProfile: Profile {
        public ResourceToModelProfile(){
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
        }

    }
}