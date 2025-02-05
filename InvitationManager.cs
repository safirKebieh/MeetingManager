using System;
using System.Net.Mail;
using System.Net;
using Spectre.Console;
using System.Collections.Generic;
using System.Windows.Forms;

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
            var recipientEmails = CollectEmailAddresses();

            if (recipientEmails.Count == 0)
            {
                Console.WriteLine("No valid email addresses entered. Exiting.");
                return;
            }

            bool success = SendEmailToRecipients(recipientEmails);

            if (success)
            {
                AnsiConsole.WriteLine("The email was sent successfully!");
            }
            else
            {
                Console.WriteLine("Failed to send the email.");
            }
        }

        // Collect email addresses from the user
        private static List<string> CollectEmailAddresses()
        {
            var emails = new List<string>();
            string input;

            AnsiConsole.Markup("Enter email addresses (type 'done' when finished):\n");

            while (true)
            {
                Console.Write("Email: ");
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input)) continue;
                if (input.Equals("done", StringComparison.OrdinalIgnoreCase)) break;

                if (IsValidEmail(input))
                {
                    emails.Add(input);
                }
                else
                {
                    Console.WriteLine("Invalid email format. Try again.");
                }
            }

            return emails;
        }

        // Send the email to all collected recipients
        private static bool SendEmailToRecipients(List<string> recipientEmails)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("JetsiMeetingManager@gmail.com", "jclu vzim hcou hqlf"),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("JetsiMeetingManager@gmail.com"),
                    Subject = "Test Email",
                    Body = $"You are invited to a Jitsi meeting. \nHere is the link: {MeetingLauncher.MeetingLink}"
                };

                foreach (var email in recipientEmails)
                {
                    mailMessage.To.Add(email);
                }

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Validate the format of an email
        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static void CopyMeetingLink()
        {
            if (string.IsNullOrEmpty(MeetingLauncher.MeetingLink))
            {
                Console.WriteLine("Meeting link is empty or unavailable.");
                return;
            }

            // Copy to clipboard
            Clipboard.SetText(MeetingLauncher.MeetingLink);

            // Print the link
            Console.WriteLine($"Meeting link is copied to your clipboard: {MeetingLauncher.MeetingLink}");
        }
    }
}
