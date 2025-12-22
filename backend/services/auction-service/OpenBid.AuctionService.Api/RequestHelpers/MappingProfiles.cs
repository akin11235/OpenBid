using AuctionService.Api.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Entities;

namespace AuctionService.Api.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
            CreateMap<Item, AuctionDto>();
            CreateMap<CreateAuctionDto, Auction>().
                ForMember(d => d.Item, o => o.MapFrom(s => s));

            CreateMap<CreateAuctionDto, Item>();
        }
    }
}
