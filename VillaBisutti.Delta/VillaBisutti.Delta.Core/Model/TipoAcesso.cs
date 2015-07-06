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
		Producao = 0,
		[Display(Name = "Pós-venda")]
		Posvenda = 1,
		[Display(Name = "Assistente")]
		Assistente = 2,
		[Display(Name = "Planejamento")]
		Planejamento = 3,
		[Display(Name = "DJ")]
		DJ = 4,
		[Display(Name = "Decoração")]
		Decoracao = 5,
		[Display(Name = "Metria")]
		Metria = 6,
		[Display(Name = "A&B")]
		AeB = 7
	}
}
