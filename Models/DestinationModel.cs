using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DestinationDiscoveryService.Models
{
    public class DestinationModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("DesiredLocation")]
        public string? DesiredLocation { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        // Add any additional fields that you might send to the Google Places API
        // For example, type of place, preferred amenities, etc.
    }
}
