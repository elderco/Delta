using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public enum TipoAcesso
	{
		[Description("Produção")]
		Producao = 1,
		Assistente = 2,
		Planejamento = 3,
		DJ = 4,
		[Description("Decoração")]
		Decoracao = 5,
		Metria = 6,
		[Description("A&B")]
		AeB = 7
	}
}
