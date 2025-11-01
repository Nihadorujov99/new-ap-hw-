using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using Academy.Infrastructure.DataContext;

namespace Academy.Infrastructure.Repositories;

public class TeacherRepository : EfCoreRepositoryAsync<Teacher>, ITeacherRepository
{
    public TeacherRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

