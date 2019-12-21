using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	public class ContestParticipant : ID
	{
		[Required, Key, DatabaseGenerated (DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public Contest Contest { get; set; }
		[Required]
		public Horse Horse { get; set; }
		[Required]
		public Participant Jockey { get; set; }
	}
}
