using Cargo.DataAccessLayer.Abstract;
using Cargo.DataAccessLayer.Concrete;
using Cargo.DataAccessLayer.Repositories;
using Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.DataAccessLayer.EntityFramework
{
	public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
	{
		public EfCargoDetailDal(CargoContext context) : base(context)
		{
		}
	}
}
