using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class Franchise
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "That Genre is way too long")] public string Name { get; set; }    
        public string Description { get; set; }
        //Collection containing movies in the franchise 
        public ICollection<Movie> Movies { get; set; }
    }
}
