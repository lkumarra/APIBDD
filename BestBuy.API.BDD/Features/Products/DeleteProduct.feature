@Products @DeleteProducts
Feature: Delete Product
	In Order to delete products
	I want to told to verify delete products
	API :- Delete /products/{id}

@GetProducts
Scenario: Delete product via Id.
	Given I am a valid user
	When I delete 'DeletedProductTest'  product
	Then Product should be deleted with status code '200'
	And Verify product deleted from DB.