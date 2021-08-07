using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class RegisterModel : PageModel
    {
        public int ResponseCode { get; private set; } = 0;
        public string Output { get; private set; } = "";

        public void OnPost()
        {
            string name = Request.Form["username"];
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrWhiteSpace(name))
            {
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                ResponseCode = refer.RegisterAsync(name).Result;
                if (ResponseCode == 201)
                {
                    Output += name + " felhasználó sikeresen létrehozva!";
                    TempData.Add("username", name);
                }
                else if (ResponseCode == 409)
                {
                    Output += "Hiba\n'" + name + "' nevű felhasználó már létezik!";
                }
                else
                {
                    Output += "Ismeretlen hiba!";
                }
            }
            else
            {
                Output += "Adj meg egy felhasználónevet!";
            }
        }
    }
}
