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

		public async Task<CargoCustomer> TGetUserCargoDetail(string userId)
		{
			return await _customerDal.GetUserCargoDetail(userId);
		}

		public async Task TUpdate(CargoCustomer entity)
		{
			await _customerDal.Update(entity);
		}
	}
}
