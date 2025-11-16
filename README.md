# Certify.Api

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/b1d2fb8f83c14a5695c002c45ed4fa42)](https://app.codacy.com/gh/panoramicdata/Certify.Api/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![NuGet](https://img.shields.io/nuget/v/Certify.Api.svg)](https://www.nuget.org/packages/Certify.Api/)
[![NuGet](https://img.shields.io/nuget/dt/Certify.Api.svg)](https://www.nuget.org/packages/Certify.Api/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A modern .NET client library for the [Certify](https://www.certify.com/) Expense Management API, built with .NET 10 and C# 14.

## Features

- ?? **Full .NET 10 Support** - Built with the latest .NET features and C# 14 syntax
- ?? **Complete API Coverage** - Full support for Certify REST API v1
- ?? **Strongly-Typed** - All models include comprehensive XML documentation
- ? **Async/Await** - Modern async patterns with `CancellationToken` support
- ?? **Built on Refit** - Leveraging [Refit](https://github.com/reactiveui/refit) for maintainable HTTP clients
- ?? **Debugging Support** - Symbol packages (`.snupkg`) included for source-level debugging
- ?? **Structured Logging** - Integrated `Microsoft.Extensions.Logging` support
- ?? **Nullable Reference Types** - Full nullable annotations for better null-safety

## Installation

Install via NuGet Package Manager:

```powershell
Install-Package Certify.Api
```

Or via .NET CLI:

```bash
dotnet add package Certify.Api
```

## Quick Start

```csharp
using Certify.Api;

// Initialize the client with your API credentials
using var client = new CertifyClient(
    apiKey: "your-api-key",
    apiSecret: "your-api-secret"
);

// Get a page of users
var users = await client.Users.GetPageAsync(cancellationToken: cancellationToken);

// Get all expense reports
var expenseReports = await client.ExpenseReports.GetAllAsync(cancellationToken: cancellationToken);

// Get a specific department by ID
var department = await client.Departments.GetAsync(departmentId, cancellationToken: cancellationToken);
```

## Configuration Options

Customize the client behavior using `CertifyClientOptions`:

```csharp
using Microsoft.Extensions.Logging;

var options = new CertifyClientOptions
{
    Timeout = TimeSpan.FromSeconds(60), // Default is 120 seconds
    Logger = loggerInstance // Optional: add structured logging
};

using var client = new CertifyClient(apiKey, apiSecret, options);
```

### Logging Support

The library supports `Microsoft.Extensions.Logging` for detailed request/response logging:

```csharp
using Microsoft.Extensions.Logging;

// Create a logger factory
using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddConsole()
        .SetMinimumLevel(LogLevel.Debug);
});

var logger = loggerFactory.CreateLogger<CertifyClient>();

var options = new CertifyClientOptions
{
    Logger = logger
};

using var client = new CertifyClient(apiKey, apiSecret, options);
```

## Supported Endpoints

The library provides full support for all Certify API endpoints:

| Endpoint | Interface | Description |
|----------|-----------|-------------|
| **Users** | `IUsers` | Manage user accounts and profiles |
| **Departments** | `IDepartments` | Manage departments and organizational structure |
| **Expense Reports** | `IExpenseReports` | Access and manage expense reports |
| **Expenses** | `IExpenses` | Individual expense line items |
| **Expense Categories** | `IExpenseCategories` | Expense category definitions |
| **Employee GLDs** | `IEmpGlds` | Employee general ledger dimensions |
| **Expense Report GLDs** | `IExpenseReportGlds` | Expense report general ledger dimensions |
| **Receipts** | `IReceipts` | Receipt images and attachments |
| **Invoices** | `IInvoices` | Invoice management |
| **Invoice Reports** | `IInvoiceReports` | Invoice report data |
| **Mileage Rates** | `IMileageRates` | Mileage rate configurations |
| **Mileage Rate Details** | `IMileageRateDetails` | Detailed mileage rate information |
| **CPD Lists** | `ICpdLists` | Continuing Professional Development lists |

## Advanced Usage

### Pagination

Get all items across multiple pages:

```csharp
// Extension method automatically handles pagination
var allUsers = await client.Users.GetAllAsync(cancellationToken: cancellationToken);

// Or manually page through results
uint pageNumber = 1;
var page = await client.Users.GetPageAsync(page: pageNumber, cancellationToken: cancellationToken);

Console.WriteLine($"Page {page.PageNumber} of {page.TotalPageCount}");
Console.WriteLine($"Total records: {page.TotalRecordCount}");
```

### Filtering

Most endpoints support filtering parameters:

```csharp
// Get active users only
var activeUsers = await client.Users.GetPageAsync(
    active: 1,
    cancellationToken: cancellationToken
);

// Get expense reports by date range
var reports = await client.ExpenseReports.GetPageAsync(
    startDate: "2024-01-01",
    endDate: "2024-12-31",
    processed: 1,
    cancellationToken: cancellationToken
);

// Get departments by code
var departments = await client.Departments.GetPageAsync(
    code: "DEPT001",
    cancellationToken: cancellationToken
);
```

### Creating and Updating Resources

```csharp
// Create a new department
var newDepartment = new Department
{
    Name = "Engineering",
    Code = "ENG",
    Description = "Engineering Department"
};

var createResult = await client.Departments.CreateAsync(
    newDepartment,
    cancellationToken: cancellationToken
);

Console.WriteLine($"Created department with ID: {createResult.Id}");

// Update an existing department
var department = new Department
{
    Id = existingDepartmentId,
    Name = "Updated Name"
};

var updateResults = await client.Departments.UpdateAsync(
    department,
    cancellationToken: cancellationToken
);

foreach (var result in updateResults)
{
    Console.WriteLine($"Status: {result.Status}, Message: {result.Message}");
}
```

### Error Handling

```csharp
using Refit;

try
{
    var users = await client.Users.GetPageAsync(cancellationToken: cancellationToken);
}
catch (ApiException ex)
{
    // Handle API errors
    Console.WriteLine($"API Error: {ex.StatusCode} - {ex.Content}");
}
catch (TaskCanceledException)
{
    // Handle timeout or cancellation
    Console.WriteLine("Request timed out or was cancelled");
}
catch (Exception ex)
{
    // Handle other errors
    Console.WriteLine($"Error: {ex.Message}");
}
```

### Using with Dependency Injection

```csharp
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register as singleton or scoped based on your needs
services.AddSingleton<CertifyClient>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<CertifyClient>>();
    var options = new CertifyClientOptions
    {
        Timeout = TimeSpan.FromSeconds(120),
        Logger = logger
    };
    
    return new CertifyClient(
        apiKey: "your-api-key",
        apiSecret: "your-api-secret",
        options: options
    );
});

var serviceProvider = services.BuildServiceProvider();
var certifyClient = serviceProvider.GetRequiredService<CertifyClient>();
```

## API Documentation

For detailed information about the Certify API endpoints and parameters, refer to the official [Certify API Documentation](https://api.certify.com/).

## Requirements

- .NET 10 or higher (recommended)
- .NET 5+ (compatible via .NET Standard 2.0)
- .NET Core 2.0+ (compatible via .NET Standard 2.0)
- .NET Framework 4.6.1+ (compatible via .NET Standard 2.0)

## Dependencies

- [Refit 8.0.0](https://www.nuget.org/packages/Refit/) - The automatic type-safe REST library
- [Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions/) - Logging abstractions
- [Nerdbank.GitVersioning](https://www.nuget.org/packages/Nerdbank.GitVersioning/) - Automatic version management from Git

## Building from Source

```bash
# Clone the repository
git clone https://github.com/panoramicdata/Certify.Api.git
cd Certify.Api

# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run tests (requires appsettings.json with valid credentials)
dotnet test
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## Testing

The test suite uses xUnit and requires valid Certify API credentials. Create an `appsettings.json` file in the test project:

```json
{
  "Config": {
    "Credentials": {
      "ApiKey": "your-api-key",
      "ApiSecret": "your-api-secret"
    }
  }
}
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Authors

- **David Bond** - [Panoramic Data Limited](https://github.com/panoramicdata)
- **Daniel Abbatt** - [Panoramic Data Limited](https://github.com/panoramicdata)

## Support

For issues, questions, or suggestions, please [open an issue](https://github.com/panoramicdata/Certify.Api/issues) on GitHub.

## Acknowledgments

- Built with [Refit](https://github.com/reactiveui/refit)
- Uses [Microsoft.Extensions.Logging](https://docs.microsoft.com/en-us/dotnet/core/extensions/logging)
- Versioned with [Nerdbank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning)

---

Copyright © 2019-2025 Panoramic Data Limited
