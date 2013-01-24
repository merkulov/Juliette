Feature: HightestInterest

@mytag
Scenario: Hightest Interest
	Given Purchase Price is $ 200,000
	And Downpayment is 20
	And Mortgage term is 30 years
	And Interest rate is 100 %
	And Property tax is 0 %
	And Property insurance is $ 0
	And First payment date is Jan,2012
	And Amortization period is Year
	When I press calculate
	Then Total monthly payment is $ 13,334.06
	And Total payment is $ 1600,008.67
	And Payoff date is Dec,2013