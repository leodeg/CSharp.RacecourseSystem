using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Context
{
	public class BaseContext<T> : DbContext where T : class
	{
		public BaseContext () : base ("RacecourseDB")
		{

		}

		public DbSet<T> DbSet { get; set; }
	}
}
