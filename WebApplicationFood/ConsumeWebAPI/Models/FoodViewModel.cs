using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumeWebAPI.Models
{
    public class FoodViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Food Name")]
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
    }
}
