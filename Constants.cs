using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MeetingManager
{
    public class Constants
    {
        // Create a list of choices
        public static List<string> ListMenu = new List<string>
        {
            StartRoom,
            JoinRoom,
            Exit
        };
        public const string StartRoom = "\U00002795 Open Room";
        public const string JoinRoom = "\U00002795 Join Room";
        public const string Exit = "❌ Exit";
        public const string promptMessageRoomID = "[bold blue]Please Enter your Room ID:[/] ";
        public const string errorMessageRoomID = "[bold red]Invalid Room ID! It must be between 3 and 12 characters.[/]\n";
        public const string promtMessageUser = "[bold blue]Please Enter username:[/] ";
        public const string errorMessageUser = "[bold red]Invalid username! It must be between 3 and 12 characters.[/]\n";
    }
}
