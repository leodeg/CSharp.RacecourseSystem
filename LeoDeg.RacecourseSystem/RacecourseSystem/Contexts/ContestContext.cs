using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Context
{

	class ContestContext : DbContext
	{
		public ContestContext () : base ("DbConnection")
		{

		}

		public DbSet<Contest> Contests { get; set; }
	}
}
