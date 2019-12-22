using RacecourseSystem.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	/// <summary>
	/// Library of racecourse information. Provide access to database.
	/// </summary>
	public class RacecourseLibrary : IDisposable
	{
		public DatabaseEntityCollection<Contest> Contests { get; }
		public DatabaseEntityCollection<ContestParticipant> ContestParticipants { get; }

		public DatabaseEntityCollection<Horse> Horses { get; }
		public DatabaseEntityCollection<HorseOwner> HorseOwners { get; }
		public DatabaseEntityCollection<Racecourse> Racecourses { get; }
		public DatabaseEntityCollection<HorseFactory> HorseFactories { get; }

		public DatabaseEntityCollection<Jockey> Jockeys { get; }
		public DatabaseEntityCollection<Trainer> Trainers { get; }


		public RacecourseLibrary ()
		{
			Contests = new DatabaseEntityCollection<Contest> ();
			ContestParticipants = new DatabaseEntityCollection<ContestParticipant> ();

			Horses = new DatabaseEntityCollection<Horse> ();
			HorseOwners = new DatabaseEntityCollection<HorseOwner> ();
			Racecourses = new DatabaseEntityCollection<Racecourse> ();
			HorseFactories = new DatabaseEntityCollection<HorseFactory> ();

			Jockeys = new DatabaseEntityCollection<Jockey> ();
			Trainers = new DatabaseEntityCollection<Trainer> ();
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose ()
		{
			Contests.Dispose ();
			ContestParticipants.Dispose ();

			Horses.Dispose ();
			HorseOwners.Dispose ();
			Racecourses.Dispose ();
			HorseFactories.Dispose ();

			Jockeys.Dispose ();
			Trainers.Dispose ();
		}
	}
}
