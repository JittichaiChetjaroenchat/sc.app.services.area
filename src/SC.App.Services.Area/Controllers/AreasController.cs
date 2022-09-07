using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SC.App.Services.Area.Business.Queries.Area;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : BaseController
    {
        private readonly IMediator _mediator;

        public AreasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Response<GetAreaResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var payload = new GetAreaById(id);
            var query = new GetAreaByIdQuery(HttpContext.Request, payload);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Response<List<GetAreaResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByFilterAsync()
        {
            var payload = new GetAreaByFilter();
            var query = new GetAreaByFilterQuery(HttpContext.Request, payload);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}