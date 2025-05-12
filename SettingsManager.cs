namespace MeetingManager
{
    public class SettingsManager
    {
        public static void ShowListSettings()
        {
            NavigationSystem.MenuSelection(NavigationSystem.ListCreater(StringResources.ListSettings, "Settings"));
        }
    }
}
