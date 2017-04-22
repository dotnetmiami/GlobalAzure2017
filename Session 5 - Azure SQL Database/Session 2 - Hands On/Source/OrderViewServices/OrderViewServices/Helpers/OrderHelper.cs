using OrderViewServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderViewServices.Helpers
{
	public static class OrderHelper
	{
		public static string CreateConnectionString()
		{
			string userName = (string)System.Web.HttpContext.Current.Cache["CurrentUser"];
			string password = "Password_1";

			if (string.IsNullOrEmpty(userName))
			{
				userName = "sqladmin";
				password = "Password_1";
			}

			string serverName = "gab17alp1";
			return string.Format("data source={0}.database.windows.net;initial catalog=Northwind;user id={1};password={2};MultipleActiveResultSets=True;App=EntityFramework", serverName, userName, password);
		}

		public static List<OrderInformation> GetOrders()
		{
			List<OrderInformation> orders = new List<OrderInformation>();

			using (Data.NorthwindEntities entities = new Data.NorthwindEntities())
			{
				entities.Database.Connection.ConnectionString = CreateConnectionString();
				entities.Database.Connection.Open();

				try
				{
					foreach (var result in entities.Orders.OrderByDescending(o => o.OrderDate).Take(20))
					{
						orders.Add(result.ToOrderInformation());
					}
				}
				catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
				{

				}
				finally
				{
					entities.Database.Connection.Close();
				}

				return orders;
			}
		}

		public static OrderInformation GetOrder(int orderId)
		{
			OrderInformation order = null;

			using (Data.NorthwindEntities entities = new Data.NorthwindEntities())
			{
				entities.Database.Connection.ConnectionString = CreateConnectionString();
				entities.Database.Connection.Open();

				try
				{
					var result = entities.Orders.Where(w => w.OrderID == orderId).FirstOrDefault();

					if (result != null)
					{
						order = result.ToOrderInformation();
					}
				}
				catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
				{

				}
				finally
				{
					entities.Database.Connection.Close();
				}

				return order;
			}
		}
	}
}