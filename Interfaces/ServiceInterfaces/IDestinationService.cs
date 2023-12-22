using System.Collections.Generic;
using System.Threading.Tasks;
using DestinationDiscoveryService.DTOs;

namespace DestinationDiscoveryService.Interfaces
{
    // Interface for the Destination service
    public interface IDestinationService
    {
        Task<IEnumerable<DestinationDTO>> SearchDestinationsAsync(string query);
    }
}
