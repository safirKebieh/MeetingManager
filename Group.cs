using System;
using System.Collections.Generic;

namespace MeetingManager
{
    public class Group
    {
        public string Name { get; set; }
        public List<Recipient> Members { get; set; }

        public Group(string name, List<Recipient> recipients)
        {
            Name = name;
            Members = recipients;
        }
    }
}
