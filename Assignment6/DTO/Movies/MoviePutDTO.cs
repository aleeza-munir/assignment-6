using Assignment6.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.DTO.Movies
{
    public class MoviePutDTO
    {
        public int Id { get; set; }
        [MaxLength(250, ErrorMessage = "Too long")] public string MovieTitle { get; set; }
        [MaxLength(50, ErrorMessage = "That Genre is way too long")] public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
        public int FranchiseId { get; set; }
    }
}
