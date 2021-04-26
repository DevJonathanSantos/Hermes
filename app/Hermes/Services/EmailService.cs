using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Hermes.Interfaces;
using Hermes.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }
        public async Task EnviarEmail()
        {
            List<Email> emails = await _emailRepository.ObterEmails();

            if (emails == null || emails.Count < 1) { return; }

            foreach (var email in emails)
            {
                List<string> para = new List<string>();

                if (!string.IsNullOrEmpty(email.Para))
                {
                    foreach(var emailPara in email.Para.Split(";"))
                    {
                        para.Add(emailPara);
                    }
                }

                List<string> comCopia = new List<string>();

                if (!string.IsNullOrEmpty(email.ComCopia))
                {
                    foreach (var emailComCopia in email.ComCopia.Split(";"))
                    {
                        para.Add(emailComCopia);
                    }
                }

                List<string> copiaOculta = new List<string>();

                if (!string.IsNullOrEmpty(email.CopiaOculta))
                {
                    foreach (var emailComCopia in email.CopiaOculta.Split(";"))
                    {
                        para.Add(emailComCopia);
                    }
                }

                List<string> replyTo = new List<string>();

                if (!string.IsNullOrEmpty(email.ReplyTo))
                {
                    foreach (var emailReplyTo in email.ReplyTo.Split(";"))
                    {
                        para.Add(emailReplyTo);
                    }
                }

                using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.USWest2))
                {
                    var sendRequest = new SendEmailRequest
                    {
                        Source = email.De,
                        Destination = new Destination
                        {
                            ToAddresses = para,
                            CcAddresses= comCopia,
                            BccAddresses = copiaOculta
                        },
                        Message = new Message
                        {
                            Subject = new Content(email.Assunto),
                            Body = new Body
                            {
                                Html = new Content
                                {
                                    Charset = "UTF-8",
                                    Data = ""
                                },
                                Text = new Content
                                {
                                    Charset = "UTF-8",
                                    Data = "OOOu mai god"
                                }
                            }
                        },
                        ReplyToAddresses=replyTo
                    };
                    try
                    {
                        Console.WriteLine("Sending email using Amazon SES...");
                        var response = client.SendEmailAsync(sendRequest);
                        Console.WriteLine("The email was sent successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The email was not sent.");
                        Console.WriteLine("Error message: " + ex.Message);

                    }
                }
            }
        }
    }
}
