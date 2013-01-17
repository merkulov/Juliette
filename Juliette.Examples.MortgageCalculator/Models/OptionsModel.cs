using System.Collections.Generic;

namespace Juliette.Examples.MortgageCalculator.Models
{
	public class OptionsModel
	{
		public OptionsModel()
		{
			Options = new List<Option>();
		}

		public List<Option> Options { get; private set; }
	}
	
	public class Option
	{
		public int OrdinalNumber { get; set; }
		public int NumberOfMonths { get; set; }
		public decimal TotalPayment { get; set; }
		public decimal MonthlyPayment { get; set; }
		public decimal Interest { get; set; }
	}
}