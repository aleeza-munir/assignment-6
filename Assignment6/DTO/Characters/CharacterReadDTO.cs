namespace Assignment6.DTO.Characters
{
    public class CharacterReadDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Picture { get; set; }
        public List<int> Movies { get; set; }

    }
}
