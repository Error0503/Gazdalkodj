using System.Collections.Generic;

namespace Gazdalkodj
{
    public class Data : IData
    {
        Dictionary<string, int> data = new Dictionary<string, int>();

        public void Create(string name)
        {
            if (!data.ContainsKey(name)) data.Add(name, 5000000);
        }

        public int Get(string name)
        {
            if (data.ContainsKey(name)) return data[name];
            return 0;
        }

        public void Set(string name, int value)
        {
            if (data.ContainsKey(name)) data[name] = value;
        }
    }
}