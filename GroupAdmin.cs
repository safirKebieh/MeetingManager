using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace MeetingManager
{
    public class GroupAdmin
    {
        public static List<Group> Groups { get; private set; } = new List<Group>();

        public static void ShowListManageGroups()
        {
            NavigationSystem.MenuSelection(NavigationSystem.ListCreater(StringResources.ListManageGroups, "Groups Management"));
        }
        public static void LoadGroups(string filePath)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (!File.Exists(filePath))
            {
                AnsiConsole.MarkupLine("[bold red]⚠  Error:[/] [yellow]The CSV file was not found.[/]");
                AnsiConsole.MarkupLine("[bold]Please ensure that the file exists and is correctly named as '[cyan]{0}[/]'.[/]", filePath);
                Thread.Sleep(4000);
                Environment.Exit(1);
            }

            Dictionary<string, Group> groupDictionary = new Dictionary<string, Group>();

            foreach (var line in File.ReadLines(filePath).Skip(1)) // Skip header
            {
                var parts = line.Split(',');
                if (parts.Length != 3) continue; // Skip invalid lines

                string groupName = parts[0].Trim();
                string userName = parts[1].Trim();
                string email = parts[2].Trim();

                var recipient = new Recipient(userName, email);

                if (!groupDictionary.ContainsKey(groupName))
                {
                    groupDictionary[groupName] = new Group(groupName, new List<Recipient>());
                }

                groupDictionary[groupName].Members.Add(recipient);
            }

            Groups = groupDictionary.Values.ToList();
            Console.WriteLine("Groups loaded successfully.");
        }
        public static void AddGroup()
        {

        }

        public static void ShowGroup()
        {

        }

        public static void DeleteGroup()
        {
            
        }

        public static void ModifyGroup()
        {

        }
    }
}
