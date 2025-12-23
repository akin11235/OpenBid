using AutoMapper;
using MassTransit;
using MongoDB.Entities;
using Openbid.AuctionService.Contracts;
using OpenBid.SearchService.Api.Models;

namespace OpenBid.SearchService.Api.Consumers
{
    public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
    {
        private readonly IMapper _mapper;

        public AuctionCreatedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<AuctionCreated> context)
        {
            Console.WriteLine("--> Consuming auction created: " + context.Message.Id);

            var item = _mapper.Map<Item>(context.Message);

            if (item.Model == "Foo") throw new ArgumentException("Cannot sell cars with name of Foo");

            await item.SaveAsync();
        }
    }
}
