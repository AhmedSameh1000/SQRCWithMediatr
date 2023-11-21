using HRLeaveMangment.Application.Models;

namespace HRLeaveMangment.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}