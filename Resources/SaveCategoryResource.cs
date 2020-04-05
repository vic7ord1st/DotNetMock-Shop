using System.ComponentModel.DataAnnotations;

namespace mockshop.API.Resources {

}public class SaveCategoryResource {
    [Required]
    [MinLength(3)]
    public string name {get; set;}
}