using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OrderView.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OrderView
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		MainViewModel ViewModel = new MainViewModel();
		public MainPage()
		{
			this.InitializeComponent();
			this.Loaded += MainPage_Loaded;
		}

		private void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			this.ViewModel.Initialize();

			this.DataContext = this.ViewModel;
		}

		private void OnEmployeeChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.ViewModel.SelectedSalesperson != null) this.ViewModel.ChangeUser(this.ViewModel.SelectedSalesperson);
		}

		private void OnShowCustomer(object sender, TappedRoutedEventArgs e)
		{
			FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
		}

		private void OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
		{
			this.ViewModel.FilterByCustomer((string)args.SelectedItem);
		}
	}
}

