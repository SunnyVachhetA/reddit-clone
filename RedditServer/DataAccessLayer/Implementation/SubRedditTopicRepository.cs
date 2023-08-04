using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using Entities.DataModels;

namespace DataAccessLayer.Implementation;

public class SubRedditTopicRepository : Repository<SubRedditTopic>, ISubRedditTopicRepository
{
    #region Constructors

    public SubRedditTopicRepository(AppDbContext dbContext) :
        base(dbContext)
    { }

    #endregion Constructors
}