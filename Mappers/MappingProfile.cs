using AutoMapper;
using DestinationDiscoveryService.Models;
using DestinationDiscoveryService.DTOs;

namespace DestinationDiscoveryService.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add mappings here
            CreateMap<DestinationModel, DestinationDTO>();
            CreateMap<DestinationDTO, DestinationModel>();
        }
    }
}
