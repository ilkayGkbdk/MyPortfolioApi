using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioApi.Application.Features.Commands.TechnologyCommands.CreateTechnology;
using MyPortfolioApi.Application.Features.Commands.TechnologyCommands.RemoveTechnology;
using MyPortfolioApi.Application.Features.Commands.TechnologyCommands.UpdateTechnology;
using MyPortfolioApi.Application.Features.Queries.TechnologyQueries.GetAllTechnologies;
using MyPortfolioApi.Application.Features.Queries.TechnologyQueries.GetTechnologyById;
using MyPortfolioApi.Application.RequestParameters;

namespace MyPortfolioApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnologiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var query = new GetAllTechnologiesQueryRequest(parameters);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var query = new GetTechnologyByIdQueryRequest(id);
            var response = await _mediator.Send(query);
            return Ok(response.Technology);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTechnologyCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var query = new RemoveTechnologyCommandRequest(id);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
