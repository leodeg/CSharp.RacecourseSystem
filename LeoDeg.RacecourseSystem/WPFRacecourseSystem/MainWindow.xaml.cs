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

			Horse horse = new Horse ()
			{
				Name = "Name",
				Breed = "Breed",
				Color = "Color",
				DateOfBirth = DateTime.Now,
				Sex = Sex.None,
				Country = "Country",
				AdditionalInfo = "Empty"
			};

			managementSystem.Library.Horses.Add (horse);
			managementSystem.Library.Horses.SaveChanges ();


			HorsesGrid.ItemsSource = managementSystem.Library.Horses.ToBindingList ();
		}

		private void TabControl_SelectionChanged (object sender, SelectionChangedEventArgs e)
		{
			if (HorseFactoryTab.IsSelected)
			{
				//HorseFactory horseFactory = new HorseFactory ()
				//{
				//	Name = "Name",
				//	Country = "Country",
				//	HorseAmount = 10,
				//	AdditionalInfo = "Empty"
				//};

				//managementSystem.Library.HorseFactories.Add (horseFactory);
				HorseFactoryGrid.ItemsSource = managementSystem.Library.HorseFactories.ToBindingList ();
			}
		}
	}
}
