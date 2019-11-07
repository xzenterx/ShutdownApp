using System;
using System.Collections.Generic;
using System.Text;

namespace ShutdownApp.Program
{
    public class Profile
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }

        public Profile(string name, TimeSpan time)
        {
            Name = name;
            Time = time;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
