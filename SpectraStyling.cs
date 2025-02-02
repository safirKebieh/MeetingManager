using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingManager.Properties;

namespace MeetingManager
{
    public class SpectraStyling
    {
        public static void MainMenu()
        {
            Console.Title = "MeetingManager";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            AnsiConsole.Markup("[bold]Wellcome in our Program[/]\n\"");

            var selectedOption = AnsiConsole.Prompt(
              new SelectionPrompt<string>()
                  .Title("[bold]Use arrow keys to select an action:[/]")
                  .PageSize(5)
                  .AddChoices(Constants.ListMenu)
                  .HighlightStyle(new Style(Color.Green))
          );
            SelectionOptions(selectedOption);
        }

        static void SelectionOptions(string selectedOption)
        {
            switch (selectedOption)
            {
                case Constants.StartMeeting:
                    // Do something
                    Console.WriteLine("Hi");
                    break;
                case Constants.JoinMeeting:
                    // Do something
                    break;
                case Constants.Exit:
                    // Do Something
                    break;
                default:
                    break;
            }
        }
    }
}