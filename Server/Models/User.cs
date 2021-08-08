using Server.Interfaces;
using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class User : IUser
    {
        private string username; // TODO: New User object per user
        private readonly Dictionary<String, int> log = new Dictionary<String, int>();

        public void AddEntry(String time, int value)
        {
            log.Add(time, value);
        }

        public void RemoveEntry(String time, int value)
        {
            if (log.ContainsKey(time))
            {
                if (log[time] == value)
                {
                    log.Remove(time);
                }
            }
        }

        public KeyValuePair<String, int> GetEntry(String time)
        {
            if (log.ContainsKey(time))
            {
                return new KeyValuePair<String, int>(time, log[time]);
            }
            return new KeyValuePair<String, int>();
        }

        public Dictionary<String, int> GetAllEnrties()
        {
            return log;
        }
    }
}
