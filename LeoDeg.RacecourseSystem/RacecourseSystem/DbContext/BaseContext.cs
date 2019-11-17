using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Context
{
	/// <summary>
	/// DbContext wrapper for a racecourse library classes. 
	/// Provide similar access to the database for the racecourse library classes.
	/// </summary>
	public class BaseContext<T> : DbContext where T : class
	{
		public BaseContext () : base ("RacecourseDB")
		{

		}

		/// <summary>
		/// Set of entities that provide access to the database table.
		/// </summary>
		public DbSet<T> DbSet { get; set; }
	}
}
