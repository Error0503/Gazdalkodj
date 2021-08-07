using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class DetailsModel : PageModel
    {
        public short Status { get; private set; } = 2;
        public string Output { get; private set; } = "";

        public void OnGet()
        {
            if (TempData.Peek("username") != null)
            {
                string name = TempData.Peek("username").ToString();
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                Status = 1;
                Output += name + " felhasználó egyenlege: " + refer.DetailsAsync(name).Result + " Ft";
            }
            else
            {
                Status = 0;
                Output += "Még nem regisztráltál!";
            }
        }
    }
}
