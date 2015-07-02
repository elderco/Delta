using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	//TODO: Criar modelo da classe para implementação (Velho)
	public class ContratoAditivo : IEntityBase
	{
		public int Id { get; set; }
		public string Arquivo { get; set; }
		public string NumeroContrato { get; set; }
		public DateTime DataContrato { get; set; }
	}
}
