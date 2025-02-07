﻿using Spectre.Console;
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
            

            MenuSelection(ListCreater(StringResources.ListMenu,"Meeting Manager"));
        }

        public static void MenuSelection(string selectedOption)
        {
            switch (selectedOption)
            {
                case StringResources.CreateRoom:
                    MeetingLauncher.GenerateMeetingLink(true);
                    break;
                case StringResources.JoinRoom:
                    MeetingLauncher.GenerateMeetingLink(false, true);
                    break;
                case StringResources.Settings:
                    SettingsManager.ShowListSettings();
                    break;
                case StringResources.Exit:
                    //TBD
                    break;
                case StringResources.GroupsManagement:
                    GroupAdmin.ShowListManageGroups();
                    break;
                case StringResources.Languages:
                    //ToDo
                    break;
                case StringResources.BackToMainMenu:
                    MenuSelection(ListCreater(StringResources.ListMenu, "Meeting Manager"));
                    break;
                case StringResources.InviteByEmail:
                    InvitationManager.SendEmail();
                    break;
                case StringResources.InviteFromDataBase:
                    //TBD
                    break;
                case StringResources.CopyInviteLink:
                    InvitationManager.CopyMeetingLink();
                    break;
                default:
                    break;
            }
        }

        public static string ListCreater(ReadOnlyCollection<string> choicesList, string banner)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText(banner).Color(Color.Green).Justify(Justify.Center));

            var selectedOption = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
                 .Title("")
                 .PageSize(5)
                 .AddChoices(choicesList)
                 .HighlightStyle(new Style(Color.Green)));

            return selectedOption;
        }
    }
}