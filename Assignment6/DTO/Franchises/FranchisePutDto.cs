using System.ComponentModel.DataAnnotations;

namespace Assignment6.DTO.Franchises
{
    public class FranchisePutDto
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "That Genre is way too long")] public string Name { get; set; }
        public string Description { get; set; }
    }
}
