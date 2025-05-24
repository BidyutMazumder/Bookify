using Bookify.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Apartments
{
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly ISender _sender;

        public ApartmentsController(ISender sender)
        {
            this._sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> SearchAppartments
            (
            DateOnly StartDate,
            DateOnly EndDate,
            CancellationToken cancellationToken
            )
        {
            var Query = new SearchApartmentsQuery(StartDate, EndDate);

            var result = await _sender.Send(Query, cancellationToken);
          
            return Ok(result.Value);
        }
    }
}
