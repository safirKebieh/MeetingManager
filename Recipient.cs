namespace MeetingManager
{
    public class Recipient
    {
        private string Name { get; set; }
        private string Email { get; set; }

        public Recipient(string name, string email) 
        {
            Name = name;
            Email = email;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string email)
        {
            this.Email = email;
        }

    }
}
