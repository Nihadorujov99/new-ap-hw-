using Academy.Application.Dtos.GroupDtos;
using Academy.Application.Services.Interfaces;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using AutoMapper;

namespace Academy.Application.Services.Managers;

public class GroupManager : CrudManager<GroupDto, CreateGroupDto, UpdateGroupDto, Group>, IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupManager(IRepositoryAsync<Group> repositoryAsync, IMapper mapper, IGroupRepository groupRepository) : base(repositoryAsync, mapper)
    {
        _groupRepository = groupRepository;
    }
}

