using Academy.Application.Dtos.GroupDtos;
using Academy.Application.Services.Interfaces;
using Academy.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Academy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filter, [FromQuery] string? includes)
        {
            Expression<Func<Group, bool>>? predicate = null;

            if (!string.IsNullOrEmpty(filter))
            {
                predicate = DynamicExpressionParser.ParseLambda<Group, bool>(
                    new ParsingConfig(), false, filter);
            }

            var groups = await _groupService.GetAllAsync(predicate, includes!);
            
            return Ok(groups);
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAllWithPagination([FromQuery]int page, int size)
        {
            var groups = await _groupService.GetAllWithPaginationAsync(page: page, size : size);

            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _groupService.GetByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGroupDto createGroupDto)
        {
            var createdGroup = await _groupService.CreateAsync(createGroupDto);

            if (createdGroup == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = createdGroup.Id }, createdGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGroupDto updateGroupDto)
        {
            var updatedGroup = await _groupService.UpdateAsync(id, updateGroupDto);
            if (updatedGroup == null)
            {
                return NotFound();
            }
            return Ok(updatedGroup);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupService.DeleteAsync(id);
            return NoContent();
        }
    }
}

