using Microsoft.AspNetCore.Mvc;

namespace InfoJobs.KnowledgeTest.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public RedirectToActionResult Index()
        {
            return RedirectToAction("Index", "Candidate", new { area = "Curriculum" });
        }
    }
}