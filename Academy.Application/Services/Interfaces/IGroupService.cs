using Academy.Application.Dtos.GroupDtos;
using Academy.Domain.Entities;

namespace Academy.Application.Services.Interfaces;

public interface IGroupService : ICrudServiceAsync<GroupDto, CreateGroupDto, UpdateGroupDto, Group>
{

}

