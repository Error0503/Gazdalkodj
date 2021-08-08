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
            Console.WriteLine(TempData.Peek("isAdmin"));
            if ((Boolean)TempData.Peek("isAdmin"))
            {
                Console.WriteLine("true");
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                IDictionary<string, int> result = refer.AdminAsync(Request.Form["pass"]).Result;
                foreach (KeyValuePair<string, int> item in result)
                {
                    Console.WriteLine(item.Key + "\t" + item.Value);
                    Output += item.Key + "\t" + item.Value;
                }
            }
        }

        public void OnPost()
        {
            string input = Request.Form["pass"];
            Console.WriteLine(input);
            if (input.Equals("f-original"))
            {
                TempData["isAdmin"] = true;
            }
        }
    }
}
