﻿using Spectre.Console;
using System;
using System.Diagnostics;

namespace MeetingManager
{
    public class MeetingLauncher
    {
        public static void GenerateMeetingLink()
        {
            Console.Clear();

            // Get a valid meeting name
            string meetingName = GetValidatedInput(
                promptMessage: Constants.promptMessageRoomID,
                errorMessage: Constants.errorMessageRoomID) + DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 5);

            // Get a valid username
            string username = GetValidatedInput(
                promptMessage: Constants.promtMessageUser,
                errorMessage: Constants.errorMessageUser);

            // Encode the username to handle special characters
            string encodedUserName = Uri.EscapeDataString(username);

            // Generate the Jitsi meeting URL with user info
            string meetingLink = $"https://meet.jit.si/{meetingName}#userInfo.displayName=\"{encodedUserName}\"";

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

                if (string.IsNullOrWhiteSpace(input) || input.Length < 3 || input.Length > 12)
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
