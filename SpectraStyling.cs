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

            // Create a list of choices
            var options = new List<string>
        {
            "\U00002795 Start Meeting",
            "\U00002795 Join Meeting",
            "❌ Exit"
        };

            var selectedOption = AnsiConsole.Prompt(
              new SelectionPrompt<string>()
                  .Title("[bold]Use arrow keys to select an action:[/]")
                  .PageSize(5)
                  .AddChoices(options)
                  .HighlightStyle(new Style(Color.Green))
          );

            AnsiConsole.Markup($"\n[bold green]✔ You selected: {selectedOption}[/]\n");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}