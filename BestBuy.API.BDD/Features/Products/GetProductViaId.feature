@Products
Feature: Get Product via Id
	In Order to get products via Id
	I want to told to verify products
	API :- GET /products/{id}

@GetProducts
Scenario: Get product via Id
	Given I am a valid user
	When I get 'Duracell' product
	Then Product should be returned with status code '200'
	And Verify the product from Db