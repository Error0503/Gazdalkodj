using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class AdminModel : PageModel
    {
        public string Output { get; private set; } = "";

        public void OnGet()
        {
            if ((Boolean)TempData.Peek("isAdmin"))
            {
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                IDictionary<string, int> result = refer.AdminAsync().Result;
                if (result.Count != 0)
                {
                foreach (KeyValuePair<string, int> item in result)
                {
                    Output += item.Key + "\t" + item.Value.ToString("C", Globals.nfi) + "\n";
                }
                } else
                {
                    Output += "Nincs adat";
                }
            }
        }

        public void OnPost()
        {
            string input = Request.Form["pass"];
            if (input.Equals("f-original"))
            {
                TempData["isAdmin"] = true;
                Response.Redirect("admin");
            }
        }
    }
}
