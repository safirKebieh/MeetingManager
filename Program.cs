using System;

namespace MeetingManager
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            GroupAdmin.LoadGroups();
            NavigationSystem.MainMenu();
        }
    }
}
