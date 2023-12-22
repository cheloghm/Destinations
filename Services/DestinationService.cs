using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DestinationDiscoveryService.DTOs;
using DestinationDiscoveryService.Interfaces;

namespace DestinationDiscoveryService.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey = "YOUR_GOOGLE_PLACES_API_KEY"; // Store this securely

        public DestinationService(IDestinationRepository repository, IHttpClientFactory httpClientFactory)
        {
            _repository = repository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<DestinationDTO>> SearchDestinationsAsync(string query)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input={query}&inputtype=textquery&fields=photos,formatted_address,name,rating,opening_hours,geometry&key={_apiKey}";

            var response = await client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<GooglePlacesApiResponse>(content);

                var destinationDTOs = new List<DestinationDTO>();
                foreach (var place in results.Results)
                {
                    // Implement additional logic here to filter or prioritize destinations
                    // based on the budget, travelDistance, and other user preferences

                    var destinationDTO = new DestinationDTO
                    {
                        Name = place.Name,
                        Address = place.FormattedAddress,
                        Rating = place.Rating,
                        PhotoUrls = place.Photos?.Select(p => p.GetPhotoUrl(_apiKey)).ToList()
                    };

                    destinationDTOs.Add(destinationDTO);
                }

                return destinationDTOs;
            }

            return new List<DestinationDTO>();
        }
    }
}
