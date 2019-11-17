using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Context
{

	class ParticipantContext : DbContext
	{
		public ParticipantContext () : base ("RacecourseDB")
		{

		}

		public DbSet<Participant> Participants { get; set; }
	}
}
