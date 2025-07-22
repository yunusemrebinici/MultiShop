using Application.Features.CQRS.Commands.AddressComands;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
	public class CreateAddressCommandHandler
	{
		private readonly IRepository<Address> _repository;

		public CreateAddressCommandHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAddressCommand command)
		{
			await _repository.CreateAsync(new Address
			{
				City = command.City,
				Detail=command.Detail,
				District = command.District,
				UserId = command.UserId,

			});
		}
	}
}
