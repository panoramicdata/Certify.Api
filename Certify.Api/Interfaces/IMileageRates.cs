﻿using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IMileageRates
	{
		[Post("/mileagerates")]
		Task PostAsync([Body] MileageRate cpd);

		[Get("/mileagerates/{id}")]
		Task<MileageRate> GetAsync(int id);

		[Get("/mileagerates")]
		Task<MileageRateContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/mileagerates")]
		Task PutAsync([Body] MileageRate cpd);

		[Delete("/mileagerates/{id}")]
		Task DeleteAsync(int id);
	}
}
