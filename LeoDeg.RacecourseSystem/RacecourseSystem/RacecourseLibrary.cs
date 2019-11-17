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
	public class RacecourseLibrary
	{
		public enum RemoveType { Company, Trainer, Jockey, Horse, HorseOwner, Contest }
		public enum ParticipantType { Trainer, Jockey }

		public DbContextEntityCollection<Company> Companies { get; set; }
		public DbContextEntityCollection<Contest> Contests { get; set; }
		public DbContextEntityCollection<Horse> Horses { get; set; }
		public DbContextEntityCollection<HorseOwner> HorseOwners { get; set; }
		public DbContextEntityCollection<Participant> Participants { get; set; }

		public RacecourseLibrary ()
		{
			Companies = new DbContextEntityCollection<Company> ();
			Contests = new DbContextEntityCollection<Contest> ();
			Horses = new DbContextEntityCollection<Horse> ();
			HorseOwners = new DbContextEntityCollection<HorseOwner> ();
			Participants = new DbContextEntityCollection<Participant> ();
		}
	}
}
