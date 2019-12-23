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
	/// Interaction logic for HorseOwnerWindow.xaml
	/// </summary>
	public partial class HorseOwnerWindow : Window
	{
		private HorseOwner oldHorseOwner;

		public Action<HorseOwner> OnAdd;
		public Action<HorseOwner, int> OnUpdate;

		public HorseOwnerWindow ()
		{
			InitializeComponent ();
			AssignComboBoxValues ();
			buttonUpdate.IsEnabled = false;
		}

		public HorseOwnerWindow (HorseOwner horseOwnerToChange)
		{
			if (horseOwnerToChange == null)
				throw new ArgumentNullException ("Horse owner must be not null.");

			InitializeComponent ();
			AssignComboBoxValues ();

			oldHorseOwner = horseOwnerToChange;
			ShowOldContestInformation ();
		}

		private void AssignComboBoxValues ()
		{
			comboBoxSex.ItemsSource = Enum.GetValues (typeof (Sex)).Cast<Sex> ();
		}

		private void ShowOldContestInformation ()
		{
			textBoxFirstName.Text = oldHorseOwner.FirstName;
			textBoxLastName.Text = oldHorseOwner.LastName;
			textBoxMiddleName.Text = oldHorseOwner.MiddleName;
			textBoxCountry.Text = oldHorseOwner.Country;
			datePickerDateOfBirth.SelectedDate = oldHorseOwner.DateOfBirth;
		}

		private HorseOwner GetHorseOwner ()
		{
			try
			{
				return new HorseOwner ()
				{
					FirstName = textBoxFirstName.Text,
					LastName = textBoxLastName.Text,
					MiddleName = textBoxMiddleName.Text ?? "Empty",
					Country = textBoxCountry.Text ?? "Empty",
					Sex = (Sex)comboBoxSex.SelectedIndex,
					DateOfBirth = datePickerDateOfBirth.SelectedDate.Value
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
				OnAdd?.Invoke (GetHorseOwner ());
				MessageBox.Show ("Contest was successfully added to the database.");
				this.Close ();
			}
		}

		private void buttonUpdate_Click (object sender, RoutedEventArgs e)
		{
			if (oldHorseOwner != null)
			{
				if (CheckInformationFields ())
				{
					HorseOwner horseOwner = GetHorseOwner ();
					horseOwner.Id = oldHorseOwner.Id;
					OnUpdate?.Invoke (horseOwner, oldHorseOwner.Id);
					MessageBox.Show ("Contest was successfully updated in the database.");
				}
			}
		}
	}
}
