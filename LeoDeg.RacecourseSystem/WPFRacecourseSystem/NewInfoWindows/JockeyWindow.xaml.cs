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
	public partial class JockeyWindow : Window
	{
		private Jockey oldJockey;

		public Action<Jockey> OnAdd;
		public Action<Jockey, int> OnUpdate;

		public JockeyWindow ()
		{
			InitializeComponent ();
			AssignComboBoxValues ();
			buttonUpdate.IsEnabled = false;
		}

		public JockeyWindow (Jockey jockeyToChange)
		{
			if (jockeyToChange == null)
				throw new ArgumentNullException ();

			InitializeComponent ();
			AssignComboBoxValues ();

			oldJockey = jockeyToChange;
			ShowOldContestInformation ();
		}

		private void AssignComboBoxValues ()
		{
			comboBoxSex.ItemsSource = Enum.GetValues (typeof (Sex)).Cast<Sex> ();
		}

		private void ShowOldContestInformation ()
		{
			textBoxFirstName.Text = oldJockey.FirstName;
			textBoxLastName.Text = oldJockey.LastName;
			textBoxMiddleName.Text = oldJockey.MiddleName;
			textBoxCountry.Text = oldJockey.Country;
			datePickerDateOfBirth.SelectedDate = oldJockey.DateOfBirth;
			textBoxLicense.Text = oldJockey.License;
			textBoxRank.Text = oldJockey.Rank;
			textBoxAdditionalInfo.Text = oldJockey.AdditionalInfo;
		}

		private Jockey GetJockey ()
		{
			try
			{
				return new Jockey ()
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
				OnAdd?.Invoke (GetJockey ());
				MessageBox.Show ("Contest was successfully added to the database.");
			}
		}

		private void buttonUpdate_Click (object sender, RoutedEventArgs e)
		{
			if (oldJockey != null)
			{
				if (CheckInformationFields ())
				{
					OnUpdate?.Invoke (GetJockey (), oldJockey.Id);
					MessageBox.Show ("Contest was successfully updated in the database.");
				}
			}
		}
	}
}
