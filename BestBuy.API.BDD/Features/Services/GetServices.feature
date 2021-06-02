@Services
Feature: GetServices
	In Order to get services
	I want to told to verify services
	API :- GET /services

@GetProducts
Scenario: Get All Services
	Given I am a valid user
	When I get all services
	Then Services list returned with status code '200'
	And Verify the services list from Db