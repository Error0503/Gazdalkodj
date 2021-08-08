using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class AdminModel : PageModel
    {
        public short Status { get; private set; } = 2;
        public string Output { get; private set; } = "";

        public void OnGet()
        {
            if ((Boolean)TempData.Peek("isAdmin"))
            {
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                foreach (KeyValuePair<string, int> item in refer.AdminAsync(Request.Form["pass"]).Result)
                {
                    Output += item.Key + "\t" + item.Value;
                }
            }
        }

        public void OnPost()
        {
            if (Request.Form["pass"].Equals("f-original"))
            {
                TempData["isAdmin"] = true;
            }
        }
    }
}
