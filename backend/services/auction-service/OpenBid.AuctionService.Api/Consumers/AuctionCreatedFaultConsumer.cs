using MassTransit;
using Openbid.AuctionService.Contracts;

namespace OpenBid.AuctionService.Api.Consumers
{
    public class AuctionCreatedFaultConsumer : IConsumer<Fault<AuctionCreated>>
    {
        public async Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
        {
            Console.WriteLine("---> Consuming faulty creation");

            var exception = context.Message.Exceptions.First();

            if (exception.ExceptionType == "System.ArgumentException") 
            {
                //context.Message.Message.Model == "FooBar";
                //await context.Publish(context.Message.Message);
                var original = context.Message.Message;

                var updated = new AuctionCreated
                {
                    Id = original.Id,
                    ReservePrice = original.ReservePrice,
                    Seller = original.Seller,
                    Winner = original.Winner,
                    SoldAmount = original.SoldAmount,
                    CurrentHighBid = original.CurrentHighBid,
                    CreatedAt = original.CreatedAt,
                    UpdatedAt = DateTime.UtcNow,
                    AuctionEnd = original.AuctionEnd,
                    Status = original.Status,
                    Make = original.Make,
                    Model = "FooBar", //corrected here
                    Year = original.Year,
                    Color = original.Color,
                    Mileage = original.Mileage,
                    ImageUrl = original.ImageUrl
                };

                await context.Publish(updated);

            }
            else
            {
                Console.WriteLine($"Not an argument exception - update error dashboard somewhere");
            }
        }
    }
}
