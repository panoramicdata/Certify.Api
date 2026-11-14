using AwesomeAssertions;
using Certify.Api.Extensions;
using Certify.Api.Interfaces;
using Certify.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test;

public class GetAllUsersAndGldsExtensionsTests
{
	private sealed class RecordingUsers : IUsers
	{
		public List<string?> Usernames { get; } = new();
		public List<uint?> Active { get; } = new();
		public List<string?> Roles { get; } = new();
		public Func<uint?, Task<UserPage>> PageFactory { get; set; } = _ => Task.FromResult(EmptyPage());

		public Task<UserPage> GetPageAsync(string? username, uint? active, string? role, uint? page, CancellationToken cancellationToken = default)
		{
			Usernames.Add(username);
			Active.Add(active);
			Roles.Add(role);
			return PageFactory(page);
		}

		public Task<UserPage> GetAsync(Guid id, CancellationToken cancellationToken = default)
			=> Task.FromResult(EmptyPage());
	}

	private static UserPage EmptyPage()
	{
		var page = new UserPage();
		page.TotalPageCount = 1;
		page.TotalRecordCount = 0;
		return page;
	}

	private static UserPage Page(uint totalPageCount, uint totalRecordCount, params User[] items)
	{
		var page = new UserPage { Users = items.ToList() };
		page.TotalPageCount = totalPageCount;
		page.TotalRecordCount = totalRecordCount;
		return page;
	}

	[Fact]
	public async Task Users_GetAll_UsesEmptyFilterWhenNoneGiven()
	{
		var users = new RecordingUsers
		{
			PageFactory = _ => Task.FromResult(Page(1, 1, new User { Id = Guid.NewGuid() }))
		};

		var result = await users.GetAllAsync(CancellationToken.None);

		result.Should().HaveCount(1);
		users.Usernames.Should().ContainSingle().Which.Should().BeNull();
		users.Active.Should().ContainSingle().Which.Should().BeNull();
		users.Roles.Should().ContainSingle().Which.Should().BeNull();
	}

	[Fact]
	public async Task Users_GetAllWithFilter_ForwardsFilterValues()
	{
		var users = new RecordingUsers
		{
			PageFactory = _ => Task.FromResult(Page(1, 1, new User { Id = Guid.NewGuid() }))
		};

		var filter = new UserFilter { Username = "alice", Active = 1, Role = "Managers" };

		await users.GetAllAsync(filter, CancellationToken.None);

		users.Usernames.Should().ContainSingle().Which.Should().Be("alice");
		users.Active.Should().ContainSingle().Which.Should().Be(1);
		users.Roles.Should().ContainSingle().Which.Should().Be("Managers");
	}

	private static ExpenseReportGldPage EmptyGldPage()
	{
		var page = new ExpenseReportGldPage();
		page.TotalPageCount = 1;
		page.TotalRecordCount = 0;
		return page;
	}

	private sealed class RecordingGlds : IExpenseReportGlds
	{
		public List<string?> Names { get; } = new();
		public List<string?> Codes { get; } = new();
		public List<uint?> Active { get; } = new();
		public Func<uint, Task<ExpenseReportGldPage>> PageFactory { get; set; } = _ => Task.FromResult(EmptyGldPage());

		public Task<ExpenseReportGldPage> GetPageAsync(uint index, string? name, string? code, uint? active, uint page = 1, CancellationToken cancellationToken = default)
		{
			Names.Add(name);
			Codes.Add(code);
			Active.Add(active);
			return PageFactory(index);
		}

		public Task<List<UpdateResult>> UpdateAsync(uint index, ExpenseReportGld expenseReportGld, CancellationToken cancellationToken = default)
			=> Task.FromResult(new List<UpdateResult>());

		public Task<CreateResult> CreateAsync(uint index, ExpenseReportGld expenseReportGld, CancellationToken cancellationToken = default)
			=> Task.FromResult(new CreateResult());

		public Task<ExpenseReportGldPage> GetAsync(uint index, Guid id, CancellationToken cancellationToken = default)
			=> Task.FromResult(EmptyGldPage());
	}

	private static ExpenseReportGldPage Page(uint totalPageCount, uint totalRecordCount, params ExpenseReportGld[] items)
	{
		var page = new ExpenseReportGldPage { ExpenseReportGlds = items.ToList() };
		page.TotalPageCount = totalPageCount;
		page.TotalRecordCount = totalRecordCount;
		return page;
	}

	[Fact]
	public async Task ExpenseReportGlds_GetAllWithoutFilter_ForwardsNullFilterFields()
	{
		var glds = new RecordingGlds
		{
			PageFactory = _ => Task.FromResult(Page(1, 1, new ExpenseReportGld { Id = Guid.NewGuid() }))
		};

		var result = await glds.GetAllAsync(3, CancellationToken.None);

		result.Should().HaveCount(1);
		glds.Names.Should().ContainSingle().Which.Should().BeNull();
		glds.Codes.Should().ContainSingle().Which.Should().BeNull();
		glds.Active.Should().ContainSingle().Which.Should().BeNull();
	}

	[Fact]
	public async Task ExpenseReportGlds_GetAllWithFilter_ForwardsFilterValues()
	{
		var glds = new RecordingGlds
		{
			PageFactory = _ => Task.FromResult(Page(1, 1, new ExpenseReportGld { Id = Guid.NewGuid() }))
		};

		var filter = new ExpenseReportGldFilter { Name = "name", Code = "code", Active = 1 };

		await glds.GetAllAsync(7, filter, CancellationToken.None);

		glds.Names.Should().ContainSingle().Which.Should().Be("name");
		glds.Codes.Should().ContainSingle().Which.Should().Be("code");
		glds.Active.Should().ContainSingle().Which.Should().Be(1);
	}
}
