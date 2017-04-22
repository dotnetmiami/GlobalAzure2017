using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderViewServices.Models
{
	public class OrderInformation
	{
		public int OrderId { get; set; }
		public string CustomerId { get; set; }
		public Nullable<int> EmployeeId { get; set; }
		public string EmployeeName { get; set; }
		public Nullable<System.DateTime> OrderDate { get; set; }
		public Nullable<System.DateTime> RequiredDate { get; set; }
		public Nullable<System.DateTime> ShippedDate { get; set; }
		public Nullable<int> ShipVia { get; set; }
		public Nullable<decimal> Freight { get; set; }
		public string ShipName { get; set; }
		public string ShipAddress { get; set; }
		public string ShipCity { get; set; }
		public string ShipRegion { get; set; }
		public string ShipPostalCode { get; set; }
		public string ShipCountry { get; set; }
		public List<OrderDetailInformation> OrderDetails { get; set; }
		public CustomerInformation Customer { get; set; }
	}

	public class CustomerInformation
	{
		public string CustomerId { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string ContactTitle { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Region { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }
	}

	public class OrderDetailInformation
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public decimal UnitPrice { get; set; }
		public short Quantity { get; set; }
		public float Discount { get; set; }
		public ProductInformation Product { get; set; }
	}

	public class ProductInformation
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public Nullable<int> SupplierId { get; set; }
		public Nullable<int> CategoryId { get; set; }
		public string QuantityPerUnit { get; set; }
		public Nullable<decimal> UnitPrice { get; set; }
		public Nullable<short> UnitsInStock { get; set; }
		public Nullable<short> UnitsOnOrder { get; set; }
		public Nullable<short> ReorderLevel { get; set; }
		public bool Discontinued { get; set; }
	}
}