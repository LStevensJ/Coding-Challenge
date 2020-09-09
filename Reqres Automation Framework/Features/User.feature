Feature: User
As a user i would like to
retrieve a list of existing users with GET request
create a new user with POST request
modify and existing user with PUT request


Scenario: User_01_Verify that a POST request can be made to the API to create a user
	Given the reqres service is running and a POST request is made to the '/api/users' endpoint
	Then the status code for the request should be 'Created'


Scenario: User_02_Verify that a GET request can be made to the API to retrieve a single user
	Given the reqres service is running and a GET request is made to the '/api/users/2' endpoint
	Then the status code for the request should be 'OK'
	And the following user should be present:
	| first_name | last_name | email					  |
    | Janet      | Weaver    | janet.weaver@reqres.in     |


Scenario: User_03_Verify that a GET request can be made to the API to retrieve a list of users
	Given the reqres service is running and a GET request is made to the '/api/users?page=1' endpoint 
	Then the status code for the request should be 'OK'
	And the following list of users should be present:
	| first_name | last_name | email					  |
    | George     | Bluth     | george.bluth@reqres.in     |
	| Janet      | Weaver    | janet.weaver@reqres.in     |
	| Emma       | Wong      | emma.wong@reqres.in        |
	| Eve        | Holt      | eve.holt@reqres.in         |
	| Charles    | Morris    | charles.morris@reqres.in   |
	| Tracey     | Ramos     | tracey.ramos@reqres.in     |


Scenario: User_04_Verify that a PUT request can be made to the API to update an existing user
	Given the reqres service is running and a PUT request is made to the '/api/users' endpoint
	Then the status code for the PUT request should be 'OK'


Scenario: User_05_Verify that an invalid GET request made to the API will return 'NotFound' Error
	Given the reqres service is running and a GET request is made to the '/api/unknown/23' endpoint 
	Then the status code for the request should be 'NotFound'