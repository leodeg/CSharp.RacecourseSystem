using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public enum Sex { None, Male, Female }

	public class Person : ID
	{
		[Key]
		[DatabaseGenerated (DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[StringLength (50)]
		public string FirstName { get; set; }
		[Required]
		[StringLength (50)]
		public string LastName { get; set; }
		[StringLength (50)]
		public string MiddleName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Sex Sex { get; set; }
		[StringLength (50)]
		public string Country { get; set; }
	}
}
