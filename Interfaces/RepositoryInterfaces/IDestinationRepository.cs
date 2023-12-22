using System.Collections.Generic;
using System.Threading.Tasks;
using DestinationDiscoveryService.Models;

namespace DestinationDiscoveryService.Interfaces
{
    public interface IDestinationRepository
    {
        Task<IEnumerable<DestinationModel>> GetDestinationsAsync();
        Task AddDestinationAsync(DestinationModel destination);
    }
}
