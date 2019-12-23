using RacecourseSystem;
using RacecourseSystem.Database;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFRacecourseSystem
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private RacecourseManagementSystem managementSystem;
		private ContestWindow contestWindow;
		private HorseFactoryWindow horseFactoryWindow;
		private RacecourseWindow racecourseWindow;
		private HorseWindow horseWindow;
		private HorseOwnerWindow horseOwnerWindow;
		private JockeyWindow jockeyWindow;
		private TrainerWindow trainerWindow;


		public MainWindow ()
		{
			InitializeComponent ();
			managementSystem = new RacecourseManagementSystem ();
		}

		private void TabControl_SelectionChanged (object sender, SelectionChangedEventArgs e)
		{

		}

		#region Refresh Tables

		private void Button_Racecourse_Refresh_Click (object sender, RoutedEventArgs e)
		{
			if (managementSystem.Library.Racecourses.IsEmpty)
				MessageBox.Show ("Racecourses information is empty.");

			RacecourseGrid.ItemsSource = null;
			managementSystem.Library.Racecourses.Load ();
			RacecourseGrid.ItemsSource = managementSystem.Library.Racecourses.GetArray ();
		}



		private void Button_Contests_Refresh_Click (object sender, RoutedEventArgs e)
		{
			if (managementSystem.Library.Contests.IsEmpty)
				MessageBox.Show ("Contests information is empty.");
			managementSystem.Library.Contests.Load ();

			ContestsGrid.ItemsSource = null;
			ContestsGrid.Items.Refresh ();
			ContestsGrid.ItemsSource = managementSystem.Library.Contests.GetArray ();
		}

		

		private void Button_HorseFactories_Refresh_Click (object sender, RoutedEventArgs e)
		{
			if (managementSystem.Library.HorseFactories.IsEmpty)
				MessageBox.Show ("Horse Factories information is empty.");
			managementSystem.Library.HorseFactories.Load ();

			HorseFactoryGrid.ItemsSource = null;
			HorseFactoryGrid.ItemsSource = managementSystem.Library.HorseFactories.GetArray ();
			HorseFactoryGrid.Items.Refresh ();
		}

		private void Button_Horses_Refresh_Click (object sender, RoutedEventArgs e)
		{
			if (managementSystem.Library.Horses.IsEmpty)
				MessageBox.Show ("Horses information is empty.");

			HorsesGrid.ItemsSource = null;
			managementSystem.Library.Horses.Load ();
			HorsesGrid.ItemsSource = managementSystem.Library.Horses.GetArray ();
			HorsesGrid.Items.Refresh ();
		}

		private void Button_HorseOwners_Refresh_Click (object sender, RoutedEventArgs e)
		{
			if (managementSystem.Library.HorseOwners.IsEmpty)
				MessageBox.Show ("Horse Owners information is empty.");
			managementSystem.Library.HorseOwners.Load ();

			HorseOwnerGrid.ItemsSource = null;
			HorseOwnerGrid.ItemsSource = managementSystem.Library.HorseOwners.GetArray ();
			HorseOwnerGrid.Items.Refresh ();
		}

		private void Button_Jockeys_Refresh_Click (object sender, RoutedEventArgs e)
		{
			if (managementSystem.Library.Jockeys.IsEmpty)
				MessageBox.Show ("Jockeys information is empty.");
			managementSystem.Library.Jockeys.Load ();

			JockeyGrid.ItemsSource = null;
			JockeyGrid.ItemsSource = managementSystem.Library.Jockeys.GetArray ();
			JockeyGrid.Items.Refresh ();
		}

		private void Button_Trainers_Refresh_Click (object sender, RoutedEventArgs e)
		{
			if (managementSystem.Library.Trainers.IsEmpty)
				MessageBox.Show ("Trainers information is empty.");
			managementSystem.Library.Trainers.Load ();

			TrainerGrid.ItemsSource = null;
			TrainerGrid.ItemsSource = managementSystem.Library.Trainers.GetArray ();
			TrainerGrid.Items.Refresh ();
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

		private void NewInfo_Horse_Click (object sender, RoutedEventArgs e)
		{
			horseWindow = new HorseWindow ();
			horseWindow.OnAdd += managementSystem.Library.Horses.Add;
			horseWindow.OnUpdate += managementSystem.Library.Horses.Update;
			horseWindow.managementSystem = managementSystem;
			horseWindow.Show ();
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

		#region Clear Tables
		private void Button_Contests_Clear_Click (object sender, RoutedEventArgs e)
		{
			ContestsGrid.ItemsSource = null;
			ContestsGrid.Items.Refresh ();
		}

		private void Button_HorseFactories_Clear_Click (object sender, RoutedEventArgs e)
		{
			HorseFactoryGrid.ItemsSource = null;
			HorseFactoryGrid.Items.Refresh ();
		}

		private void Button_Racecourses_Clear_Click (object sender, RoutedEventArgs e)
		{
			RacecourseGrid.ItemsSource = null;
			RacecourseGrid.Items.Refresh ();
		}

		private void Button_Horses_Clear_Click (object sender, RoutedEventArgs e)
		{
			HorsesGrid.ItemsSource = null;
			HorsesGrid.Items.Refresh ();
		}

		private void Button_HorseOwners_Clear_Click (object sender, RoutedEventArgs e)
		{
			HorseOwnerGrid.ItemsSource = null;
			HorseOwnerGrid.Items.Refresh ();
		}

		private void Button_Jockeys_Clear_Click (object sender, RoutedEventArgs e)
		{
			JockeyGrid.ItemsSource = null;
			JockeyGrid.Items.Refresh ();
		}

		private void Button_Trainers_Clear_Click (object sender, RoutedEventArgs e)
		{
			TrainerGrid.ItemsSource = null;
			TrainerGrid.Items.Refresh ();
		}

		#endregion

		#region Grids Double Click Events

		private void ContestsGrid_MouseDoubleClick (object sender, MouseButtonEventArgs e)
		{
			Contest contest = ContestsGrid.SelectedItem as Contest;
			if (contest == null) return;
			contestWindow = new ContestWindow (contest);
			contestWindow.Title = string.Format ("Contest - Id: {0}, Title: {1}", contest.Id, contest.Title);
			contestWindow.OnAdd += managementSystem.Library.Contests.Add;
			contestWindow.OnUpdate += managementSystem.Library.Contests.Update;
			contestWindow.Show ();
		}

		private void HorseFactoryTab_MouseDoubleClick (object sender, MouseButtonEventArgs e)
		{
			HorseFactory horseFactory = HorseFactoryGrid.SelectedItem as HorseFactory;
			if (horseFactory == null) return;
			horseFactoryWindow = new HorseFactoryWindow (horseFactory);
			horseFactoryWindow.Title = string.Format ("Horse Factory - Id: {0}, Name: {1}", horseFactory.Id, horseFactory.Name);
			horseFactoryWindow.OnAdd += managementSystem.Library.HorseFactories.Add;
			horseFactoryWindow.OnUpdate += managementSystem.Library.HorseFactories.Update;
			horseFactoryWindow.Show ();
		}

		private void RacecourseGrid_MouseDoubleClick (object sender, MouseButtonEventArgs e)
		{
			Racecourse racecourse = RacecourseGrid.SelectedItem as Racecourse;
			if (racecourse == null) return;
			racecourseWindow = new RacecourseWindow (racecourse);
			racecourseWindow.Title = string.Format ("Racecourse - Id: {0}, Name: {1}", racecourse.Id, racecourse.Name);
			racecourseWindow.OnAdd += managementSystem.Library.Racecourses.Add;
			racecourseWindow.OnUpdate += managementSystem.Library.Racecourses.Update;
			racecourseWindow.Show ();
		}

		private void HorsesGrid_MouseDoubleClick (object sender, MouseButtonEventArgs e)
		{
			Horse horse = HorsesGrid.SelectedItem as Horse;
			if (horse == null) return;
			horseWindow = new HorseWindow (horse);
			horseWindow.Title = string.Format ("Horse - Id: {0}, Name: {1}", horse.Id, horse.Name);
			horseWindow.OnAdd += managementSystem.Library.Horses.Add;
			horseWindow.OnUpdate += managementSystem.Library.Horses.Update;
			horseWindow.managementSystem = managementSystem;
			horseWindow.Show ();
		}

		private void HorseOwnerGrid_MouseDoubleClick (object sender, MouseButtonEventArgs e)
		{
			HorseOwner horseOwner = HorseOwnerGrid.SelectedItem as HorseOwner;
			if (horseOwner == null) return;
			horseOwnerWindow = new HorseOwnerWindow (horseOwner);
			horseOwnerWindow.Title = string.Format ("Horse Owner - Id: {0}, Name: {1}", horseOwner.Id, horseOwner.FirstName + " " + horseOwner.LastName);
			horseOwnerWindow.OnAdd += managementSystem.Library.HorseOwners.Add;
			horseOwnerWindow.OnUpdate += managementSystem.Library.HorseOwners.Update;
			horseOwnerWindow.Show ();
		}

		private void JockeyGrid_MouseDoubleClick (object sender, MouseButtonEventArgs e)
		{
			Jockey jockey = JockeyGrid.SelectedItem as Jockey;
			if (jockey == null) return;
			jockeyWindow = new JockeyWindow (jockey);
			jockeyWindow.Title = string.Format ("Jockey - Id: {0}, Name: {1}", jockey.Id, jockey.FirstName + " " + jockey.LastName);
			jockeyWindow.OnAdd += managementSystem.Library.Jockeys.Add;
			jockeyWindow.OnUpdate += managementSystem.Library.Jockeys.Update;
			jockeyWindow.Show ();
		}

		private void TrainerGrid_MouseDoubleClick (object sender, MouseButtonEventArgs e)
		{
			Trainer trainer = TrainerGrid.SelectedItem as Trainer;
			if (trainer == null) return;
			trainerWindow = new TrainerWindow (trainer);
			trainerWindow.Title = string.Format ("Jockey - Id: {0}, Name: {1}", trainer.Id, trainer.FirstName + " " + trainer.LastName);
			trainerWindow.OnAdd += managementSystem.Library.Trainers.Add;
			trainerWindow.OnUpdate += managementSystem.Library.Trainers.Update;
			trainerWindow.Show ();
		}

		#endregion

		
	}
}
