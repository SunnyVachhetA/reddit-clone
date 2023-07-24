using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using Entities.DataModels;

namespace DataAccessLayer.Implementation;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext)
        : base(dbContext)
    { }
}
