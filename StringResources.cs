using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MeetingManager
{
    public class StringResources
    {
        public static readonly ReadOnlyCollection<string> ListMenu = new ReadOnlyCollection<string>(new List<string>
        {
            CreateRoom,
            JoinRoom,
            Settings,
            Exit
        });

        public static readonly ReadOnlyCollection<string> ListManageInvites = new ReadOnlyCollection<string>(new List<string>
        {
            InviteByEmail,
            InviteFromDataBase,
            CopyInviteLink,
            BackToMainMenu
        });

        public static readonly ReadOnlyCollection<string> ListManageGroups = new ReadOnlyCollection<string>(new List<string>
        {
            AddGroup,
            DeleteGroup,
            ModifyGroup,
            BackToSettings
        });

        public static readonly ReadOnlyCollection<string> ListSettings = new ReadOnlyCollection<string>(new List<string>
        {
            GroupsManagement,
            Languages,
            BackToMainMenu
        });

        // List Menu
        public const string CreateRoom = "\U00002795 Create Room";
        public const string JoinRoom = "\U00002795 Join Room";
        public const string Settings = "\U00002795 Settings";
        public const string Exit = "❌ Exit";

        // List ManageInvites
        public const string InviteByEmail = "➕ Send invitation via email.";
        public const string InviteFromDataBase = "➕ Send invitation from contact list.";
        public const string CopyInviteLink = "➕ Copy and share the invitation link.";

        // List ManageGroups
        public const string AddGroup = "➕ Add a new Group";
        public const string DeleteGroup = "➕ Delete an Existing Group";
        public const string ModifyGroup = "➕ Modify an Existing Group";
        public const string BackToSettings = "➕ Back to Settings";

        // List Options
        public const string GroupsManagement = "\U00002795 Groups Management";
        public const string Languages = "➕ Language Selection";
        public const string BackToMainMenu = "➕ Back to MainMenu";

        //General
        public const string promptMessageRoomID = "[bold blue]Enter your Room ID:[/] ";
        public const string errorMessageRoomID = "[bold red]Invalid Room ID! It must be between 3 and 12 characters long[/]\n";
        public const string promtMessageUser = "[bold blue]Enter your username:[/] ";
        public const string errorMessageUser = "[bold red]Invalid username! It must be between 3 and 12 characters long.[/]\n";
        public const string welcomeMessage = "\n\n :rocket: :rocket: :rocket: MeetingManager – Simplifying Your Meetings. :rocket: :rocket: :rocket:\n\n\n\"";
    }
}