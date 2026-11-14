using AwesomeAssertions;
using Certify.Api.Models;
using Xunit;

namespace Certify.Api.Test;

public class PagedModelTests
{
	[Fact]
	public void CpdListPage_NewInstance_HasEmptyCpdLists()
		=> new CpdListPage().CpdLists.Should().BeEmpty();

	[Fact]
	public void DepartmentPage_NewInstance_HasEmptyDepartments()
		=> new DepartmentPage().Departments.Should().BeEmpty();

	[Fact]
	public void EmpGldPage_NewInstance_HasEmptyEmployeeGlds()
		=> new EmpGldPage().EmployeeGlds.Should().BeEmpty();

	[Fact]
	public void ExpenseCategoryPage_NewInstance_HasEmptyExpenseCategories()
		=> new ExpenseCategoryPage().ExpenseCategories.Should().BeEmpty();

	[Fact]
	public void ExpensePage_NewInstance_HasEmptyExpenses()
		=> new ExpensePage().Expenses.Should().BeEmpty();

	[Fact]
	public void ExpenseReportGldPage_NewInstance_HasEmptyExpenseReportGlds()
		=> new ExpenseReportGldPage().ExpenseReportGlds.Should().BeEmpty();
}
