# Coding-Challenge

**Version 1.0.0** 

A framework designed to automate the following scenarios for reqres API; 

1.	Verify that a POST request can be posted to the API to create the single user and assert that the single user is created. 
2.	Verify that a GET request can be posted to the API to get the expected details of single user
3.	Verify that a GET request can be posted to the API to get the expected details of the list of users
4.	Verify that a PUT request can be posted to the API to update the single user and assert that the expected update was made. 
5.	Verify that a GET request can be posted to the API to return a single user not found, which should return a “404” response. 

This framework was built using Visual Studio (VS) 2019, please ensure you download and run the framework using VS 2019, this framework may not be compatible with 
older versions of VS.

All pre-requisites and dependencies are encapsulated within the file package, framework should work out the box though a rebuild is strongly recommended before running.

Please note the following status code equivalents have been used to verify each scenario;

'Created' = 201  
'OK' = 200
'NotFound' = 404 

HttpClient returns and represents the abovementioned phrases as success status code.
