using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Gazdalkodj_Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Output { get; private set; } = "Hiba";

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            swaggerClient swClient = new swaggerClient("http://localhost:5000/", new System.Net.Http.HttpClient());
            swClient.CreateAsync("Teszt");
            Output = "Siker!";
            int res = swClient.DetailAsync("Teszt").Result; // TODO: Certificate?
            Output += "Egyenleg: " + res + " huf";
        }

    }
}
