using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using Academy.Infrastructure.DataContext;

namespace Academy.Infrastructure.Repositories;

public class GroupRepository : EfCoreRepositoryAsync<Group>, IGroupRepository
{
    public GroupRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

