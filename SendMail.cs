using System;
using System.Net;
using System.Net.Mail;


class SendMail
{

    static void Main(string[] args)
    {
        var fromAddress = new MailAddress("awoo2008@gmail.com", "Anthony Wu");
        var toAddress = new MailAddress("bwu.67041@seymour.sa.edu.au", "Benita Wu");
        const string fromPassword = "qptx oqtm sasm onid";
        const string subject = "Hello from C#";
        const string body = "It's so much fun learning C#";
        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            Timeout = 20000
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
    }
}
