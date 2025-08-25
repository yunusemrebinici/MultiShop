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
	public class CargoOperationManager : ICargoOperationService
	{
		private readonly ICargoOperationDal _cargoOperationDal;

		public CargoOperationManager(ICargoOperationDal cargoOperationDal)
		{
			_cargoOperationDal = cargoOperationDal;
		}

		public async Task TAdd(CargoOperation entity)
		{
			await _cargoOperationDal.Add(entity);
		}

		public async Task TDelete(CargoOperation entity)
		{
			await _cargoOperationDal.Remove(entity);
		}

		public async Task<CargoOperation> TGetById(int id)
		{
		    return  await _cargoOperationDal.GetById(id);
		}

		public async Task<List<CargoOperation>> TGetListAll()
		{
		   return await _cargoOperationDal.GetAll();
		}

		public async Task TUpdate(CargoOperation entity)
		{
			await _cargoOperationDal.Update(entity);
		}
	}
}
