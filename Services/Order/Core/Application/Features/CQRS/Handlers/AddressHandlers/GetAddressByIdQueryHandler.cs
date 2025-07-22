using Application.Features.CQRS.Quaries.AddressQuaries;
using Application.Features.CQRS.Results.AddressResults;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
	public class GetAddressByIdQueryHandler
	{
		private readonly IRepository<Address> _repository;

		public GetAddressByIdQueryHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
		{
			var value= await _repository.GetByIdAsync(query.Id);
			return new GetAddressByIdQueryResult
			{
				AddressId = value.AddressId,
				City = value.City,
				Detail=value.Detail,
				District = value.District,
				UserId = value.UserId
				
			} ;
		}
	}
}
