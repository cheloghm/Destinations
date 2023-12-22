using MongoDB.Driver;
using DestinationDiscoveryService.Models;

namespace DestinationDiscoveryService.Data
{
    // Context class for MongoDB interactions.
    public class DestinationContext
    {
        private readonly IMongoDatabase _database;

        public DestinationContext(IMongoDatabase database)
        {
            _database = database;
        }

        // Provides access to the Destinations collection in MongoDB.
        public IMongoCollection<DestinationModel> Destinations
        {
            get { return _database.GetCollection<DestinationModel>("Destinations"); }
        }
    }
}
