using RacecourseSystem.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{

	public class RacecourseManagementSystem
	{
		public RacecourseLibrary Library { get; set; }

		public RacecourseManagementSystem () : base ()
		{
			Library = new RacecourseLibrary ();
		}
	}
}
