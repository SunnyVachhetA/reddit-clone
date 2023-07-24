using Common.Constants;

namespace Common.Exceptions;
public class ModelValidationException : Exception
{
    public object? Errors { get; set; }

    public ModelValidationException() : base(MessageConstants.VALIDATION_ERROR)
    { }

    public ModelValidationException(object errors) : this()
    {
        Errors = errors;
    }
}
