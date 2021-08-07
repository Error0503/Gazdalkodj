using Server.Interfaces;
using System.Collections.Generic;

namespace Server.Models
{
    public class Data : IData
    {
        private readonly Dictionary<string, int> dict = new Dictionary<string, int>();

        public int Create(string name)
        {
            if (!dict.ContainsKey(name))
            {
                dict.Add(name, 5000000);
                return 201;
            }
            return 409;
        }

        public int Get(string name)
        {
            if (dict.ContainsKey(name)) return dict[name];
            return 404;
        }

        public int Add(string name, int value)
        {
            if (dict.ContainsKey(name))
            {
                dict[name] += value;
                return 200;
            }
            return 404;
        }

        public int Substract(string name, int value)
        {
            if (dict.ContainsKey(name))
            {
                dict[name] -= value;
                return 200;
            }
            return 404;
        }

        public int Delete(string name)
        {
            if (dict.ContainsKey(name))
            {
                dict.Remove(name);
                return 200;
            }
            return 404;
        }
    }
}
