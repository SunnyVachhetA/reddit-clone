using Common.Constants;

namespace Common.Exceptions;
public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(string message = MessageConstants.RESOURCE_NOT_FOUND) :
        base(message)
    { }
}
