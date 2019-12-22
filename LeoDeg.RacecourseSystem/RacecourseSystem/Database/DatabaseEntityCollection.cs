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
		private DatabaseContext<TEntity> Context { get; set; }

		public DatabaseEntityCollection ()
		{
			Context = new DatabaseContext<TEntity> ();
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
			using (DatabaseContext<TEntity> db = new DatabaseContext<TEntity> ())
			{
				db.DbSet.Add (entity);
				db.SaveChanges ();
			}
		}

		/// <summary>
		/// Get entity to the database.
		/// </summary>
		/// <param name="id">id of the entity</param>
		public TEntity Get (int id)
		{
			using (DatabaseContext<TEntity> db = new DatabaseContext<TEntity> ())
			{
				return db.DbSet.Find (id);
			}
		}

		/// <summary>
		/// Return IEnumerabe with entities.
		/// </summary>
		public IEnumerable<TEntity> GetIEnumerable ()
		{
			using (DatabaseContext<TEntity> db = new DatabaseContext<TEntity> ())
			{
				return db.DbSet;
			}
		}

		public BindingList<TEntity> GetBindingList ()
		{
			using (DatabaseContext<TEntity> db = new DatabaseContext<TEntity> ())
			{
				return db.DbSet.Local.ToBindingList ();
			}
		}

		/// <summary>
		/// Return count of entities in the database.
		/// </summary>
		public int GetCount ()
		{
			using (DatabaseContext<TEntity> db = new DatabaseContext<TEntity> ())
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
			using (DatabaseContext<TEntity> db = new DatabaseContext<TEntity> ())
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
			using (DatabaseContext<TEntity> db = new DatabaseContext<TEntity> ())
			{
				var item = db.DbSet.Find (entityId);
				if (item == null) throw new ArgumentException (string.Format ("Cannot find entity with id: {0}", entityId));
				db.Entry (entity).CurrentValues.SetValues (entity);
			}
		}

		public void SaveChanges ()
		{
			using (DatabaseContext<TEntity> db = new DatabaseContext<TEntity> ())
			{
				db.SaveChanges ();
			}
		}

		public void Clear ()
		{
			using (DatabaseContext<TEntity> db = new DatabaseContext<TEntity> ())
			{
				db.DbSet.Clear ();
			}
		}
	}
}
