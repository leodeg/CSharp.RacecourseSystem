using RacecourseSystem;
using RacecourseSystem.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
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

		ContestWindow contestWindow;
		HorseFactoryWindow horseFactoryWindow;
		RacecourseWindow racecourseWindow;
		HorseOwnerWindow horseOwnerWindow;
		JockeyWindow jockeyWindow;
		TrainerWindow trainerWindow;

		public MainWindow ()
		{
			InitializeComponent ();
			managementSystem = new RacecourseManagementSystem ();
			Initialize ();
		}

		private void Initialize ()
		{

		}

		private void TabControl_SelectionChanged (object sender, SelectionChangedEventArgs e)
		{

		}

		#region Refresh Tables

		private void Button_Racecourse_Refresh_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.Racecourses.Load ();
			RacecourseGrid.ItemsSource = managementSystem.Library.Racecourses.ToBindingList ();
		}

		private void Button_Contests_Refresh_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.Contests.Load ();
			ContestsGrid.ItemsSource = managementSystem.Library.Contests.ToBindingList ();
		}

		private void Button_HorseFactories_Refresh_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.HorseFactories.Load ();
			HorseFactoryGrid.ItemsSource = managementSystem.Library.HorseFactories.ToBindingList ();
		}

		private void Button_Horses_Refresh_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.Horses.Load ();
			HorsesGrid.ItemsSource = managementSystem.Library.Horses.ToBindingList ();
		}

		private void Button_HorseOwners_Refresh_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.HorseOwners.Load ();
			HorseOwnerGrid.ItemsSource = managementSystem.Library.HorseOwners.ToBindingList ();
		}

		private void Button_Jockeys_Refresh_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.Jockeys.Load ();
			JockeyGrid.ItemsSource = managementSystem.Library.Jockeys.ToBindingList ();
		}

		private void Button_Trainers_Refresh_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.Trainers.Load ();
			TrainerGrid.ItemsSource = managementSystem.Library.Trainers.ToBindingList ();
		}

		#endregion

		#region New Info

		private void NewInfo_Contest_Click (object sender, RoutedEventArgs e)
		{
			contestWindow = new ContestWindow ();
			contestWindow.OnAdd += managementSystem.Library.Contests.Add;
			contestWindow.OnUpdate += managementSystem.Library.Contests.Update;
			contestWindow.Show ();
		}

		private void NewInfo_HorseFactory_Click (object sender, RoutedEventArgs e)
		{
			horseFactoryWindow = new HorseFactoryWindow ();
			horseFactoryWindow.OnAdd += managementSystem.Library.HorseFactories.Add;
			horseFactoryWindow.OnUpdate += managementSystem.Library.HorseFactories.Update;
			horseFactoryWindow.Show ();
		}

		private void NewInfo_Racecourse_Click (object sender, RoutedEventArgs e)
		{
			racecourseWindow = new RacecourseWindow ();
			racecourseWindow.OnAdd += managementSystem.Library.Racecourses.Add;
			racecourseWindow.OnUpdate += managementSystem.Library.Racecourses.Update;
			racecourseWindow.Show ();
		}

		private void NewInfo_HorseOwner_Click (object sender, RoutedEventArgs e)
		{
			horseOwnerWindow = new HorseOwnerWindow ();
			horseOwnerWindow.OnAdd += managementSystem.Library.HorseOwners.Add;
			horseOwnerWindow.OnUpdate += managementSystem.Library.HorseOwners.Update;
			horseOwnerWindow.Show ();
		}

		private void NewInfo_Jockey_Click (object sender, RoutedEventArgs e)
		{
			jockeyWindow = new JockeyWindow ();
			jockeyWindow.OnAdd += managementSystem.Library.Jockeys.Add;
			jockeyWindow.OnUpdate += managementSystem.Library.Jockeys.Update;
			jockeyWindow.Show ();
		}

		private void NewInfo_Trainer_Click (object sender, RoutedEventArgs e)
		{
			trainerWindow = new TrainerWindow ();
			trainerWindow.OnAdd += managementSystem.Library.Trainers.Add;
			trainerWindow.OnUpdate += managementSystem.Library.Trainers.Update;
			trainerWindow.Show ();
		}

		#endregion
	}
}
