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
	public class EfCargoComanyDal :GenericRepository<CargoCompany>, ICargoCompanyDal
	{
		private readonly CargoContext _context;

		public EfCargoComanyDal(CargoContext context) :base(context) 
		{
			_context = context;
		}

	}
}
