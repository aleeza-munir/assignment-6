using Assignment6.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.DTO.Movies
{
    public class MovieCreateDTO
    {
        public string MovieTitle { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
        public int FranchiseId { get; set; }
    }
}
