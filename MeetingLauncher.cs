using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManager
{
    public class MeetingLauncher
    {   
        public void GenerateMeetingLink()
        {
            // Generate a unique meeting name
            string meetingName = "JitsiMeeting" + DateTime.Now.Ticks;
            string userName = "Safir#ä"; // Change this to any name

            // Encode the user name to handle special characters
            string encodedUserName = Uri.EscapeDataString(userName);

            // Generate the Jitsi meeting URL with user info
            string meetingLink = $"https://meet.jit.si/{meetingName}#userInfo.displayName=\"{encodedUserName}\"";

            Console.WriteLine($"📅 Meeting Created: {meetingLink}");

            // Open the meeting in the default web browser
            Process.Start(new ProcessStartInfo(meetingLink) { UseShellExecute = true });

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
