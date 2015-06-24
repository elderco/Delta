using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public enum TipoAcesso
	{
		[Display(Name = "Produção")]
		Producao = 1,
		Assistente = 2,
		Planejamento = 3,
		DJ = 4,
		[Display(Name = "Decoração")]
		Decoracao = 5,
		Metria = 6,
		[Display(Name = "A&B")]
		AeB = 7
	}
}
