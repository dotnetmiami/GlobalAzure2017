using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderView.Models;

namespace OrderView.Models
{
	public class MainViewModel : Common.BindableBase
	{
		private ObservableCollection<OrderInformation> _currentOrders;
		public ObservableCollection<OrderInformation> CurrentOrders
		{
			get { return this._currentOrders; }
			set { this.SetProperty(ref this._currentOrders, value); }
		}

		private List<SalespersonInformation> _salespersons;
		public List<SalespersonInformation> Salespersons
		{
			get { return this._salespersons; }
			set { this.SetProperty(ref this._salespersons, value); }
		}

		private SalespersonInformation _selectedSalesperson;
		public SalespersonInformation SelectedSalesperson
		{
			get { return this._selectedSalesperson; }
			set { this.SetProperty(ref this._selectedSalesperson, value); }
		}


		private ObservableCollection<string> _searchSuggestions;
		public ObservableCollection<string> SearchSuggestions
		{
			get { return this._searchSuggestions; }
			set { this.SetProperty(ref this._searchSuggestions, value); }
		}

		private bool _isLoading;

		public bool IsLoading
		{
			get { return this._isLoading; }
			set { this.SetProperty(ref this._isLoading, value); }
		}

		public const string OrderApiUrl = "";

		public void Initialize()
		{
			this.CurrentOrders = new ObservableCollection<OrderInformation>();
			this.SearchSuggestions = new ObservableCollection<string>();
			this.Salespersons = Helpers.OrderHelper.GetSalespersons();

			this.SelectedSalesperson = this.Salespersons.FirstOrDefault();
		}

		public void FilterByCustomer(string selectedCustomer)
		{
			LoadOrdersAsync(selectedCustomer);
		}

		public void ChangeUser(SalespersonInformation salesperson)
		{
			this.SelectedSalesperson = salesperson;

			LoadOrdersAsync();
		}

		public async void LoadOrdersAsync(string filter)
		{
			this.IsLoading = true;

			await Helpers.OrderHelper.SetUserAsync(this.SelectedSalesperson.UserName);

			this.CurrentOrders.Clear();

			var orders = await Helpers.OrderHelper.GetOrdersAsync(filter);

			foreach (var order in orders)
			{
				this.CurrentOrders.Add(order);
			}

			this.IsLoading = false;
		}

		public async void LoadOrdersAsync()
		{
			this.IsLoading = true;

			await Helpers.OrderHelper.SetUserAsync(this.SelectedSalesperson.UserName);

			this.CurrentOrders.Clear();

			var orders = await Helpers.OrderHelper.GetOrdersAsync();

			foreach (var order in orders)
			{
				this.CurrentOrders.Add(order);
			}

			this.IsLoading = false;
		}
	}
}