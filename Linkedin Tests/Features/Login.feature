Feature: Login
User logs in with valid credentials (username, password)
Home page will load after successful login

Background: 
	Given User will be on the login page


@positive
Scenario Outline: Login with Valid Credentials
	
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on login  button
	Then User will be redirected to Homepage
Examples: 
	| UserName    | Password |
	| abc@xyz.com | 12345    |
	| def@xyz.com | 98765    |
@negative
Scenario Outline: Login with InValid Credentials
	
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on login  button
	Then Error message for Password Length should be thrown
Examples: 
	| UserName    | Password |
	| des@dfs.com | 34256    |
	| rfg@eyr.com | 45644    |

@regression
Scenario Outline: Check for Password Hidden Display
	When User will enter password '<Password>'
	And  User will click on show button in the password text box
	Then The password characters should be shown
Examples:
	| Password |
	| 6653     |

@regression
Scenario: Check for Password Show Display
	When User will enter password '<Password>'
	And  User will click on show button in the password text box
	And  User will click on hide button in the password text box
	Then The password characters should not be shown
Examples: 
	| Password |
	| 6653     |