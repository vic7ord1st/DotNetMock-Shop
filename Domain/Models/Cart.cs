using System.Collections.Generic;

namespace supermarket.API.Domain.Models {
    public class Cart {
        public int id {get; set;}

        public IList <Product> products {get; set;} = new List <Product>();

        public int userId {get; set;}

        public User user {get; set;}
    }
}