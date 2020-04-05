using AutoMapper;
using mockshop.API.Domain.Models;
using mockshop.API.Resources;

namespace mockshop.API.Mapping {
    public class ModelResourceProfile: Profile {
        public ModelResourceProfile(){
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>();
        }

    }
}