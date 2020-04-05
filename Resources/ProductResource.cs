
namespace supermarket.API.Resources{

    public class ProductResource {
        public string name {get; set;}
        public string description {get; set;}
        public int price {get; set;}
        public bool inStock {get; set;}
        public CategoryResource category {get; set;}
    }
}