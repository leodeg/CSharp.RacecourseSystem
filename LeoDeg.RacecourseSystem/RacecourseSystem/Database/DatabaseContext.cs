using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Context
{
	/// <summary>
	/// DbContext wrapper for a racecourse library classes. 
	/// Provide similar access to the database for the racecourse library classes.
	/// </summary>
	public class DatabaseContext<T> : DbContext where T : class
	{
		public DatabaseContext () : base ("RacecourseDB")
		{

		}

		/// <summary>
		/// Set of entities that provide access to the database table.
		/// </summary>
		public DbSet<T> DbSet { get; set; }

		internal object CreateObjectSet<T1> ()
		{
			throw new NotImplementedException ();
		}
	}

	public class DatabaseContext : DbContext
	{
		public DatabaseContext () : base ("RacecourseDB")
		{
		}

		public DbSet<Contest> Contests { get; set; }
		public DbSet<ContestParticipant> ContestParticipants { get; set; }
		public DbSet<Horse> Horses { get; set; }
		public DbSet<HorseOwner> HorseOwners { get; set; }
		public DbSet<Jockey> Jockeys { get; set; }
		public DbSet<Trainer> Trainers { get; set; }
		public DbSet<Racecourse> Racecourses { get; set; }
		public DbSet<HorseFactory> HorseFactories { get; set; }
	}
}
