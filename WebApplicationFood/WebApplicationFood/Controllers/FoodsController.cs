using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFood.Data;
using WebApplicationFood.Models;
using WebApplicationFood.Models.Entities;

namespace WebApplicationFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public FoodsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllFoods()
        {
            var allFoods = dbContext.Foods.ToList();

            return Ok(allFoods);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetFoodById(Guid id)
        {
            var food = dbContext.Foods.Find(id);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        [HttpPost]
        public IActionResult AddFood(AddFoodDto addFoodDto)
        {
            var foodEntity = new Food()
            {
                Name = addFoodDto.Name,
                Description = addFoodDto.Description,
                Type = addFoodDto.Type,
                Price = addFoodDto.Price
            };

            dbContext.Foods.Add(foodEntity);
            dbContext.SaveChanges();

            return Ok(foodEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateFood(Guid id, UpdateFoodDto updateFoodDto)
        {
            var food = dbContext.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            food.Name = updateFoodDto.Name;
            food.Description = updateFoodDto.Description;
            food.Type = updateFoodDto.Type;
            food.Price = updateFoodDto.Price;

            dbContext.SaveChanges();
            return Ok(food);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteFood(Guid id)
        {
            var food = dbContext.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            dbContext.Remove(food);

            try
            {
                dbContext.SaveChanges();
                return NoContent(); // Hoặc Ok() nếu bạn muốn
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi vào nhật ký (điều này cần thiết để theo dõi)
                Console.WriteLine($"Lỗi khi xóa món ăn: {ex.Message}");
                return StatusCode(500, "Có lỗi xảy ra khi xóa món ăn.");
            }
        }
    }
}
