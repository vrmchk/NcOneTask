namespace Artsofte.BLL.Exceptions.Base;

public abstract class BaseCustomException : ApplicationException
{
    protected BaseCustomException(string cause, string message, Exception? innerException = null)
        : base(message, innerException)
    {
        CauseOfError = cause;
    }

    public string CauseOfError { get; set; }
}