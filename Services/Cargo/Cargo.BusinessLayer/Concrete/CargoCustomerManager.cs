using Cargo.BusinessLayer.Abstract;
using Cargo.DataAccessLayer.Abstract;
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

		public async Task TUpdate(CargoCustomer entity)
		{
			await _customerDal.Update(entity);
		}
	}
}
