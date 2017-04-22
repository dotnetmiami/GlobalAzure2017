using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderViewServices.Models;

namespace OrderViewServices.Controllers
{
	public class OrdersController : ApiController
	{
		public IEnumerable<OrderInformation> GetOrders()
		{
			return Helpers.OrderHelper.GetOrders();
		}

		public OrderInformation Get(int id)
		{
			return Helpers.OrderHelper.GetOrder(id);
		}

		public IHttpActionResult Post(string value)
		{
			System.Web.HttpContext.Current.Cache["CurrentUser"] = value;
			return Created("CurrentUser", value);
		}
	}
	
}
