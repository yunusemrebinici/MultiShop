using Cargo.BusinessLayer.Abstract;
using Cargo.DataAccessLayer.Abstract;
using Cargo.DTO.CargoCustomerDtos;
using Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.BusinessLayer.Concrete
{
	public class CargoCustomerManager : ICargoCustomerService
	{
		private readonly ICargoCustomerDal _customerDal;

		public CargoCustomerManager(ICargoCustomerDal customerDal)
		{
			_customerDal = customerDal;
		}

		public async Task CreateCargoDetail(CreateCargoCustomerDto createCargoCustomerDto)
		{
			CargoCustomer value = new CargoCustomer()
			{
				Address = createCargoCustomerDto.Address,
				City = createCargoCustomerDto.City,
				District = createCargoCustomerDto.District,
				Email = createCargoCustomerDto.Email,
				Name = createCargoCustomerDto.Name,
				Phone = createCargoCustomerDto.Phone,
				Surname = createCargoCustomerDto.Surname,
				UserId = createCargoCustomerDto.UserId,
			};
			await TAdd(value);
		}

		public async Task TAdd(CargoCustomer entity)
		{
			await _customerDal.Add(entity);
		}

		public async Task TDelete(CargoCustomer entity)
		{
			 await _customerDal.Update(entity);
		}

		public async Task<CargoCustomer> TGetById(int id)
		{
			return await _customerDal.GetById(id);
		}

		public async Task<List<CargoCustomer>> TGetListAll()
		{
			return await _customerDal.GetAll();
		}

		public async Task<ResultCargoCustomerDto> TGetUserCargoDetail(string userId)
		{
			var values= await _customerDal.GetUserCargoDetail(userId);

			if(values != null)
			{
				return new ResultCargoCustomerDto()
				{
					Address = values.Address,
					CargoCustomerId = values.CargoCustomerId,
					City = values.City,
					District = values.District,
					Email = values.Email,
					Name = values.Name,
					Phone = values.Phone,
					Surname = values.Surname,
					UserId = values.UserId


				};
			}
			else
			{
				return new ResultCargoCustomerDto();
			}
			
		}

		public async Task TUpdate(CargoCustomer entity)
		{
			await _customerDal.Update(entity);
		}
	}
}
