using RacecourseSystem;
using RacecourseSystem.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFRacecourseSystem
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		RacecourseManagementSystem managementSystem;


		public MainWindow ()
		{
			InitializeComponent ();

			managementSystem = new RacecourseManagementSystem ();
			managementSystem.Library.Companies.Initialize ();
		}



		private void TabControl_SelectionChanged (object sender, SelectionChangedEventArgs e)
		{
			if (CompaniesTab.IsSelected)
			{
				managementSystem.Library.Companies.Context.DbSet.Load ();
				CompaniesGrid.ItemsSource = managementSystem.Library.Companies.Context.DbSet.Local.ToBindingList ();
			}
		}
	}
}
