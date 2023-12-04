Feature: Search

@Product_Search
Scenario Outline: Search for Products

	Given 
	When User will type the '<searchtext>' in the search box
	Then Search results are loaded in the same page with '<searchtext>'
Examples: 
	| searchtext |
	| water      |
	| java       |
	| hairgrass  |
