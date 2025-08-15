using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioApi.Application.Features.Commands.SkillCommands.CreateSkill;
using MyPortfolioApi.Application.Features.Commands.SkillCommands.RemoveSkill;
using MyPortfolioApi.Application.Features.Commands.SkillCommands.UpdateSkill;
using MyPortfolioApi.Application.Features.Queries.SkillQueries.GetAllSkills;
using MyPortfolioApi.Application.Features.Queries.SkillQueries.GetSkillById;
using MyPortfolioApi.Application.RequestParameters;

namespace MyPortfolioApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-skills")]
        public async Task<IActionResult> GetAllSkills([FromQuery] PaginationParameters parameters)
        {
            var query = new GetAllSkillsQueryRequest { Parameters = parameters };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(string id)
        {
            var query = new GetSkillByIdQueryRequest { Id = id };
            var response = await _mediator.Send(query);
            return Ok(response.Skill);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSkill([FromBody] CreateSkillCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSkill([FromBody] UpdateSkillCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSkill(string id)
        {
            var query = new RemoveSkillCommandRequest(id);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
