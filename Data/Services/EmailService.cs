using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace QLThuQuan.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mailSettings = _configuration.GetSection("EmailSettings");
                
                var smtpClient = new SmtpClient(mailSettings["MailServer"])
                {
                    Port = int.Parse(mailSettings["MailPort"]),
                    Credentials = new NetworkCredential(mailSettings["SenderEmail"], mailSettings["Password"]),
                    EnableSsl = bool.Parse(mailSettings["EnableSsl"]),
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(mailSettings["SenderEmail"], mailSettings["SenderName"]),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                throw;
            }
        }
    }
}