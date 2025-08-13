using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioApi.Application.Features.Commands.ProjectCommands.CreateProject;
using MyPortfolioApi.Application.Features.Commands.ProjectCommands.RemoveProject;
using MyPortfolioApi.Application.Features.Commands.ProjectCommands.UpdateProject;
using MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetAllProjects;
using MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetProjectById;
using MyPortfolioApi.Application.RequestParameters;

namespace MyPortfolioApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-projects")]
        public async Task<IActionResult> GetAllProjects([FromQuery] PaginationParameters parameters)
        {
            var query = new GetAllProjectsQueryRequest { Parameters = parameters };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(string id)
        {
            var query = new GetProjectByIdQueryRequest(id);
            var response = await _mediator.Send(query);
            return response.Success ? Ok(response.Project) : BadRequest(new { message = response.Message });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommandRequest request)
        {
            var response = await _mediator.Send(request);
            var message = response.Message;

            return response.Success ? Ok(new { message }) : BadRequest(new { message });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommandRequest request)
        {
            var response = await _mediator.Send(request);
            var message = response.Message;

            return response.Success ? Ok(new { message }) : BadRequest(new { message });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var query = new RemoveProjectCommandRequest(id);
            var response = await _mediator.Send(query);
            var message = response.Message;

            return response.Success ? Ok(new { message }) : BadRequest(new { message });
        }
    }
}
