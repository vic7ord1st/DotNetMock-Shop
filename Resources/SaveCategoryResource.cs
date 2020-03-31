using System.ComponentModel.DataAnnotations;

namespace supermarket.API.Resources {

}public class SaveCategoryResource {
    [Required]
    [MinLength(3)]
    public string name {get; set;}
}