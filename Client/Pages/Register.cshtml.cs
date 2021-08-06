using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class RegisterModel : PageModel
    {
        public string Output { get; private set; } = "";

        public void OnPost()
        {
            string name = Request.Form["username"];
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrWhiteSpace(name))
            {
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                int status = refer.RegisterAsync(name).Result;
                if (status == 201)
                {
                    Output += name + " felhasználó sikeresen létrehozva!";
                    TempData.Add("username", new String(name));
                }
                else if (status == 409)
                {
                    Output += "Hiba\n'" + name + "' nevű felhasználó már létezik!";
                }
                else
                {
                    Output += "Ismeretlen hiba!";
                }
            } else
            {
                Output += "Adj meg egy felhasználónevet!";
            }
        }
    }
}
