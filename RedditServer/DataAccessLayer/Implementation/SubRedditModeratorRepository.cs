using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using Entities.DataModels;

namespace DataAccessLayer.Implementation;

public class SubRedditModeratorRepository :
    Repository<SubRedditModerator>,
    ISubRedditModeratorRepository
{
    #region Constructors

    public SubRedditModeratorRepository(AppDbContext dbContext) : base(dbContext)
    { }

    #endregion Constructors
}