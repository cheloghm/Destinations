public class GooglePlacesApiResponse
{
    public IEnumerable<GooglePlace> Results { get; set; }

    public class GooglePlace
    {
        public string Name { get; set; }
        public string FormattedAddress { get; set; } // Changed from 'Address' to 'FormattedAddress'
        public double Rating { get; set; }
        public string PlaceId { get; set; }
        public IEnumerable<Photo> Photos { get; set; }

        public class Photo
        {
            public string PhotoReference { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }

            public string GetPhotoUrl(string apiKey)
            {
                return $"https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference={PhotoReference}&key={apiKey}";
            }
        }
    }
}
