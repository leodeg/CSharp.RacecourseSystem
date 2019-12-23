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
	/// Interaction logic for ContestWindow.xaml
	/// </summary>
	public partial class ContestWindow : Window
	{
		private Contest oldContest;

		public Action<Contest> OnAdd;
		public Action<Contest, int> OnUpdate;


		public ContestWindow ()
		{
			InitializeComponent ();
			buttonUpdate.IsEnabled = false;
		}

		public ContestWindow (Contest contestToUpdate)
		{
			InitializeComponent ();
			oldContest = contestToUpdate;
			ShowOldContestInformation ();
		}

		private void ShowOldContestInformation ()
		{
			textBoxTitle.Text = oldContest.Title;
			textBoxHorseBreed.Text = oldContest.HorsesBreed;
			textBoxPrizePool.Text = oldContest.PrizePool.ToString ();
			datePickerDateTime.SelectedDate = oldContest.DateTime;
		}

		private Contest GetContest ()
		{
			try
			{
				return new Contest ()
				{
					Title = textBoxTitle.Text,
					HorsesBreed = textBoxHorseBreed.Text ?? "Empty",
					DateTime = datePickerDateTime.SelectedDate.Value,
					PrizePool = long.Parse (textBoxPrizePool.Text)
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
			if (textBoxTitle.Text.Length < 1)
			{
				MessageBox.Show ("Title is empty.");
				return false;
			}

			if (!datePickerDateTime.SelectedDate.HasValue)
			{
				MessageBox.Show ("Date time is empty.");
				return false;
			}

			if (!long.TryParse (textBoxPrizePool.Text, out long result))
			{
				MessageBox.Show ("Prize pool is empty.");
				return false;
			}

			return true;
		}

		private void buttonNew_Click (object sender, RoutedEventArgs e)
		{
			if (CheckInformationFields ())
			{
				OnAdd?.Invoke (GetContest ());
				MessageBox.Show ("Contest was successfully added to the database.");
			}
		}

		private void buttonUpdate_Click (object sender, RoutedEventArgs e)
		{
			if (oldContest != null)
			{
				if (CheckInformationFields ())
				{
					OnUpdate?.Invoke (GetContest (), oldContest.Id);
					MessageBox.Show ("Contest was successfully updated in the database.");
				}
			}
		}
	}
}
