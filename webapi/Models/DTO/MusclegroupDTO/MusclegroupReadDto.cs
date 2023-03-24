namespace webapi.Models.DTO.MusclegroupDTO
{
    public class MusclegroupReadDto
    {
        public int Id { get; set; }

        public string Musclegroup1 { get; set; } = null!;

        public List<int> Exercises { get; set; }
    }
}
