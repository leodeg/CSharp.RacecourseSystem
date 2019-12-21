using RacecourseSystem.Context;
using RacecourseSystem.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{

	public class RacecourseManagementSystem : IDisposable
	{
		public RacecourseLibrary Library { get; set; }

		public RacecourseManagementSystem ()
		{
			Library = new RacecourseLibrary ();
		}

		public void Dispose ()
		{
			Library.Dispose ();
		}
	}
}
