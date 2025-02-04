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
            AnsiConsole.Markup("Enter the recipient's email address:");
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
                    Body = $"You are invited to a Jitsi meeting. \nHere is the link: {MeetingLauncher.MeetingLink}"
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
            AnsiConsole.Markup("The email was sent successfully!\n");
        }
    }
}
