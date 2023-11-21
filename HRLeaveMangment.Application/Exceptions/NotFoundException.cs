namespace HRLeaveMangment.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object Key) : base($"{name} {Key} Was Not Found")
        {
        }
    }
}