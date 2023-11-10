using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //this is called automatically when there is a get request
        }

        public void OnPost()
        {
            //will be automatically called when there is a post request
            //want to add Name to the list
            GuestList.AddName(Name);
            Name = null;
        }

        [BindProperty]
        public string Name { get; set; }

        public IEnumerable<string> AllNames => GuestList.Names;
    }
}