using Academy.Application.Dtos.TeacherDtos;
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
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filter, [FromQuery] string? includes)
        {
            Expression<Func<Teacher, bool>>? predicate = null;

            if (!string.IsNullOrEmpty(filter))
            {
                predicate = DynamicExpressionParser.ParseLambda<Teacher, bool>(
                    new ParsingConfig(), false, filter);
            }

            var teachers = await _teacherService.GetAllAsync(predicate, includes!);
            
            return Ok(teachers);
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAllWithPagination([FromQuery]int page, int size)
        {
            var teachers = await _teacherService.GetAllWithPaginationAsync(page: page, size : size);

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeacherDto createTeacherDto)
        {
            var createdTeacher = await _teacherService.CreateAsync(createTeacherDto);

            if (createdTeacher == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = createdTeacher.Id }, createdTeacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTeacherDto updateTeacherDto)
        {
            var updatedTeacher = await _teacherService.UpdateAsync(id, updateTeacherDto);
            if (updatedTeacher == null)
            {
                return NotFound();
            }
            return Ok(updatedTeacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.DeleteAsync(id);
            return NoContent();
        }
    }
}

