using Cargo.DTO.CargoCustomerDtos;
using Cargo.DTO.CargoDetailDtos;
using Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.BusinessLayer.Abstract
{
	public interface ICargoCustomerService:IGenericService<CargoCustomer>
	{
		Task<ResultCargoCustomerDto> TGetUserCargoDetail(string userId);

		Task CreateCargoDetail(CreateCargoCustomerDto createCargoCustomerDto);
	}
}
