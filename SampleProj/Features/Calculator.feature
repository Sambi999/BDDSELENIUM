Feature: Calculator


@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the sum should be 120

Scenario: Subtract two numbers
	Given the first number is 100
	And the second number is 70
	When the second number is subtracted from the first number
	Then the difference should be 30