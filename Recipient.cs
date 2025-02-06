﻿namespace MeetingManager
{
    public class Recipient
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Recipient(string name, string email) 
        {
            Name = name;
            Email = email;
        }
    }
}
