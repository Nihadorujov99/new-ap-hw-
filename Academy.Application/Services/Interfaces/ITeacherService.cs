using Academy.Application.Dtos.TeacherDtos;
using Academy.Domain.Entities;

namespace Academy.Application.Services.Interfaces;

public interface ITeacherService : ICrudServiceAsync<TeacherDto, CreateTeacherDto, UpdateTeacherDto, Teacher>
{

}

