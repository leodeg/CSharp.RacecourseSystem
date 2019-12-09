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
	/// <summary>
	/// Class wrapper for DbContext.
	/// </summary>
	/// <typeparam name="TEntity">class for base context that is DbContext wrapper</typeparam>
	public class DatabaseEntityCollection<TEntity> : IDisposable where TEntity : class
	{
		private BaseContext<TEntity> Context { get; set; }

		public void Initialize ()
		{
			Context = new BaseContext<TEntity> ();
		}

		public void Dispose ()
		{
			Context.Dispose ();
		}

		/// <summary>
		/// Load date from the database.
		/// </summary>
		public void Load ()
		{
			Context.DbSet.Load ();
		}

		/// <summary>
		/// Return binding list of the current entity.
		/// </summary>
		public BindingList<TEntity> ToBindingList ()
		{
			return Context.DbSet.Local.ToBindingList ();
		}

		/// <summary>
		/// Add entity to the database.
		/// </summary>
		/// <param name="entity"></param>
		public void Add (TEntity entity)
		{
			using (BaseContext<TEntity> db = new BaseContext<TEntity> ())
			{
				db.DbSet.Add (entity);
				db.SaveChanges ();
			}
		}

		/// <summary>
		/// Return IEnumerabe with entities.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<TEntity> GetIEnumerable ()
		{
			using (BaseContext<TEntity> db = new BaseContext<TEntity> ())
			{
				return db.DbSet;
			}
		}

		public BindingList<TEntity> GetBindingList ()
		{
			using (BaseContext<TEntity> db = new BaseContext<TEntity> ())
			{
				return db.DbSet.Local.ToBindingList ();
			}
		}

		/// <summary>
		/// Return count of entities in the database.
		/// </summary>
		/// <returns></returns>
		public int GetCount ()
		{
			using (BaseContext<TEntity> db = new BaseContext<TEntity> ())
			{
				return db.DbSet.Count ();
			}
		}

		/// <summary>
		/// Remove entity from the database.
		/// </summary>
		/// <param name="entity"></param>
		public void Remove (TEntity entity)
		{
			using (BaseContext<TEntity> db = new BaseContext<TEntity> ())
			{
				db.DbSet.Remove (entity);
				db.SaveChanges ();
			}
		}

		/// <summary>
		/// Update information of entity with entityId.
		/// </summary>
		/// <param name="entity">entity with a new information</param>
		/// <param name="entityId">id of entity that will be updated</param>
		/// <exception cref="ArgumentException" />
		public void Update (TEntity entity, int entityId)
		{
			using (BaseContext<TEntity> db = new BaseContext<TEntity> ())
			{
				var item = db.DbSet.Find (entityId);
				if (item == null) throw new ArgumentException (string.Format ("Cannot find entity with id: {0}", entityId));
				db.Entry (entity).CurrentValues.SetValues (entity);
			}
		}

		public void Clear ()
		{
			using (BaseContext<TEntity> db = new BaseContext<TEntity> ())
			{
				db.DbSet.Clear ();
				db.SaveChanges ();
			}
		}
	}
}
