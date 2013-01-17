using System.Web.Mvc;

namespace Juliette.Examples.MortgageCalculator.Controllers.Juliette
{
    public class JulietteController : Controller
    {
        //
        // GET: /Juliette/

        public ActionResult Index()
        {
            return View();
        }

	    public ActionResult Run()
	    {
		    return View("Status");
	    }
    }
}
