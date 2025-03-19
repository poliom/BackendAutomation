Feature: Stock

A short summary of the feature

@tag1
Scenario: Calculate time for investment with 200 per month until 1000 return
	Given get stock price and last divident price for nVidia
	When calculate the time for return investment of 1000 for 200 per month
	Then the needed time is 2 years and 0 months
