# Certify.Api

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/b1d2fb8f83c14a5695c002c45ed4fa42)](https://app.codacy.com/gh/panoramicdata/Certify.Api/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![NuGet](https://img.shields.io/nuget/v/Certify.Api.svg)](https://www.nuget.org/packages/Certify.Api/)
[![NuGet](https://img.shields.io/nuget/dt/Certify.Api.svg)](https://www.nuget.org/packages/Certify.Api/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A .NET Standard 2.0 client library for the [Certify](https://www.certify.com/) Expense Management API.

## Features

- Full support for Certify REST API v1
- Strongly-typed models with XML documentation
- Async/await support with cancellation tokens
- Built on [Refit](https://github.com/reactiveui/refit) for easy maintenance
- .NET Standard 2.0 compatible (works with .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+)
- Symbol packages (`.snupkg`) for source-level debugging

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

You can customize the client behavior using `CertifyClientOptions`:

```csharp
var options = new CertifyClientOptions
{
    Timeout = TimeSpan.FromSeconds(60) // Default is 120 seconds
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
```

### Error Handling

```csharp
try
{
    var users = await client.Users.GetPageAsync(cancellationToken: cancellationToken);
}
catch (Refit.ApiException ex)
{
    // Handle API errors
    Console.WriteLine($"API Error: {ex.StatusCode} - {ex.Content}");
}
catch (TaskCanceledException)
{
    // Handle timeout or cancellation
    Console.WriteLine("Request timed out or was cancelled");
}
```

## API Documentation

For detailed information about the Certify API endpoints and parameters, refer to the official [Certify API Documentation](https://api.certify.com/).

## Requirements

- .NET Standard 2.0 or higher
- .NET Framework 4.6.1 or higher
- .NET Core 2.0 or higher
- .NET 5, 6, 7, 8, 9, 10+

## Dependencies

- [Refit](https://www.nuget.org/packages/Refit/) - HTTP client library
- [Nerdbank.GitVersioning](https://www.nuget.org/packages/Nerdbank.GitVersioning/) - Automatic version management

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Authors

- **David Bond** - [Panoramic Data Limited](https://github.com/panoramicdata)
- **Daniel Abbatt** - [Panoramic Data Limited](https://github.com/panoramicdata)

## Support

For issues, questions, or suggestions, please [open an issue](https://github.com/panoramicdata/Certify.Api/issues) on GitHub.

---

Copyright © 2019-2025 Panoramic Data Limited
