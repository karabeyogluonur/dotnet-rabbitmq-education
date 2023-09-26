using System;
namespace OrderProducer.Console.Models
{
	public class OrderModel
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; } = String.Empty;
		public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;

        public List<ProductModel> Products { get; set; }

	}
}

