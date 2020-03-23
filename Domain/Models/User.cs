
namespace supermarket.API.Domain.Models {

    public class User {

        public int id {get; set;}
        public string firstName {get; set;}
        public string lastName {get; set;}

        public bool isAdmin {get; set;}
        public string email {get; set;}

        public string password {get; set;}

        public Cart cart {get; set;}
    }
}