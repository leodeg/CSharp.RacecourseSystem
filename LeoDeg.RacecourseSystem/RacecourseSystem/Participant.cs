using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public class Participant : Person
	{
		public string License { get; set; }
		public string Rank { get; set; }
		public string AdditionalInfo { get; set; }
	}
}
