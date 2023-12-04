Feature: Search



@Product-Search
Scenario Outline: Search for Products
	Given User will be on the home page
	When User will type the '<searchtext>' in the search box
	Then Search results are loaded in the same page with '<searchtext>'
Examples: 
	| searchtext |
	| water      |
	| java       |
	| hairgrass  |
