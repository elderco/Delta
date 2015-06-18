using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public enum LocalCerimonia
	{
		Local = 0,
		Anexo = 1,
		Externo = 2,
		[("Não Possui Cerimonial")]
		NaoPossui = 3
	}
}
