using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public enum TipoEvento
	{
		[Description("Aniversário")]
		Aniversario = 0,
		Barmitzva = 1,
		Batmitzva = 2,
		Casamento = 3,
		Corporativo = 4,
		Debutante = 5,
		Outro = 6 
	}
}
