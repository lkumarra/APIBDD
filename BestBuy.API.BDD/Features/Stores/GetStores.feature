@Stores
Feature: GetStores
	In Order to get stores
	I want to told to verify stores
	API :- GET /stores

@GetStores
Scenario: Get All Stores
	Given I am a valid user
	When I get all stores
	Then Stores list returned with status code '200'
	And Verify the stores list from Db