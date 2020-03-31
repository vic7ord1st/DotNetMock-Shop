using AutoMapper;
using supermarket.API.Domain.Models;
using supermarket.API.Resources;

namespace supermarket.API.Mapping {
    public class ModelResourceProfile: Profile {
        public ModelResourceProfile(){
            CreateMap<Category, CategoryResource>();
        }

    }
}