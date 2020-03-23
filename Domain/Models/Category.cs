using System.Collections.Generic;

namespace supermarket.API.Domain.Models {

    public class Category {

        public int id {get; set;}

        public string name {get; set;}

        public IList <Product> products {get; set;} = new List <Product> ();

    }
}