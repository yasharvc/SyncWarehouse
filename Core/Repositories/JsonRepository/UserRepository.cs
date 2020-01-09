using Models;
using Newtonsoft.Json;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace JsonRepository
{
	public class UserRepository : IUserRepository
	{
		List<User> users = new List<User>();

		public UserRepository()
		{
			users = JsonConvert.DeserializeObject<List<User>>(JsonFileProvider.GetJson<UserRepository>());
			if (users == null)
			{
				users = new List<User>();
				Save();
			}
		}
		public void Delete(User entity)
		{
			var item = GetByID(entity.Id);
			users.Remove(item);
			Save();
		}

		public IEnumerable<User> GetAll() => users;

		public User GetByID(int id) => users.Find(m => m.Id == id);

		public User GetByUserNamePassword(string username, string password) => users.Single(m => m.UserName == username && m.Password == m.Password);

		public IEnumerable<User> GetPaged(int countInPage, int pageNumber) => users.Skip((pageNumber - 1) * countInPage).Take(countInPage);

		public void Insert(User entity)
		{
			try
			{
				entity.Id = users.Select(m => m.Id).Max() + 1;
			}
			catch
			{
				entity.Id = 1;
			}
			users.Add(entity);
			Save();
		}

		public void Update(User entity)
		{
			var item = GetByID(entity.Id);
			item = entity;
			Save();
		}

		protected void Save() => JsonFileProvider.SetJson<ProductRepository>(ToJSON());

		protected string ToJSON() => Newtonsoft.Json.JsonConvert.SerializeObject(users);
	}
}
