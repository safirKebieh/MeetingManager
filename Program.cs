using System;

namespace MeetingManager
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            GroupAdmin.LoadGroups("..//..//groups.csv"); //ToDo: must be relative Path, Decide later where and how.
            NavigationSystem.MainMenu();
        }
    }
}
