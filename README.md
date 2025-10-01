# BestBuy API BDD Testing Framework

This project is an automated testing framework for BestBuy API endpoints using Behavior Driven Development (BDD) approach with SpecFlow and C#.

## Project Overview

The framework is designed to test various API endpoints of BestBuy, including:
- Products
- Categories
- Services
- Stores

## Technology Stack

- **Language:** C# (.NET Framework 4.8)
- **BDD Framework:** SpecFlow
- **Testing Approach:** API Testing
- **Project Type:** Class Library

## Project Structure

```
BestBuy.API.BDD/
├── API/                    # API implementation classes
│   ├── Categories/        # Category-related API calls
│   ├── Products/          # Product-related API calls
│   ├── Services/          # Service-related API calls
│   └── Stores/           # Store-related API calls
├── Features/              # SpecFlow feature files
├── Helpers/              # Helper classes and utilities
├── Modals/               # Response models
└── Steps/                # Step definitions
```

## Features

The framework supports testing of the following API operations:

### Products
- Get all products
- Get product by ID
- Create new product
- Update existing product
- Delete product

### Categories
- Get all categories
- Get category by ID
- Create new category

### Services
- Get all services

### Stores
- Get all stores

## Setup Instructions

1. Clone the repository
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Update the `App.config` with your API configuration settings

## Running Tests

### Using Visual Studio Test Explorer
1. Open the solution in Visual Studio
2. Build the solution
3. Open Test Explorer (Test > Test Explorer)
4. Click "Run All" or select specific tests to run

### Using Command Line
```bash
# Navigate to the project directory
cd path/to/BestBuy.API.BDD

# Run all tests
vstest.console.exe bin/Debug/net48/BestBuy.API.BDD.dll

# Run specific feature
vstest.console.exe bin/Debug/net48/BestBuy.API.BDD.dll /Tests:GetProducts
```

### Using SpecFlow+ Runner
1. Install SpecFlow+ Runner
2. Open SpecFlow+ Runner
3. Load the test assembly
4. Execute desired features or scenarios

## Sample Code Examples

### Feature File Example (GetProducts.feature)
```gherkin
Feature: Get Products API
    As a user
    I want to get products information
    So that I can view available products

    Scenario: Get all products
        Given I have access to the BestBuy API
        When I send GET request to products endpoint
        Then the response status code should be 200
        And the response should contain product list
```

### Step Definition Example
```csharp
[Given(@"I have access to the BestBuy API")]
public void GivenIHaveAccessToTheBestBuyAPI()
{
    // Setup code
    _baseAPI = new BaseAPI();
}

[When(@"I send GET request to products endpoint")]
public void WhenISendGETRequestToProductsEndpoint()
{
    _response = _baseAPI.GetProducts();
}

[Then(@"the response status code should be (.*)")]
public void ThenTheResponseStatusCodeShouldBe(int statusCode)
{
    Assert.AreEqual(statusCode, (int)_response.StatusCode);
}
```

### API Call Example
```csharp
public class GetProducts : BaseAPI
{
    public HttpResponseMessage GetAllProducts()
    {
        string endpoint = APIEndPointGenerator.GenerateEndPoint("products");
        return HttpClientHelper.Get(endpoint);
    }
}
```

### Response Model Example
```csharp
public class GetProductsModal
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("price")]
    public decimal Price { get; set; }

    // Other properties...
}
```

## Configuration

The `App.config` file contains essential configuration including:
- API Base URL
- Endpoints
- Other environment-specific settings

## Helper Components

- **APIEndPointGenerator:** Generates API endpoints
- **ConfigHelper:** Manages configuration settings
- **HttpClientHelper:** Handles HTTP requests
- **ResponseValidator:** Validates API responses
- **JSONParser:** Parses JSON responses

## Best Practices

- Feature files are organized by domain (Products, Categories, etc.)
- Each API operation has its dedicated test class
- Common steps are maintained in `CommanSteps.cs`
- Response validation is standardized using `IResponseValidator` interface

## Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a new Pull Request

## Project Maintenance

Regular maintenance tasks include:
- Updating dependencies
- Adding new test scenarios
- Maintaining test data
- Reviewing and updating test assertions

## License

[Specify your license here]