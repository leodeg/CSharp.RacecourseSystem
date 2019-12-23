using RacecourseSystem;
using System;
using System.Collections.Generic;
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
	/// Interaction logic for JockeyWindow.xaml
	/// </summary>
	public partial class TrainerWindow : Window
	{
		private Trainer oldTrainer;

		public Action<Trainer> OnAdd;
		public Action<Trainer, int> OnUpdate;

		public TrainerWindow ()
		{
			InitializeComponent ();
			AssignComboBoxValues ();
			buttonUpdate.IsEnabled = false;
		}

		public TrainerWindow (Trainer trainerToChange)
		{
			if (trainerToChange == null)
				throw new ArgumentNullException ();

			InitializeComponent ();
			AssignComboBoxValues ();

			oldTrainer = trainerToChange;
			ShowOldContestInformation ();
		}

		private void AssignComboBoxValues ()
		{
			comboBoxSex.ItemsSource = Enum.GetValues (typeof (Sex)).Cast<Sex> ();
		}

		private void ShowOldContestInformation ()
		{
			textBoxFirstName.Text = oldTrainer.FirstName;
			textBoxLastName.Text = oldTrainer.LastName;
			textBoxMiddleName.Text = oldTrainer.MiddleName;
			textBoxCountry.Text = oldTrainer.Country;
			datePickerDateOfBirth.SelectedDate = oldTrainer.DateOfBirth;
			textBoxLicense.Text = oldTrainer.License;
			textBoxRank.Text = oldTrainer.Rank;
			textBoxAdditionalInfo.Text = oldTrainer.AdditionalInfo;
		}

		private Trainer GetTrainer ()
		{
			try
			{
				return new Trainer ()
				{
					FirstName = textBoxFirstName.Text,
					LastName = textBoxLastName.Text,
					MiddleName = textBoxMiddleName.Text,
					Country = textBoxCountry.Text,
					Sex = (Sex)comboBoxSex.SelectedIndex,
					DateOfBirth = datePickerDateOfBirth.SelectedDate.Value,
					License = textBoxLicense.Text,
					Rank = textBoxRank.Text,
					AdditionalInfo = textBoxAdditionalInfo.Text
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

		private bool CheckInformationFields ()
		{
			if (textBoxFirstName.Text.Length < 1)
			{
				MessageBox.Show ("First name is empty.");
				return false;
			}

			if (textBoxLastName.Text.Length < 1)
			{
				MessageBox.Show ("Last name is empty.");
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
				OnAdd?.Invoke (GetTrainer ());
				MessageBox.Show ("Contest was successfully added to the database.");
				this.Close ();
			}
		}

		private void buttonUpdate_Click (object sender, RoutedEventArgs e)
		{
			if (oldTrainer != null)
			{
				if (CheckInformationFields ())
				{
					OnUpdate?.Invoke (GetTrainer (), oldTrainer.Id);
					MessageBox.Show ("Contest was successfully updated in the database.");
				}
			}
		}
	}
}
