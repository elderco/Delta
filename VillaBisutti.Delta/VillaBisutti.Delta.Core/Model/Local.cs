using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	//TODO: Criar Data, ServiceModel e ServiceInterface deste model (André)
	//TODO: Criar Tela de cadastro de locais (André)
	public class Local : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome da Casa"), Required]
		public string NomeCasa { get; set; }
		[Display(Name = "Sigla da Casa")]
		public string SiglaCasa { get; set; }
		[Display(Name = "Endereço da Casa")]
		public string EnderecoCasa { get; set; }
	}
}
