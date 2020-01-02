using Contracts;

namespace Models
{
	public class OrderItem : BaseModel
	{
		public int ProductID { get; set; }
		public int Count { get; set; }
	}
}