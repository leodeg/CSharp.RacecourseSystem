using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public class Horse
	{
		public string Name { get; set; }
		public string Breed { get; set; }
		public string Color { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Sex Sex { get; set; }
		public string Country { get; set; }
		public Company HorseFactory { get; set; }
		public Participant Trainer { get; set; }
		public HorseOwner Owner { get; set; }
		public string AdditionalInfo { get; set; }
	}
}
