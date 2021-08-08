using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface IData
    {
        public int Create(string name);
        public int Get(string name);
        public int Add(string name, int value);
        public int Substract(string name, int value);
        public int Delete(string name);
        public Dictionary<string, int> GetAll();
    }
}
