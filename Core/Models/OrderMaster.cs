using Contracts;
using System;
using System.Collections.Generic;

namespace Models
{
	public class OrderMaster : BaseModel
	{
		public int SenderUserID { get; set; }
		public int SenderWarehouseID { get; set; }
		public DateTime SendingDateTime { get; set; }
		public int ReceiverUserID { get; set; }
		public int ReceiverWarehouseID { get; set; }
		public DateTime ReceiveDateTime { get; set; }
		public ICollection<OrderItem> Items { get; set; }
	}
}