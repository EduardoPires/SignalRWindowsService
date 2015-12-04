using System.Web.Mvc;

namespace EP.SignalRSelfHost.Client.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}