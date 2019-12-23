using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public class Participant : Person
	{
		[StringLength (50)]
		public string License { get; set; }
		[StringLength (50)]
		public string Rank { get; set; }
		[StringLength (255)]
		public string AdditionalInfo { get; set; }
	}
}
