# Certify.Api

A .NET NuGet package for the [Certify](https://www.certify.com/) expense management API.

[![Nuget](https://img.shields.io/nuget/v/Certify.Api)](https://www.nuget.org/packages/Certify.Api/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Quick Start

Install via NuGet:

```powershell
Install-Package Certify.Api
```

Create a client and make API calls:

```csharp
using Certify.Api;

using var client = new CertifyClient("your-api-key", "your-api-secret");

var departments = await client.Departments.GetPageAsync();
```

## Supported Resources

- Departments
- Expense Categories
- Expense Reports
- Expenses
- Expense Report GLDs
- Invoice Reports
- Invoices
- Mileage Rates
- Mileage Rate Details
- Receipts
- Users
- CPD Lists
- Employee GLDs

## Requirements

- .NET 10.0 or later

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

© Panoramic Data Limited
