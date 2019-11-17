using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public enum CompanyType { Racecourse, HorseFactory }

	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public CompanyType CompanyType { get; set; }
		public int HorseAmount { get; set; }
		public string AdditionalInfo { get; set; }
	}
}
