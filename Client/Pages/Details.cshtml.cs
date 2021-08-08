using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace Client.Pages
{
    public class DetailsModel : PageModel
    {
        public short Status { get; private set; } = 2;
        public string Output { get; private set; } = "";
        public string Balance { get; private set; } = "";

        public void OnGet()
        {
            if (TempData.Peek("username") != null)
            {
                string name = TempData.Peek("username").ToString();
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                Status = 1;
                Output += name + " felhasználó egyenlege: ";
                NumberFormatInfo nfi = new CultureInfo("hu-HU", false).NumberFormat;
                nfi.CurrencyDecimalDigits = 0;
                int value = refer.DetailsAsync(name).Result;
                
                Balance += value.ToString("C", nfi);
            }
            else
            {
                Status = 0;
                Output += "Még nem regisztráltál!";
            }
        }
    }
}
