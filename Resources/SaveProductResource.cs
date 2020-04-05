using System.ComponentModel.DataAnnotations;

namespace mockshop.API.Resources {

}public class SaveProductResource {
    [Required]
    [MinLength(3)]
    public string name {get; set;}
    [Required]
    [MinLength(5)]
    public string description {get; set;}
    [Required]
    public int price {get; set;}
    [Required]
    public bool inStock {get; set;}
    [Required]
    public int categoryId {get; set;}
}