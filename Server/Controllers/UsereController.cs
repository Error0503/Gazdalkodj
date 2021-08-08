using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Server.Interfaces;
using System;

namespace Server.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUser user)
        {
            User = user;
        }

        [HttpPut("addentry")]
        public void AddEntry(string time, int value)
        {
            User.AddEntry(time, value);
        }

        [HttpGet("getsingleentry")]
        public String[] GetEntry(string time)
        {
            
            return new string[] { };
        }

        [HttpDelete("deleteentry")]
        public void RemoveEntry(string time, int value)
        {
            User.RemoveEntry(time, value);
        }

        [HttpGet("getallentries")]
        public Dictionary<String, int> GetAllEntries()
        {
            return User.GetAllEnrties();
        }

        public IUser User { get; }
    }
}
