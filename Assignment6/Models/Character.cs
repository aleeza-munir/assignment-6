using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class Character
    {
        public int Id { get; set; }
        [MaxLength(100)] public string? FullName {get; set;}
        [MaxLength(50, ErrorMessage = "Alias is too long")] public string? Alias {get; set;}
        [MaxLength(50, ErrorMessage = "That Genre is way too long")] public string Gender { get; set;}
        public string Picture { get; set;}
        //Collection of movies the character is in
        public ICollection<Movie> Movies { get; set; } 
    }
}
