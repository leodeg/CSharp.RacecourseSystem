using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public class Contest : ID
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string HorsesBreed { get; set; }
		public int HorseAge { get; set; }
		public long PrizePool { get; set; }
		public DateTime DateTime { get; set; }
		public List<Participant> Jockeys { get; set; }
		public List<Horse> Horses { get; set; }

	}
}
