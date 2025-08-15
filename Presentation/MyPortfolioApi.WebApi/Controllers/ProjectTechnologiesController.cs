using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.CreateProjectTechnology;
using MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.RemoveProjectTechnology;
using MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.UpdateProjectTechnology;
using MyPortfolioApi.Application.Features.Queries.ProjectTechnologyQueries.GetAllProjectTechnologies;
using MyPortfolioApi.Application.Features.Queries.ProjectTechnologyQueries.GetProjectTechnologyById;
using MyPortfolioApi.Application.RequestParameters;

namespace MyPortfolioApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTechnologiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectTechnologiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var query = new GetAllProjectTechnologiesQueryRequest(parameters);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var query = new GetProjectTechnologyByIdQueryRequest(id);
            var response = await _mediator.Send(query);
            return Ok(response.ProjectTechnology);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProjectTechnologyCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProjectTechnologyCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var query = new RemoveProjectTechnologyCommandRequest(id);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
