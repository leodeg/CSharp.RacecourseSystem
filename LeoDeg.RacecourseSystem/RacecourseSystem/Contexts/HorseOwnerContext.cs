using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Context
{

	class HorseOwnerContext : DbContext
	{
		public HorseOwnerContext () : base ("RacecourseDB")
		{

		}

		public DbSet<HorseOwner> HorseOwners { get; set; }
	}
}
