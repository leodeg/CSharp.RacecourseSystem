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
		public enum RemoveType { Company, Trainer, Jockey, Horse, HorseOwner, Contest }
		public enum ParticipantType { Trainer, Jockey }

		public DatabaseEntityCollection<Company> Companies { get; }
		public DatabaseEntityCollection<Contest> Contests { get; }
		public DatabaseEntityCollection<Horse> Horses { get; }
		public DatabaseEntityCollection<HorseOwner> HorseOwners { get; }
		public DatabaseEntityCollection<Participant> Participants { get; }

		public RacecourseLibrary ()
		{
			Companies = new DatabaseEntityCollection<Company> ();
			Contests = new DatabaseEntityCollection<Contest> ();
			Horses = new DatabaseEntityCollection<Horse> ();
			HorseOwners = new DatabaseEntityCollection<HorseOwner> ();
			Participants = new DatabaseEntityCollection<Participant> ();
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose ()
		{
			Companies.Dispose ();
			Contests.Dispose ();
			Horses.Dispose ();
			HorseOwners.Dispose ();
			Participants.Dispose ();
		}
	}
}
