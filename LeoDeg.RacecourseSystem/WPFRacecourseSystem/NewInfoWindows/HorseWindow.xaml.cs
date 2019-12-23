using RacecourseSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WPFRacecourseSystem
{
	/// <summary>
	/// Interaction logic for HorseWindow.xaml
	/// </summary>
	public partial class HorseWindow : Window
	{
		public HorseFactory HorseFactory { get; set; }

		private Horse oldHorse;

		public Action<Horse> OnAdd;
		public Action<Horse, int> OnUpdate;

		public RacecourseManagementSystem managementSystem;

		public HorseWindow ()
		{
			InitializeComponent ();
			AssignComboBoxValues ();
		}

		public HorseWindow (Horse horseToChange)
		{
			if (horseToChange == null)
				throw new ArgumentNullException ();

			InitializeComponent ();
			oldHorse = horseToChange;
			AssignComboBoxValues ();
			ShowOldContestInformation ();
		}

		private void AssignComboBoxValues ()
		{
			comboBoxSex.ItemsSource = Enum.GetValues (typeof (Sex)).Cast<Sex> ();
		}

		private void ShowOldContestInformation ()
		{
			textBoxName.Text = oldHorse.Name;
			textBoxBreed.Text = oldHorse.Breed;
			textBoxColor.Text = oldHorse.Color;
			textBoxCountry.Text = oldHorse.Country;
			comboBoxSex.SelectedIndex = (int)oldHorse.Sex;
			datePickerDateOfBirth.SelectedDate = oldHorse.DateOfBirth;
			textBoxAdditionalInfo.Text = oldHorse.AdditionalInfo;
		}

		private Horse GetHorse ()
		{
			try
			{
				return new Horse ()
				{
					Name = textBoxName.Text,
					Breed = textBoxBreed.Text,
					Color = textBoxColor.Text,
					Country = textBoxCountry.Text,
					Sex = (Sex)comboBoxSex.SelectedIndex,
					DateOfBirth = datePickerDateOfBirth.SelectedDate.Value,
					AdditionalInfo = textBoxAdditionalInfo.Text,

					HorseFactory = GetHorseFactory (),
					Owner = GetHorseOwner (),
					Trainer = GetTrainer ()
				};
			}
			catch (ArgumentNullException ex)
			{
				MessageBox.Show ("Argument null exception: " + ex.Message);
				return null;
			}
			catch (FormatException ex)
			{
				MessageBox.Show ("Format exception: " + ex.Message);
				return null;
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message);
				return null;
			}
		}

		private HorseFactory GetHorseFactory ()
		{
			HorseFactory horseFactory = HorseFactoryGrid.SelectedItem as HorseFactory;
			if (horseFactory != null)
				return managementSystem.Library.HorseFactories.Get(horseFactory.Id);
			return null;
		}

		private HorseOwner GetHorseOwner ()
		{
			HorseOwner horseOwner = HorseOwnerGrid.SelectedItem as HorseOwner;
			if (horseOwner != null)
				return managementSystem.Library.HorseOwners.Get (horseOwner.Id);
			return null;
		}

		private Trainer GetTrainer ()
		{
			Trainer trainer = TrainerGrid.SelectedItem as Trainer;
			if (trainer != null)
				return managementSystem.Library.Trainers.Get (trainer.Id);
			return null;
		}

		private bool CheckInformationFields ()
		{
			if (textBoxName.Text.Length < 1)
			{
				MessageBox.Show ("First name is empty.");
				return false;
			}

			if (!datePickerDateOfBirth.SelectedDate.HasValue)
			{
				MessageBox.Show ("Date of birth is empty.");
				return false;
			}

			return true;
		}

		private void buttonNew_Click (object sender, RoutedEventArgs e)
		{
			if (CheckInformationFields ())
			{
				OnAdd?.Invoke (GetHorse ());
				MessageBox.Show ("Contest was successfully added to the database.");
			}
		}

		private void buttonUpdate_Click (object sender, RoutedEventArgs e)
		{
			if (oldHorse != null && CheckInformationFields ())
			{
				OnUpdate?.Invoke (GetHorse (), oldHorse.Id);
				MessageBox.Show ("Contest was successfully updated in the database.");
			}
		}

		private void buttonRefreshHorseFactories_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.HorseFactories.Load ();
			HorseFactoryGrid.ItemsSource = managementSystem.Library.HorseFactories.GetArray ();
		}

		private void buttonRefreshHorseOwners_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.HorseOwners.Load ();
			HorseOwnerGrid.ItemsSource = managementSystem.Library.HorseOwners.GetArray ();
		}

		private void buttonRefreshTrainers_Click (object sender, RoutedEventArgs e)
		{
			managementSystem.Library.Trainers.Load ();
			TrainerGrid.ItemsSource = managementSystem.Library.Trainers.GetArray ();
		}
	}
}
