using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Context
{
	class PersonContext : DbContext
	{
		public PersonContext () : base ("DbConnection")
		{

		}

		public DbSet<Person> Persons { get; set; }
	}
}
