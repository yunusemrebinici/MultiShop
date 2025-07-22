using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly OrderContext _orderContext;

		public Repository(OrderContext orderContext)
		{
			_orderContext = orderContext;
		}

		public async Task CreateAsync(T entity)
		{
			await _orderContext.Set<T>().AddAsync(entity);
			await _orderContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_orderContext.Set<T>().Remove(entity);
			await _orderContext.SaveChangesAsync();
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _orderContext.Set<T>().ToListAsync();
		}

		public async Task<T> GetByFilterAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter)
		{
			return await _orderContext.Set<T>().SingleOrDefaultAsync(filter);
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _orderContext.Set<T>().FindAsync(id);
		}

		public async Task UpdateAsync(T entity)
		{
			_orderContext.Set<T>().Update(entity);
			await _orderContext.SaveChangesAsync();

		}
	}
}
