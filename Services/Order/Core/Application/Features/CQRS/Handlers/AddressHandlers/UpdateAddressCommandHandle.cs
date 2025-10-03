using Application.Features.CQRS.Commands.AddressComands;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
	public class UpdateAddressCommandHandle
	{
		private readonly IRepository<Address> _repository;

		public UpdateAddressCommandHandle(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAddressCommand update)
		{
			var value= await _repository.GetByIdAsync(update.AddressId);
			value.Detail = update.Detail;
			value.District = update.District;
			value.City = update.City;
			value.UserId = update.UserId;
			value.AddressId = update.AddressId;
			value.UserSurname = update.UserSurname;
			value.Email = update.Email;
			value.Description = update.Description;
			value.Phone = update.Phone;
			value.UserName= update.UserName;
			await _repository.UpdateAsync(value);
		}
	}
}
