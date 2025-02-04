using Spectre.Console;
using System;

namespace MeetingManager
{
    public class NavigationSystem
    {
        public static void MainMenu()
        {  // This function must be template to call it again and again 
            Console.Title = "MeetingManager";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AnsiConsole.Markup(StringResources.welcomeMessage);

            var selectedOption = AnsiConsole.Prompt(
              new SelectionPrompt<string>()
                  .PageSize(5)
                  .AddChoices(StringResources.ListMenu)
                  .HighlightStyle(new Style(Color.Green)));

            MenuSelection(selectedOption);
        }

        static void MenuSelection(string selectedOption)
        {
            switch (selectedOption)
            {
                case StringResources.CreateRoom:
                    MeetingLauncher.GenerateMeetingLink(true);
                    break;
                case StringResources.JoinRoom:
                    MeetingLauncher.GenerateMeetingLink();
                    break;
                case StringResources.Exit:
                    // TBD
                    break;
                default:
                    break;
            }
        }
    }
}