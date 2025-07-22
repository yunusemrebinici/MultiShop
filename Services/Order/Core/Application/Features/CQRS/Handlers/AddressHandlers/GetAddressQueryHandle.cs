﻿using Application.Features.CQRS.Results.AddressResults;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
	public class GetAddressQueryHandle
	{
		private readonly IRepository<Address> _repository;

		public GetAddressQueryHandle(IRepository<Address> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetAddressQueryResult>> Handle()
		{
			var value = await _repository.GetAllAsync();
			return value.Select(x => new GetAddressQueryResult
			{

				AddressId = x.AddressId,
				City = x.City,
				Detail = x.Detail,
				District = x.District,
				UserId = x.UserId,

			}).ToList();
		}
	}
}
