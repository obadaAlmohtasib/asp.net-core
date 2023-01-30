using Microsoft.AspNetCore.Mvc;
using TrackingAPI.Client.Services;

namespace TrackingAPI.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HotelsService _hotelsService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _hotelsService = new HotelsService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Content()
        {
            return View();
        }

        public async Task<Object> Search(string query)
        {
            return await _hotelsService.SearchForHotels(query);
        }

    }
}