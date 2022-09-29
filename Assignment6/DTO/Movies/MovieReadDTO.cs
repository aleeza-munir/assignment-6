using Assignment6.Models;

namespace Assignment6.DTO.Movies
{
    public class MovieReadDTO
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public int FranchiseId { get; set; }
        public List<int> Characters { get; set; }   
    }
}
