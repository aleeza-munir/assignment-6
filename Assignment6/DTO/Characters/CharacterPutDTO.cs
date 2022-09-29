using System.ComponentModel.DataAnnotations;

namespace Assignment6.DTO.Characters
{
    public class CharacterPutDTO
    {
        public int Id { get; set; }
        [MaxLength(100)] public string? FullName { get; set; }
        [MaxLength(50, ErrorMessage = "Alias is too long")] public string? Alias { get; set; }
        [MaxLength(50, ErrorMessage = "That Genre is way too long")] public string Gender { get; set; }
        public string Picture { get; set; }
    }
}
