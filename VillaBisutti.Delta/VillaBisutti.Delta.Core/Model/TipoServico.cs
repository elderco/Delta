using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public enum TipoServico
	{
		[Display(Name = "À Inglesa")]
		Inglesa = 0,
		[Display(Name = "Franco-Americano")]
		FrancoAmericano = 1,
		[Display(Name = "À Francesa")]
		Francesa = 2,
		[Display(Name = "Serviço Volante")]
		Volante = 3,
		[Display(Name = "Serviço Buffet")]
		Buffet = 4,
		[Display(Name = "Serviço Mixto")]
		Mixto = 4,
		[Display(Name = "Outro tipo de serviço")]
		Outro = 5
	}
}
