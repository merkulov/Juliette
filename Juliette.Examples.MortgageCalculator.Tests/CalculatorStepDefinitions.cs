using Juliette.Examples.MortgageCalculator.Controllers;
using Juliette.Examples.MortgageCalculator.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace Juliette.Examples.MortgageCalculator.Tests
{
    [Binding]
    public class StepDefinitions
    {
        public class MyDynamicObject : DynamicObject
        {
            Dictionary<string, object> dictionary  = new Dictionary<string, object>();

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                string name = binder.Name;
                return dictionary.TryGetValue(name, out result);
            }

            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                dictionary[binder.Name] = value;
                return true;
            }
        }

        private dynamic initData = new MyDynamicObject();
        private List<Option> result;

        private HomeController controller = new HomeController();


        [Given(@"Purchase Price is \$ (.*)")]
        public void GivenPurchasePriceIs(Decimal p0)
        {
            initData.Price = p0;
        }

        [Given(@"Downpayment is (.*)")]
        public void GivenDownpaymentIs(int p0)
        {
            initData.Downpayment = p0;
        }

        [Given(@"Mortgage term is (.*) years")]
        public void GivenMortgageTermIsYears(int p0)
        {
            initData.MortgageTerm = p0;

        }

        [Given(@"Interest rate is (.*) %")]
        public void GivenInterestRateIs(Decimal p0)
        {
            initData.InterestRate = p0;
        }

        [Given(@"Property tax is (.*) %")]
        public void GivenPropertyTaxIs(int p0)
        {
            initData.PropertyTax = p0;
        }

        [Given(@"Property insurance is \$ (.*)")]
        public void GivenPropertyInsuranceIs(int p0)
        {
            initData.PropertyInsurance = p0;
        }

        [Given(@"First payment date is (.*)")]
        public void GivenFirstPaymentDateIsJan(string p0)
        {
            initData.FirstPaymentDate = p0;
        }

        [Given(@"Amortization period is Year")]
        public void GivenAmortizationPeriodIsYear()
        {
            //TODO: implement
        }

        [When(@"I press calculate")]
        public void WhenIPressCalculate()
        {
            ViewResult viewResult = controller.Calculate(initData.Price, initData.MortgageTerm * 12, initData.Downpayment);
            result = (List<Option>)viewResult.Model;

        }

        [Then(@"Total monthly payment is \$ (.*)")]
        public void ThenTotalMonthlyPaymentIs_(string p0)
        {
            Assert.AreEqual(result[0].MonthlyPayment, decimal.Parse(p0));

        }

        [Then(@"Total payment is \$ (.*)")]
        public void ThenTotalPaymentIs_(string p0)
        {
            Assert.AreEqual(result[0].TotalPayment, decimal.Parse(p0));
        }

        [Then(@"Payoff date is (.*)")]
        public void ThenPayoffDateIsDec(string p0)
        {
            //TODO: implement
        }
    }
}