using NUnit.Framework;
using RacecourseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Tests
{
	[TestFixture]
	public class RacecourseManagementSystemTests
	{
		RacecourseManagementSystem managementSystem;

		[SetUp]
		public void SetUp ()
		{
			managementSystem = new RacecourseManagementSystem ();
		}

		[Test]
		public void AddCompanyTest ()
		{
			managementSystem.AddCompany (new Company ());
			managementSystem.AddCompany (new Company ());
			managementSystem.AddCompany (new Company ());
			int actual = managementSystem.GetCompaniesCount ();
			Assert.AreEqual (3, actual);
		}
	}
}