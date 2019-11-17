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

	public static class ExtensionsMethods
	{
		/// <summary>
		/// Extension Method. Clear all data from table.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dbSet"></param>
		public static void Clear<T> (this DbSet<T> dbSet) where T : class
		{
			dbSet.RemoveRange (dbSet);
		}
	}
}
