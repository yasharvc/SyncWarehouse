using Contracts.Interfaces;
using Models;

namespace Repository
{
	public interface IUserRepository : IRepository<User>
	{
		User GetByUserNamePassword(string username, string password);
	}
}