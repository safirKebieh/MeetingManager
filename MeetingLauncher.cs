using Spectre.Console;
using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using static System.Net.WebRequestMethods;

namespace MeetingManager
{
    public class MeetingLauncher
    {
        public static void GenerateMeetingLink(bool isCreate = false)
        {
            Console.Clear();

            // Get a valid meeting name (Room ID)
            string meetingName = GetValidatedInput(
                promptMessage: StringResources.promptMessageRoomID,
                errorMessage: StringResources.errorMessageRoomID) + DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 5);

            // Generate the Jitsi meeting URL with user info (before asking for email and username)
            string meetingLink = $"https://meet.jit.si/{meetingName}";

            // Ask for the recipient email address before the username
            if (isCreate)
                TBDInvitePeopleStep(meetingLink); // Ask for email first

            // Get a valid username
            string username = GetValidatedInput(
                promptMessage: StringResources.promtMessageUser,
                errorMessage: StringResources.errorMessageUser);

            // Encode the username to handle special characters
            string encodedUserName = Uri.EscapeDataString(username);

            // Add user info to the meeting link
            meetingLink = $"{meetingLink}#userInfo.displayName=\"{encodedUserName}\"";

            // Open the meeting in the default web browser
            Process.Start(new ProcessStartInfo(meetingLink) { UseShellExecute = true });

            AnsiConsole.Markup("[bold red]Your Meeting is ready. Check your Browser![/] ");
        }

        private static string GetValidatedInput(string promptMessage, string errorMessage)
        {
            string input;
            bool isValid = false;

            do
            {
                AnsiConsole.Markup(promptMessage);
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input) || input.Length < 3 || input.Length > 20)
                {
                    Console.Clear();
                    AnsiConsole.Markup(errorMessage);
                }
                else
                {
                    Console.Clear();
                    isValid = true;
                }
            }
            while (!isValid);

            return input;
        }

        private static void TBDInvitePeopleStep(string meetingLink)
        {
            // Ask the user for the recipient email address
            Console.WriteLine("Please enter the email address to send an email to:");
            string recipientEmail = Console.ReadLine(); // Get email from user input

            // Call the method to send the email
            SendEmail(recipientEmail, meetingLink);

            Console.WriteLine("Email has been sent successfully!");
        }

        static void SendEmail(string recipientEmail, string meetingLink)
        {
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
                    Body = $"This is an invite to a jetsi meeting. \n This is the link {meetingLink}"
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
        }
    }
}

