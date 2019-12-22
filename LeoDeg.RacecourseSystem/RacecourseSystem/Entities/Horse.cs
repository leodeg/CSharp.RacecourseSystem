using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacecourseSystem
{
	[Table (name: "Horses")]
	public class Horse : ID
	{
		[DatabaseGenerated (DatabaseGeneratedOption.Identity)]
		[Required]
		[Key]
		public int Id { get; set; }

		public HorseFactory HorseFactory { get; set; }
		public Trainer Trainer { get; set; }
		public HorseOwner Owner { get; set; }

		[Required, StringLength (100)]
		public string Name { get; set; }

		[StringLength (50)]
		public string Breed { get; set; }

		[StringLength (50)]
		public string Color { get; set; }

		public DateTime DateOfBirth { get; set; }

		public Sex Sex { get; set; }

		[StringLength (50)]
		public string Country { get; set; }

		[StringLength (255)]
		public string AdditionalInfo { get; set; }
	}
}
