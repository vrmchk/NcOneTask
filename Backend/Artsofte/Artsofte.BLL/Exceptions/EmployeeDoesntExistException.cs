using Artsofte.BLL.Exceptions.Base;

namespace Artsofte.BLL.Exceptions;

public class EmployeeDoesntExistException : BaseCustomException
{
    public EmployeeDoesntExistException(string cause, string message, Exception? innerException = null) 
        : base(cause, message, innerException) { }
}