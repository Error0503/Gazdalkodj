using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class RegisterModel : PageModel
    {
        public int ResponseCode { get; private set; } = 0;
        public string Output { get; private set; } = "";
        private bool createNew = true;

        public void OnGet()
        {
            if (TempData.Peek("username") != null)
            {
                ResponseCode = 5;
            }
        }

        public void OnPost()
        {
            createNew = true;
            CreateUser();
        }

        public void OnPostConfirm()
        {
            createNew = false;
            CreateUser();
        }

        public void OnPostCancel()
        {
            Response.Redirect("http://localhost:4000/Details");
        }

        public void CreateUser()
        {
            string name = Request.Form["username"];
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrWhiteSpace(name))
            {
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                ResponseCode = refer.RegisterAsync(name).Result;
                if (ResponseCode == 201)
                {
                    if (createNew)
                    {
                        TempData.Add("username", name);
                    }
                    else
                    {
                        TempData["username"] = name;
                    }
                    Output += name + " felhasználó sikeresen létrehozva!";
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
