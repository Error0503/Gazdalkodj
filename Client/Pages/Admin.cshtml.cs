using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class AdminModel : PageModel
    {
        public string Output { get; private set; } = "";
        public string Logs { get; private set; } = "";

        public void OnGet()
        {
            if ((Boolean)TempData.Peek("isAdmin"))
            {
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                IDictionary<string, int> user_data = refer.AdminAsync().Result;
                IDictionary<string, int> logs = refer.GetallentriesAsync().Result;

                if (user_data.Count != 0)
                {
                    foreach (KeyValuePair<string, int> item in user_data)
                    {
                        Output += item.Key + "\t" + item.Value.ToString("C", Globals.nfi) + "\n";
                    }
                }
                else
                {
                    Output += "Nincs adat";
                }
                if (logs.Count != 0)
                {
                    foreach (KeyValuePair<string, int> item in logs)
                    {
                        Logs += item.Key + "\t" + item.Value + "\n";
                    }
                } else
                {
                    Logs += "Nincs log :(";
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
