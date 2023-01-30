using Microsoft.AspNetCore.Mvc;
using TrackingApi.Data;
using TrackingApi.Model;

namespace TrackingApi.Controllers
{    
    [Route("api/[controller]")] // Token Replacement === [Route("api/HotelsService")]
    [ApiController]
    public class HotelsServiceController : ControllerBase
    {
        private readonly DataLoader _dataLoader;

        public HotelsServiceController() {
            _dataLoader = DataLoader.getInstance();
        }

        [HttpGet]
        public Object Get() => throw new NotImplementedException();

        [HttpGet("query")]
        // public IList<Object> Search<Custom>(string query)
        public Object Search(string query)
        {
            List<ResponseHotel> response = _dataLoader.SearchForHotels(query.Trim().ToLower());
            if (response.Count == 0) {
                return ResponseObject.Create(response, "No match, Please try another search");
            }
            return ResponseObject.Create(response);
        }

    }
}
