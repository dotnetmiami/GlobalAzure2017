using OrderView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace OrderView.Helpers
{
	public static class OrderHelper
	{
		public const string OrderApiUrl = "http://orderviewservices20170422101528.azurewebsites.net/";

		public static List<SalespersonInformation> GetSalespersons()
		{
			List<SalespersonInformation> salespersons = new List<SalespersonInformation>();

			salespersons.Add(new SalespersonInformation() { Label = "Janet (Sales Manager)", UserName = "Janet" });
			salespersons.Add(new SalespersonInformation() { Label = "Andrew (Salesperson)", UserName = "Andrew" });
			salespersons.Add(new SalespersonInformation() { Label = "Nancy (Salesperson)", UserName = "Nancy" });

			return salespersons;
		}

		public static async Task<List<OrderInformation>> GetOrdersAsync(string filter)
		{
			List<OrderInformation> orders = new List<OrderInformation>();

			Uri requestUri = new Uri(OrderApiUrl + "api/Orders");
			HttpClient client = new System.Net.Http.HttpClient();
			HttpResponseMessage response = await client.GetAsync(requestUri);

			var stream = await response.Content.ReadAsStreamAsync();
			stream.Position = 0;

			var settings = new DataContractJsonSerializerSettings { DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss") };

			DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<OrderInformation>), settings);
			orders = (List<OrderInformation>)ser.ReadObject(stream);

			return orders.Where(w => w.Customer.CompanyName.Equals(filter)).ToList();
		}

		public static async Task<List<OrderInformation>> GetOrdersAsync()
		{
			List<OrderInformation> orders = new List<OrderInformation>();

			Uri requestUri = new Uri(OrderApiUrl + "api/Orders");
			HttpClient client = new System.Net.Http.HttpClient();
			HttpResponseMessage response = await client.GetAsync(requestUri);

			var stream = await response.Content.ReadAsStreamAsync();
			stream.Position = 0;

			var settings = new DataContractJsonSerializerSettings { DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss") };

			DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<OrderInformation>), settings);
			orders = (List<OrderInformation>)ser.ReadObject(stream);

			return orders;
		}

		public static async Task<bool> SetUserAsync(string userName)
		{
			Uri requestUri = new Uri(OrderApiUrl + $"api/Orders?value={userName}");

			var client = new System.Net.Http.HttpClient();
			HttpResponseMessage respon = await client.PostAsync(requestUri, null);

			return respon.IsSuccessStatusCode;
		}
	}
}