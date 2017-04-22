using OrderViewServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderViewServices
{
	public static class ListExtensions
	{
		public static OrderInformation ToOrderInformation(this Data.Order order)
		{
			return new OrderInformation()
			{
				Customer = order.Customer.ToCustomerInformation(),
				OrderDetails = order.Order_Details.ToOrderDetailInformationList(),

				CustomerId = order.CustomerID,
				EmployeeId = order.EmployeeID,
				EmployeeName = order.EmployeeName,
				Freight = order.Freight,
				OrderDate = order.OrderDate,
				OrderId = order.OrderID,
				RequiredDate = order.RequiredDate,
				ShipAddress = order.ShipAddress,
				ShipCity = order.ShipCity,
				ShipCountry = order.ShipCountry,
				ShipName = order.ShipName,
				ShippedDate = order.ShippedDate,
				ShipPostalCode = order.ShipPostalCode,
				ShipRegion = order.ShipRegion,
				ShipVia = order.ShipVia,
			};
		}

		private static List<OrderDetailInformation> ToOrderDetailInformationList(this ICollection<Data.Order_Detail> orderDetails)
		{
			return (from detail in orderDetails select detail.ToOrderDetailInformation()).ToList();
		}

		public static OrderDetailInformation ToOrderDetailInformation(this Data.Order_Detail orderDetail)
		{
			return new OrderDetailInformation()
			{
				Discount = orderDetail.Discount,
				OrderId = orderDetail.OrderID,
				ProductId = orderDetail.ProductID,
				Quantity = orderDetail.Quantity,
				UnitPrice = orderDetail.UnitPrice,

				Product = orderDetail.Product.ToProductInformation(),
			};
		}

		public static CustomerInformation ToCustomerInformation(this Data.Customer customer)
		{
			return new CustomerInformation()
			{
				Address = customer.Address,
				City = customer.City,
				CompanyName = customer.CompanyName,
				ContactName = customer.ContactName,
				ContactTitle = customer.ContactTitle,
				Country = customer.Country,
				CustomerId = customer.CustomerID,
				Fax = customer.Fax,
				Phone = customer.Phone,
				PostalCode = customer.PostalCode,
				Region = customer.Region,

			};
		}

		public static ProductInformation ToProductInformation(this Data.Product product)
		{
			return new ProductInformation()
			{
				CategoryId = product.CategoryID,
				Discontinued = product.Discontinued,
				ProductId = product.ProductID,
				ProductName = product.ProductName,
				QuantityPerUnit = product.QuantityPerUnit,
				ReorderLevel = product.ReorderLevel,
				SupplierId = product.SupplierID,
				UnitPrice = product.UnitPrice,
				UnitsInStock = product.UnitsInStock,
				UnitsOnOrder = product.UnitsOnOrder,
			};
		}
	}
}