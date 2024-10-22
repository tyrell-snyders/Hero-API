namespace Hero_API.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
