using RacecourseSystem.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public class HorseCollection : DatabaseEntityCollection<Horse>
	{
		/// <summary>
		/// Return binding list of the current entity.
		/// </summary>
		public override Array GetArray ()
		{
			return Context.DbSet.Include (x => x.HorseFactory).Include (x => x.Owner).Include (x => x.Trainer).ToArray ();
		}
	}
}
