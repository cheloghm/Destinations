namespace DestinationDiscoveryService.DTOs
{
    public class DestinationDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public string PlaceId { get; set; }
        public IEnumerable<string> PhotoUrls { get; set; } // URLs of the photos

        // Additional fields as needed
    }
}
