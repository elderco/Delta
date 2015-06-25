using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public enum TipoEvento
	{
		[Display(Name = "Aniversário")]
		Aniversario = 0,
		[Display(Name = "Barmitzva")]
		Barmitzva = 1,
		[Display(Name = "Batmitzva")]
		Batmitzva = 2,
		[Display(Name = "Casamento")]
		Casamento = 3,
		[Display(Name = "Corporativo")]
		Corporativo = 4,
		[Display(Name = "Debutante")]
		Debutante = 5,
		[Display(Name = "Outro")]
		Outro = 6 
	}
}
