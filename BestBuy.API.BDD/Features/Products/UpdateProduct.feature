@Products @PatchProducts
Feature: Update Products
	In Order to post products
	I want to told to verify products
	API :- PATCH /products/{id}

@GetProducts @PositiveScenatio
Scenario: Update a product
	Given I am a valid user
	When I update a product with prductId as 'AddedProduct', name as 'UpdatedProduct', type as 'UpdatedType', price as '10000', shipping as '200', upc as 'UpdatedUPC',description as 'UpdatedDescription',manufacturer as 'UpdatedManufacturer', model as 'UpdatedModel',url as 'UpdatedUrl' image as 'UpdatedImage'
	Then Products should be updated with status code '200'
	And Verify product updated in Db.

@GetProducts @NegativeScenario
Scenario Outline: Update a product with invalid data
	Given I am a valid user
	When I try to update a product with prductId as '<ProductId>', name as '<Name>', type as '<type>', price as '<price>', shipping as '<shipping>', upc as '<upc>',description as '<description>',manufacturer as '<manufacturer>', model as '<model>', url as '<url>' image as '<image>'
	Then Products should not be updated with name as '<errorName>',message as '<message>', status code '<statuscode>' and errors as '<errors>'

	Examples:
		| Scenario                                         | ProductId    | Name        | type        | price | shipping | upc       | description      | manufacturer      | model      | url      | image      | statuscode | errorName  | message                    | errors                                                 |
		| Try to update product with productId as Invalid  | Invalid      | UpdatedName | UpdatedType | 1     | 1        | AddedUpc1 | AddedDescription | AddedManufacturer | AddedModel | AddedUrl | AddedImage | 404        | NotFound   | No record found for id '0' |                                                        |
		| Try to create product with name as null          | AddedProduct | NULL        | UpdatedType | 1     | 1        | AddedUpc1 | AddedDescription | AddedManufacturer | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'name' should be string                                |
		| Try to create product with name as null          | AddedProduct | EMPTY       | UpdatedType | 2     | 2        | AddedUpc1 | AddedDescription | AddedManufacturer | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'name' should NOT be shorter than 1 characters         |
		| Try to create product with type as null          | AddedProduct | UpdatedName | NULL        | 4     | 4        | AddedUpc1 | AddedDescription | AddedManufacturer | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'type' should be string                                |
		| Try to create product with type as empty         | AddedProduct | UpdatedName | EMPTY       | 5     | 5        | AddedUpc1 | AddedDescription | AddedManufacturer | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'type' should NOT be shorter than 1 characters         |
		| Try to create product with upc as null           | AddedProduct | UpdatedName | UpdatedType | 13    | 13       | NULL      | AddedDescription | AddedManufacturer | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'upc' should be string                                 |
		| Try to create product with upc as empty          | AddedProduct | UpdatedName | UpdatedType | 14    | 14       | EMPTY     | AddedDescription | AddedManufacturer | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'upc' should NOT be shorter than 1 characters          |
		| Try to create product with description as null   | AddedProduct | UpdatedName | UpdatedType | 16    | 16       | AddedUpc1 | NULL             | AddedManufacturer | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'description' should be string                         |
		| Try to create product with description as empty  | AddedProduct | UpdatedName | UpdatedType | 17    | 17       | AddedUpc1 | EMPTY            | AddedManufacturer | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'description' should NOT be shorter than 1 characters  |
		| Try to create product with manufacturer as null  | AddedProduct | UpdatedName | UpdatedType | 19    | 19       | AddedUpc1 | AddedDescription | NULL              | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'manufacturer' should be string                        |
		| Try to create product with manufacturer as empty | AddedProduct | UpdatedName | UpdatedType | 20    | 20       | AddedUpc1 | AddedDescription | EMPTY             | AddedModel | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'manufacturer' should NOT be shorter than 1 characters |
		| Try to create product with model as null         | AddedProduct | UpdatedName | UpdatedType | 22    | 22       | AddedUpc1 | AddedDescription | AddedManufacturer | NULL       | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'model' should be string                               |
		| Try to create product with model as empty        | AddedProduct | UpdatedName | UpdatedType | 23    | 23       | AddedUpc1 | AddedDescription | AddedManufacturer | EMPTY      | AddedUrl | AddedImage | 400        | BadRequest | Invalid Parameters         | 'model' should NOT be shorter than 1 characters        |
		| Try to create product with url as null           | AddedProduct | UpdatedName | UpdatedType | 25    | 25       | AddedUpc1 | AddedDescription | AddedManufacturer | AddedModel | NULL     | AddedImage | 400        | BadRequest | Invalid Parameters         | 'url' should be string                                 |
		| Try to create product with url as empty          | AddedProduct | UpdatedName | UpdatedType | 26    | 26       | AddedUpc1 | AddedDescription | AddedManufacturer | AddedModel | EMPTY    | AddedImage | 400        | BadRequest | Invalid Parameters         | 'url' should NOT be shorter than 1 characters          |
		| Try to create product with image as null         | AddedProduct | UpdatedName | UpdatedType | 28    | 28       | AddedUpc1 | AddedDescription | AddedManufacturer | AddedModel | AddedUrl | NULL       | 400        | BadRequest | Invalid Parameters         | 'image' should be string                               |
		| Try to create product with image as empty        | AddedProduct | UpdatedName | UpdatedType | 29    | 29       | AddedUpc1 | AddedDescription | AddedManufacturer | AddedModel | AddedUrl | EMPTY      | 400        | BadRequest | Invalid Parameters         | 'image' should NOT be shorter than 1 characters        |