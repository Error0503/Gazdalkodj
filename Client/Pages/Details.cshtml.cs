using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class DetailsModel : PageModel
    {

        public string Output { get; private set; } = "";

        public void OnGet()
        {
            if (TempData.Peek("username") != null)
            {
                string name = TempData.Peek("username").ToString();
                Reference refer = new Reference("http://localhost:5000/", new System.Net.Http.HttpClient());
                Output += "<p>" + name + " felhasználó egyenlege: " + refer.DetailsAsync(name).Result + " Ft</p>";
            }
            else
            {
                Output += "<p color=\"red\">Még nem regisztráltál!</p>";
            }
        }
    }
}
