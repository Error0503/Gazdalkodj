using System;
using Microsoft.AspNetCore.Mvc;

namespace Gazdalkodj.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {

        public DataController(IData data)
        {
            Data = data;
        }

        [HttpPut("create")]
        public void Create(String name)
        {
            Data.Create(name);
        }

        [HttpGet("detail")]
        public int ListDetail(String name)
        {
            return Data.Get(name);
        }

        [HttpPost("update")]
        public void Update(string name, int value)
        {
            Data.Set(name, value);
        }

        public IData Data { get; }
    }
}