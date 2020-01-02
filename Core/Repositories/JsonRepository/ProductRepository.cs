using Models;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace JsonRepository
{
	public class ProductRepository : IProductRepository
	{
		List<Product> products = new List<Product>();

		public ProductRepository()
		{
			products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(JsonFileProvider.GetJson<ProductRepository>());
			if (products == null)
			{
				products = new List<Product>();
				Save();
			}
		}

		public void Delete(Product entity)
		{
			var item = GetByID(entity.Id);
			products.Remove(item);
			Save();
		}

		public IEnumerable<Product> GetAll() => products;

		public Product GetByID(int id) => products.Find(m => m.Id == id);

		public IEnumerable<Product> GetPaged(int countInPage, int pageNumber) => products.Skip((pageNumber - 1) * countInPage).Take(countInPage);

		public void Insert(Product entity)
		{
			try
			{
				entity.Id = products.Select(m => m.Id).Max() + 1;
			}
			catch
			{
				entity.Id = 1;
			}
			products.Add(entity);
			Save();
		}

		public void Update(Product entity)
		{
			var item = GetByID(entity.Id);
			item = entity;
			Save();
		}

		protected void Save() => JsonFileProvider.SetJson<ProductRepository>(ToJSON());
		protected string ToJSON() => Newtonsoft.Json.JsonConvert.SerializeObject(products);
	}
}
