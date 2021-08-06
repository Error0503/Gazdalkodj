using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
namespace Server.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {

        public DataController(IData data)
        {
            Data = data;
        }

        [HttpPut("register")]
        public int Create(string name)
        {
            return Data.Create(name);
        }

        [HttpGet("details")]
        public int Get(string name)
        {
            return Data.Get(name);
        }

        [HttpPost("add")]
        public int Add(string name, int value)
        {
            return Data.Add(name, value);
        }

        [HttpPost("substract")]
        public int Substract(string name, int value)
        {
            return Data.Substract(name, value);
        }

        [HttpDelete("forget")]
        public int Delete(string name)
        {
            return Data.Delete(name);
        }

        public IData Data { get; }
    }
}
