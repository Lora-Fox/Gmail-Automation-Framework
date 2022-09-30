Feature: Gmail

@mytag
Scenario: Gmail Login
	Given Gmail application is installed on device	
	When the user enters valid email and password 
	Then the user is logged in to account

	Scenario: Send email
	Given the user is logged in Gmail	
	When the user composes and sends the email
	Then email is sent 