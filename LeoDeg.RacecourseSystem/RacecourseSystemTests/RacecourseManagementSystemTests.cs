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
		private RacecourseManagementSystem managementSystem;

		[SetUp]
		public void SetUp ()
		{
			managementSystem = new RacecourseManagementSystem ();
		}

		[Test]
		public void AddCompany_Clear_GetCount_Test ()
		{

		}
	}
}