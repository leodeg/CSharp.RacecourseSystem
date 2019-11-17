﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem.Context
{

	class CompanyContext : DbContext
	{
		public CompanyContext () : base ("DbConnection")
		{

		}

		public DbSet<Company> Companies { get; set; }
	}
}
