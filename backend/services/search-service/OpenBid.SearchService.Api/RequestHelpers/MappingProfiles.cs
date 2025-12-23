using AutoMapper;
using Openbid.AuctionService.Contracts;
using OpenBid.SearchService.Api.Models;

namespace OpenBid.SearchService.Api.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AuctionCreated, Item>();
        }
    }
}
