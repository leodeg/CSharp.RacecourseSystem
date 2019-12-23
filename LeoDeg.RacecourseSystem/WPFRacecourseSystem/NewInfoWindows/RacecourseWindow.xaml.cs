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
	/// Interaction logic for RacecourseWindow.xaml
	/// </summary>
	public partial class RacecourseWindow : Window
	{
		private Racecourse oldHorseFactory;

		public Action<Racecourse> OnAdd;
		public Action<Racecourse, int> OnUpdate;

		public RacecourseWindow ()
		{
			InitializeComponent ();
		}

		public RacecourseWindow (Racecourse horseFactoryToChange)
		{
			InitializeComponent ();
			oldHorseFactory = horseFactoryToChange;
			ShowOldContestInformation ();
		}

		private void ShowOldContestInformation ()
		{
			textBoxName.Text = oldHorseFactory.Name;
			textBoxCountry.Text = oldHorseFactory.Country;
			textBoxHorseAmount.Text = oldHorseFactory.HorseAmount.ToString ();
			textBoxAdditionalInfo.Text = oldHorseFactory.AdditionalInfo;
		}

		private Racecourse GetHorseFactory ()
		{
			try
			{
				return new Racecourse ()
				{
					Name = textBoxName.Text,
					Country = textBoxCountry.Text ?? "Empty",
					HorseAmount = GetHorseAmount (),
					AdditionalInfo = textBoxAdditionalInfo.Text ?? "Empty"
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

		private int GetHorseAmount ()
		{
			int horseAmount;
			try
			{
				horseAmount = int.Parse (textBoxHorseAmount.Text);
			}
			catch (Exception)
			{
				horseAmount = 0;
			}
			return horseAmount;
		}

		private bool CheckInformationFields ()
		{
			if (textBoxName.Text.Length < 1)
			{
				MessageBox.Show ("Name is empty.");
				return false;
			}

			if (textBoxAdditionalInfo.Text.Length > 255)
			{
				MessageBox.Show ("Additional Information is too long. The maximum size is a 255 characters.");
				return false;
			}

			return true;
		}

		private void buttonNew_Click (object sender, RoutedEventArgs e)
		{
			if (CheckInformationFields ())
			{
				OnAdd?.Invoke (GetHorseFactory ());
				MessageBox.Show ("Contest was successfully added to the database.");
			}
		}

		private void buttonUpdate_Click (object sender, RoutedEventArgs e)
		{
			if (oldHorseFactory != null)
			{
				if (CheckInformationFields ())
				{
					OnUpdate?.Invoke (GetHorseFactory (), oldHorseFactory.Id);
					MessageBox.Show ("Contest was successfully updated in the database.");
				}
			}
		}
	}
}
