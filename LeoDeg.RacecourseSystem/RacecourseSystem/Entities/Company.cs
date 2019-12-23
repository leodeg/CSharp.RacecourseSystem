using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public class Company : ID
	{
		[Key]
		[DatabaseGenerated (DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[StringLength (100)]
		public string Name { get; set; }
		[StringLength (50)]
		public string Country { get; set; }
		public int HorseAmount { get; set; }
		[StringLength (255)]
		public string AdditionalInfo { get; set; }
	}
}
