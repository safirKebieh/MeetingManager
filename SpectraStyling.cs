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
        // Create a list of choices
        static List<string> ListMenu = new List<string>
        {
            "\U00002795 Start Meeting",
            "\U00002795 Join Meeting",
            "❌ Exit"
        };

        public static void MainMenu()
        {
            Console.Title = "MeetingManager";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            AnsiConsole.Markup("[bold]Wellcome in our Program[/]\n\"");

            var selectedOption = AnsiConsole.Prompt(
              new SelectionPrompt<string>()
                  .Title("[bold]Use arrow keys to select an action:[/]")
                  .PageSize(5)
                  .AddChoices(ListMenu)
                  .HighlightStyle(new Style(Color.Green))
          );
            SelectionOptions(selectedOption);
        }

        static void SelectionOptions(string selectedOption)
        {
            switch (selectedOption)
            {
                case "\U00002795 Start Meeting":
                    // Do something
                    break;
                case "\U00002795 Join Meeting":
                    // Do something
                    break;
                case "❌ Exit":
                    // Do Something
                    break;
                default:
                    break;
            }
        }
    }
}