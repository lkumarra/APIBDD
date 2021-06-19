@Categories @PostCategories
Feature: Post Categories
	In Order to create categories
	I want to told to verify post categories
	API :- POST /categories

@PostCategories @PositiveScenario
Scenario: Create a category
	Given I am a valid user
	When I create a category with id as 'AddedCategoriesId' and name as 'AddedCategoryName'
	Then Categories should be created with status code '201'
	And Verify Category created in DB.

@PostCategories @NegativeScenario
Scenario Outline: Create a category with Invalid data.
	Given I am a valid user
	When I try to create a category with id as '<Id>'and name as '<Name>'
	Then Categories should not be created with name as '<errorName>',message as '<message>', status code '400' and errors as '<errors>'

	Examples:
		| Scenario                                    | Id      | Name      | errorName  | message            | errors                                         |
		| Try to create a category with Id as null    | NULL    | AddedName | BadRequest | Invalid Parameters | 'id' should be string                          |
		| Try to create a category with Id as Empty   | EMPTY   | AddedName | BadRequest | Invalid Parameters | 'id' should NOT be shorter than 1 characters   |
		| Try to create a category with name as null  | AddedId | NULL      | BadRequest | Invalid Parameters | 'name' should be string                        |
		| Try to create a category with name as Empty | AddedId | EMPTY     | BadRequest | Invalid Parameters | 'name' should NOT be shorter than 1 characters |