using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MeetingManager
{
    public class NavigationSystem
    {
        public static void MainMenu()
        {
            Console.Title = "MeetingManager";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Banner throw Spectra
            AnsiConsole.Write(new FigletText("Meeting Manager").Color(Color.Green).Justify(Justify.Center));

            MenuSelection(ListCreater(StringResources.ListMenu));
        }

        public static void MenuSelection(string selectedOption)
        {
            switch (selectedOption)
            {
                case StringResources.CreateRoom:
                    MeetingLauncher.GenerateMeetingLink(true);
                    break;
                case StringResources.JoinRoom:
                    MeetingLauncher.GenerateMeetingLink(false,true);
                    break;
                case StringResources.Exit:
                    //TBD
                    break;
                case StringResources.InviteByEmail:
                    InvitationManager.SendEmail();
                    break;
                case StringResources.InviteFromDataBase:
                    //TBD
                    break;
                case StringResources.CopyInviteLink:
                    //TBD
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