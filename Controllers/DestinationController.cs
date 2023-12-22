using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DestinationDiscoveryService.DTOs;
using DestinationDiscoveryService.Interfaces;

namespace DestinationDiscoveryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        // GET: /Destination?query=Paris&budget=1000&travelDistance=500&userId=12345
        [HttpGet]
        public async Task<IActionResult> GetDestinations(string query)
        {
            var destinations = await _destinationService.SearchDestinationsAsync(query);
            return Ok(destinations);
        }
    }
}
