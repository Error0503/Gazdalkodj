using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace Client.Pages
{
    public class TransactionModel : PageModel
    {

        public string Output { get; private set; } = "";
        public int ResponseCode { get; private set; } = 0;

        public void OnGet()
        {
            if (TempData.Peek("username") == null)
            {
                Output += "Még nem regisztráltál!";
            }
        }
        
        public void OnPostPlus()
        {
            Execute('+');
        }

        public void OnPostMinus()
        {
            Execute('-');
        }
        
        private void Execute(char operation)
        {
            if (TempData.Peek("username") != null)
            {
                int value = int.Parse(Request.Form["ammount"]);
                Console.WriteLine(value);
                if (value > 0)
                {
                    string username = TempData.Peek("username").ToString();

                    string url = "";
                    if (operation == '+') url = "http://localhost:5000/add";
                    if (operation == '-') url = "http://localhost:5000/substract";
                    Reference refer = new Reference(url, new System.Net.Http.HttpClient());

                    if (operation == '+') ResponseCode = refer.AddAsync(username, value).Result;
                    if (operation == '-') ResponseCode = refer.SubstractAsync(username, value).Result;

                    if (ResponseCode == 200)
                    {
                        Output += "Sikeres tranzakció!";
                    }
                    else
                    {
                        Output += "Hiba történt!";
                    }
                }
                else
                {
                    Output += "Adj meg egy nem negatív összeget!";
                }
            }
            else
            {
                Output += "Még nem regisztráltál!";
            }
        }
    }
}
