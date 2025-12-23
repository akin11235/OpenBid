using MassTransit;
using MongoDB.Entities;
using Openbid.AuctionService.Contracts;
using OpenBid.SearchService.Api.Models;

namespace OpenBid.SearchService.Api.Consumers
{
    public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
    {
        public async Task Consume(ConsumeContext<AuctionDeleted> context)
        {
            Console.WriteLine("---> Consuming AuctionDeleted: " + context.Message.Id);

            var result = await DB.DeleteAsync<Item>(context.Message.Id);

            if(!result.IsAcknowledged)
            {
                throw new MessageException(typeof(AuctionCreated), "Problem deleting auction");
            }
        }
    }
}
