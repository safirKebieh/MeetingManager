using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MeetingManager
{
    public class NavigationSystem
    {
        public static void MainMenu()
        {  // This function must be template to call it again and again 
            Console.Title = "MeetingManager";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AnsiConsole.Markup(StringResources.welcomeMessage);

            MenuSelection(ListCreater(StringResources.ListMenu));
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

        public static string ListCreater(ReadOnlyCollection<string> choicesList)
        {
            var selectedOption = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
                 .PageSize(5)
                 .AddChoices(choicesList)
                 .HighlightStyle(new Style(Color.Green)));

            return selectedOption;
        }
    }
}