using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InfoJobsPoc.Client.Pages
{
    public class CandidatePageModel : PageModel
    {
        private readonly ILogger<CandidatePageModel> _logger;

        public CandidatePageModel(ILogger<CandidatePageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}