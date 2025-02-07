using Spectre.Console;
using System;
using System.Diagnostics;
using System.Reflection;

namespace MeetingManager
{
    public class MeetingLauncher
    {
        public static string MeetingLink = "";

        public static void GenerateMeetingLink(bool isCreate = false, bool isJoin = false)
        {
            Console.Clear();
            string banner = "";
            //Show Banner
            if (isCreate)
                banner = "Create Meeting";
            else
                banner = "Join Meeting";

            AnsiConsole.Write(new FigletText(banner).Color(Color.Green).Justify(Justify.Center));
            // Get a valid meeting name (Room ID)
            string meetingName = GetValidatedInput(
                promptMessage: StringResources.promptMessageRoomID, // ( ) ? : ;  if join + ""  / if create + DateTime .... 
                errorMessage: StringResources.errorMessageRoomID) + (isJoin ? "" : DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 5));

            // Generate the Jitsi meeting URL with user info (before asking for email and username)
            MeetingLink = $"https://meet.jit.si/{meetingName}";

            if (isCreate)
            {
                InvitationManager.ShowListManageInvites();
            }

            // Get a valid username
            string username = GetValidatedInput(
                promptMessage: StringResources.promtMessageUser,
                errorMessage: StringResources.errorMessageUser);

            // Encode the username to handle special characters
            string encodedUserName = Uri.EscapeDataString(username);

            // Add user info to the meeting link
            MeetingLink = $"{MeetingLink}#userInfo.displayName=\"{encodedUserName}\"";

            // Open the meeting in the default web browser
            Process.Start(new ProcessStartInfo(MeetingLink) { UseShellExecute = true });

            AnsiConsole.Markup("[bold red]Your meeting is ready. Please check your browser.[/] ");
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
    }
}

