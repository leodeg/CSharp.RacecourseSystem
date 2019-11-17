using RacecourseSystem.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{

	public class RacecourseManagementSystem
	{
		public enum RemoveType { Company, Trainer, Jockey, Horse, HorseOwner, Contest }
		public enum ParticipantType { Trainer, Jockey }


		public RacecourseManagementSystem () : base ()
		{

		}

		public void AddCompany (Company company)
		{
			using (CompanyContext db = new CompanyContext ())
			{
				db.Companies.Add (company);
				db.SaveChanges ();
			}
		}

		public IEnumerable<Company> GetCompanies ()
		{
			using (CompanyContext db = new CompanyContext ())
			{
				return db.Companies;
			}
		}

		public int GetCompaniesCount ()
		{
			using (CompanyContext db = new CompanyContext ())
			{
				return db.Companies.Count ();
			}
		}

		public void AddContest (Contest contest)
		{
			using (ContestContext db = new ContestContext ())
			{
				db.Contests.Add (contest);
				db.SaveChanges ();
			}
		}

		public void AddHorse (Horse horse)
		{
			using (HorseContext db = new HorseContext ())
			{
				db.Horses.Add (horse);
				db.SaveChanges ();
			}
		}

		public void AddHorseOwner (HorseOwner horseOwner)
		{
			using (HorseOwnerContext db = new HorseOwnerContext ())
			{
				db.HorseOwners.Add (horseOwner);
				db.SaveChanges ();
			}
		}

		public void AddParticipant (Participant participant, ParticipantType type)
		{
			using (ParticipantContext db = new ParticipantContext ())
			{
				db.Participants.Add (participant);
				db.SaveChanges ();
			}
		}

		public void Remove (int id, RemoveType type)
		{
			switch (type)
			{
				case RemoveType.Company:
					break;
				case RemoveType.Trainer:
					break;
				case RemoveType.Jockey:
					break;
				case RemoveType.Horse:
					break;
				case RemoveType.HorseOwner:
					break;
				case RemoveType.Contest:
					break;
				default:
					break;
			}
		}
	}
}
