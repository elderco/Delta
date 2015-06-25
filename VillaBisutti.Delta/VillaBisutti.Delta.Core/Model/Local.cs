using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	//TODO: Criar Data, ServiceModel e ServiceInterface deste model (André)
	//TODO: Criar Tela de cadastro de locais (André)
	public class Local : IEntityBase
	{
		public int Id { get; set; }
		public string NomeCasa { get; set; }
		public string SiglaCasa { get; set; }
		public string EnderecoCasa { get; set; }
	}
}
