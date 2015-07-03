using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public enum LocalCerimonia
	{
		[Description("No Local")]
		Local = 0,
		[Description("No Anexo")]
		Anexo = 1,
		[Description("Cerimônia Externa")]
		Externo = 2,
		[Description("Não Possui Cerimônia")]
		NaoPossui = 3
	}
}
