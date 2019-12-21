using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public class Contest : ID
	{
		[Key]
		[DatabaseGenerated (DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required, StringLength (80)]
		public string Title { get; set; }
		[StringLength (50)]
		public string HorsesBreed { get; set; }
		public int HorseAge { get; set; }
		public long PrizePool { get; set; }
		[Required]
		public DateTime DateTime { get; set; }
	}
}
