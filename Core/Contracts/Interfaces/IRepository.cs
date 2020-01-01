using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces
{
	public interface IRepository<T> where T: BaseModel
	{
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
		T GetByID(int id);
		IEnumerable<T> GetPaged(int countInPage, int pageNumber);
		IEnumerable<T> GetAll();
	}
}
