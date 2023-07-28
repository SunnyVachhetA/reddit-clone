using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using Entities.DataModels;

namespace DataAccessLayer.Implementation;
public class SubRedditRepository : Repository<SubReddit>, ISubRedditRepository
{
    public SubRedditRepository(AppDbContext dbContext)
        : base(dbContext)
    { }
}
