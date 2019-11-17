using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Context
{

	class HorseContext : DbContext
	{
		public HorseContext () : base ("DbConnection")
		{

		}

		public DbSet<Horse> Horses { get; set; }
	}
}
