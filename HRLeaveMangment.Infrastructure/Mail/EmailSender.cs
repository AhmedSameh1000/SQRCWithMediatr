using HRLeaveMangment.Application.Contracts.Infrastructure;
using HRLeaveMangment.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HRLeaveMangment.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _settings { get; }

        public EmailSender(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var Client = new SendGridClient(_settings.ApiKey);

            var To = new EmailAddress(email.To);
            var From = new EmailAddress
            {
                Email = _settings.FromAddress,
                Name = _settings.FromName
            };
            var Message = MailHelper.CreateSingleEmail(From, To, email.Subject, email.Body, email.Body);

            var response = await Client.SendEmailAsync(Message);
            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}