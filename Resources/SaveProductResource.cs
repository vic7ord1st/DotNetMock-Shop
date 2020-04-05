using System.ComponentModel.DataAnnotations;

namespace supermarket.API.Resources {

}public class SaveProductResource {
    [Required]
    [MinLength(3)]
    public string name {get; set;}
    public string descriptionn {get; set;}
    public int price {get; set;}
    public bool inStock{get; set;}
}