@Categories
Feature: Get Categories Via ID
	In Order to get products
	I want to told to verify get categories via Id
	API :- GET /categories/{id}

@GetCategories
Scenario: Get category via Id
	Given I am a valid user
	When I get category with id a 'DVD_Games'
	Then Categories should be returned with status code '200'
	And Verify the category from Db