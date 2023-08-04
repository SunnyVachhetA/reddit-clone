using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using Entities.DataModels;

namespace DataAccessLayer.Implementation;

public class RedditTopicRepository
    : Repository<RedditTopic>, IRedditTopicRepository

{
    #region Constructors

    public RedditTopicRepository(AppDbContext dbContext) : base(dbContext)
    { }

    #endregion Constructors
}