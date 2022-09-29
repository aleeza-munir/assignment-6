using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(250, ErrorMessage = "Too long")] public string MovieTitle { get; set; }
        [MaxLength(50, ErrorMessage = "That Genre is way too long")] public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; } 
        public string Trailer { get; set; }
        public Franchise Franchise { get; set; }
        public int FranchiseId { get; set; }
        //Collection for the characters in a specific movie 
        public ICollection<Character> Characters { get; set; }
    }
}
