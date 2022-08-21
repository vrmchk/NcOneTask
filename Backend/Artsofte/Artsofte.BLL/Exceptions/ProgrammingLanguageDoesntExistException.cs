using Artsofte.BLL.Exceptions.Base;

namespace Artsofte.BLL.Exceptions;

public class ProgrammingLanguageDoesntExistException : BaseCustomException
{
    public ProgrammingLanguageDoesntExistException(string? cause, string message, Exception? innerException = null) 
        : base(cause, message, innerException) { }
}