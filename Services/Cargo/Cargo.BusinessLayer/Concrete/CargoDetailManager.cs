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
	public class CargoDetailManager : ICargoDetailService
	{
		private readonly ICargoDetailDal _cargoDetailDal;

		public CargoDetailManager(ICargoDetailDal cargoDetailDal)
		{
			_cargoDetailDal = cargoDetailDal;
		}

		public async Task TAdd(CargoDetail entity)
		{
			await _cargoDetailDal.Add(entity);
		}

		public async Task TDelete(CargoDetail entity)
		{
			await _cargoDetailDal.Update(entity);
		}

		public async Task<CargoDetail> TGetById(int id)
		{
			return await _cargoDetailDal.GetById(id);
		}

		public async Task<List<CargoDetail>> TGetListAll()
		{
			return await _cargoDetailDal.GetAll();
		}

		public async Task TUpdate(CargoDetail entity)
		{
			await _cargoDetailDal.Update(entity);
		}
	}
}
