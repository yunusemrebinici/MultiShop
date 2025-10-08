using Cargo.DataAccessLayer.Abstract;
using Cargo.DataAccessLayer.Concrete;
using Cargo.DataAccessLayer.Repositories;
using Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.DataAccessLayer.EntityFramework
{
	public class EfCargoCustomerDal:GenericRepository<CargoCustomer>,ICargoCustomerDal
	{
		private readonly CargoContext _context;

		public EfCargoCustomerDal(CargoContext context) : base(context) 
		{
			_context = context;
		}


		public async Task<CargoCustomer> GetUserCargoDetail(string userId)
		{
			var values = await _context.CargoCustomers.Where(x => x.UserId == userId).FirstOrDefaultAsync();
			return values;
		}
	}
}
