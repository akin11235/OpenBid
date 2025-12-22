using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using OpenBid.SearchService.Api.Models;
using OpenBid.SearchService.Api.RequestHelpers;

namespace OpenBid.SearchService.Api.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Item>>> SearchItems([FromQuery]SearchParams searchParams)
        {
            //var pageNumber = searchParams.PageNumber <= 0 ? 1 : searchParams.PageNumber;
            //var pageSize = searchParams.PageSize <= 0 ? 5 : searchParams.PageSize;

            // Placeholder logic for searching items
            var query = DB.PagedSearch<Item, Item>();

            // Full-text search
            if (!string.IsNullOrEmpty(searchParams.SearchTerm))
            {
                query.Match(Search.Full, searchParams.SearchTerm)
                    .SortByTextScore();
            }

            // Sorting
            query = searchParams.OrderBy switch
            {
                "make" => query.Sort(x => x.Ascending(a => a.Make)),
                "new" => query.Sort(x => x.Descending(a => a.CreatedAt)),
                _ => query.Sort(x => x.Ascending(a => a.AuctionEnd)),
            };

            //Status filtering
            query = searchParams.FilterBy switch
            {
                "finished" => 
                query.Match(x => x.AuctionEnd < DateTime.UtcNow),

                "endingSoon" =>
                    query.Match(x =>
                        x.AuctionEnd > DateTime.UtcNow &&
                        x.AuctionEnd < DateTime.UtcNow.AddHours(6)),

                _ => 
                    query.Match(x => x.AuctionEnd > DateTime.UtcNow)
            };

            // Seller filter
            if (!string.IsNullOrWhiteSpace(searchParams.Seller))
            {
                query.Match(x => x.Seller == searchParams.Seller);
            }

            // Winner filter
            if (!string.IsNullOrWhiteSpace(searchParams.Winner))
            {
                query.Match(x => x.Winner == searchParams.Winner);
            }

            // Paging
            query.PageNumber(searchParams.PageNumber);
            query.PageSize(searchParams.PageSize);

            var result = await query.ExecuteAsync();

            return Ok(new
            {
                results = result.Results,
                pageCount = result.PageCount,
                totalCount = result.TotalCount
            });
        }
    }
}
