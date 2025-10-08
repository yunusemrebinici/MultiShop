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
	public class CargoCompanyManager : ICargoCompanyService
	{
		private readonly ICargoCompanyDal _companyDal;

		public CargoCompanyManager(ICargoCompanyDal companyDal)
		{
			_companyDal = companyDal;
		}

		public async Task TAdd(CargoCompany entity)
		{
			await _companyDal.Add(entity);
		}

		

		public async Task TDelete(CargoCompany entity)
		{
			await _companyDal.Remove(entity);
		}

		public async Task<CargoCompany> TGetById(int id)
		{
		    return await _companyDal.GetById(id);
		}

		public async Task<List<CargoCompany>> TGetListAll()
		{
			 return await	_companyDal.GetAll();
		}

		public async Task TUpdate(CargoCompany entity)
		{
			await _companyDal.Update(entity);
		}
	}
}
