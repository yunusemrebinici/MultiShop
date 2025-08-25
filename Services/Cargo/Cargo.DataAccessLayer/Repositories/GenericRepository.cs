using Cargo.DataAccessLayer.Abstract;
using Cargo.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private readonly CargoContext _context;

		public GenericRepository(CargoContext context)
		{
			_context = context;
		}

		public async Task Add(T entity)
		{
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<List<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetById(int id)
		{
			var value = await _context.Set<T>().FindAsync(id);
			return value;
		}

		public async Task Remove(T entity)
		{
			var remove = await _context.Set<T>().FindAsync(entity);
			_context.Remove(remove);
			await _context.SaveChangesAsync();
		}

		public async Task Update(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
