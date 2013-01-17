using System.Collections.Generic;
using System.Web.Mvc;
using Juliette.Examples.MortgageCalculator.Models;

namespace Juliette.Examples.MortgageCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Calculate(decimal propertyCost, int numberOfMonths, decimal downPayment)
		{
			//calculations are wrong but whatever
			var model = new List<Option>();

			decimal interestYearlyRate = 0.03m;

			var interestMonthlyRate = interestYearlyRate / 12; // that's just wrong, but whatever

			decimal loanAmount = propertyCost - downPayment;

			decimal totalPayment = (loanAmount / numberOfMonths) * ((1 + interestMonthlyRate) * numberOfMonths);
			decimal monthlyPayment = totalPayment / numberOfMonths;

			model.Add(new Option
				{
				OrdinalNumber = 1,
				MonthlyPayment = monthlyPayment,
				NumberOfMonths = numberOfMonths,
				TotalPayment = totalPayment,
				Interest = totalPayment + downPayment - propertyCost
			});

			return View("Options", model);
		}
    }
}
