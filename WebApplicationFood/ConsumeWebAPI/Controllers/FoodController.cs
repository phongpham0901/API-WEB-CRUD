using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebAPI.Controllers
{
    public class FoodController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:44326");
        private readonly HttpClient _client;

        public FoodController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<FoodViewModel> foodList = new List<FoodViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + ).Result;
            return View();
        }
    }
}
