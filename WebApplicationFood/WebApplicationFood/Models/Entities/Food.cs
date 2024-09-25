namespace WebApplicationFood.Models.Entities
{
    public class Food
    {

        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }


    }
}
