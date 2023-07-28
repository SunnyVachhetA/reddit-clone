using BusinessAccessLayer.Abstraction;
using DataAccessLayer.Abstraction;

namespace BusinessAccessLayer.Implementation;
public class SubRedditService : ISubRedditService
{
    #region Properties

    private readonly ISubRedditRepository _subRedditRepository;

    #endregion

    #region Constructor

    public SubRedditService(ISubRedditRepository subRedditRepository)
    {
        _subRedditRepository = subRedditRepository;
    }

    #endregion

    #region Interface Methods
    #endregion
}
