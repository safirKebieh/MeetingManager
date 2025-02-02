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
            StartMeeting,
            JoinMeeting,
            Exit
        };

        public const string StartMeeting = "\U00002795 Start Meeting";
        public const string JoinMeeting = "\U00002795 Join Meeting";
        public const string Exit = "❌ Exit";

    }
}
