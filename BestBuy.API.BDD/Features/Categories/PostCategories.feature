@Categories @PostCategories
Feature: Post Categories
	In Order to create categories
	I want to told to verify post categories
	API :- POST /categories

@PostCategories @PositiveScenario
Scenario: Create a category
	Given I am a valid user
	When I create a category with id as 'AddedCategoriesId' and name as 'AddedCategoryName'
	Then Categories shoould be created with status code '201'
	And Verify Category created in DB.

@PostCategories @NegativeScenario
Scenario Outline: Create a category with Invalid data.
	Given I am a valid user
	When I try to create a category with id as '<Id>'and name as '<Name>'
	Then Categories shoould not be created with status code '400'

	Examples:
		| Scenario                                    | Id      | Name      |
		| Try to create a category with Id as null    | NULL    | AddedName |
		| Try to create a category with Id as Empty   | EMPTY   | AddedName |
		| Try to create a category with name as null  | AddedId | NULL      |
		| Try to create a category with name as Empty | AddedId | EMPTY     |