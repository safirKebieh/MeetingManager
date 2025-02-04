using System;
using System.Net.Mail;
using System.Net;
using Spectre.Console;

namespace MeetingManager
{
    public class InvitationManager
    {
        public static void InvitePeopleMenu()
        {
            NavigationSystem.MenuSelection(NavigationSystem.ListCreater(StringResources.ListManageInvites));
        }

        public static void SendEmail()
        {
            AnsiConsole.Markup("Please enter the email address to send an email to:");
            string recipientEmail = Console.ReadLine();

            try
            {
                // Set up the SMTP client (Gmail example)
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // SMTP port for Gmail
                    Credentials = new NetworkCredential("JetsiMeetingManager@gmail.com", "jclu vzim hcou hqlf"), // Use your email and app password
                    EnableSsl = true // Enable SSL encryption
                };

                // Create the email message
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("JetsiMeetingManager@gmail.com"), // Your email as the sender
                    Subject = "Test Email",
                    Body = $"This is an invite to a jetsi meeting. \n This is the link {MeetingLauncher.MeetingLink}"
                };

                // Add the recipient's email address
                mailMessage.To.Add(recipientEmail); // The email address entered by the user

                // Send the email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., invalid email address, network issues)
                Console.WriteLine($"Error: {ex.Message}");
            }
            AnsiConsole.Markup("Email has been sent successfully!");
        }
    }
}
