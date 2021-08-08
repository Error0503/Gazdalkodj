using System;
using System.Collections.Generic;

namespace Server.Interfaces
{
    public interface IUser
    {
        public void AddEntry(string time, int value);
        public void RemoveEntry(string time, int value);
        public KeyValuePair<string, int> GetEntry(string time);
        public Dictionary<String, int> GetAllEnrties();
    }
}