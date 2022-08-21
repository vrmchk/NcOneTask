using Artsofte.BLL.Exceptions.Base;

namespace Artsofte.BLL.Exceptions;

public class DepartmentDoesntExistException : BaseCustomException
{
    public DepartmentDoesntExistException(string? cause, string message, Exception? innerException = null)
        : base(cause, message, innerException) { }
}