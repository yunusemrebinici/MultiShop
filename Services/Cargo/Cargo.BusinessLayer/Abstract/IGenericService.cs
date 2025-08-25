using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		Task TAdd(T entity);

		Task TDelete(T entity);

		Task TUpdate(T entity);

		Task<T> TGetById(int id);

		Task<List<T>> TGetListAll();
	}
}
