using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using DestinationDiscoveryService.Models;
using DestinationDiscoveryService.Data;
using DestinationDiscoveryService.Interfaces;

namespace DestinationDiscoveryService.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DestinationContext _context;

        public DestinationRepository(DestinationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DestinationModel>> GetDestinationsAsync()
        {
            return await _context.Destinations.Find(_ => true).ToListAsync();
        }

        public async Task AddDestinationAsync(DestinationModel destination)
        {
            await _context.Destinations.InsertOneAsync(destination);
        }
    }
}
