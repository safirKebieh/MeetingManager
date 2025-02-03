using System.Collections.Generic;

namespace MeetingManager
{
    public class StringResources
    {
        public static List<string> ListMenu = new List<string>
        {
            CreateRoom,
            JoinRoom,
            Exit
        };
        
        public const string CreateRoom = "\U00002795 Create Room";
        public const string JoinRoom = "\U00002795 Join Room";
        public const string Exit = "❌ Exit";
        public const string promptMessageRoomID = "[bold blue]Please Enter your Room ID:[/] ";
        public const string errorMessageRoomID = "[bold red]Invalid Room ID! It must be between 3 and 12 characters.[/]\n";
        public const string promtMessageUser = "[bold blue]Please Enter username:[/] ";
        public const string errorMessageUser = "[bold red]Invalid username! It must be between 3 and 12 characters.[/]\n";
        public const string welcomeMessage = "\n\n :rocket: :rocket: :rocket: MeetingManager – Simplifying Your Meetings. :rocket: :rocket: :rocket:\n\n\n\"";
    }
}
