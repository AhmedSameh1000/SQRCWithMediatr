namespace HRLeaveMangment.Application.Exceptions
{
    public class BadRequestExceptionException : ApplicationException
    {
        public BadRequestExceptionException(string Message) : base(Message)
        {
        }
    }
}