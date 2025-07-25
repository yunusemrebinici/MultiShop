﻿using Application.Features.CQRS.Commands.AddressComands;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
	public class RemoveAddressCommandHandle
	{
		private readonly IRepository<Address> _repository;

		public RemoveAddressCommandHandle(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAddressCommand remove)
		{
			var value = await _repository.GetByIdAsync(remove.AddressId);
     		await _repository.DeleteAsync(value);
		}
	}
}
