using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public class HorseOwner : Person
	{
		public List<Horse> Horses { get; set; }
		public int HorseCount { get { return Horses.Count; } }
	}
}
