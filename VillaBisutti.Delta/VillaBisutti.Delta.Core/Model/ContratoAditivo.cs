using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	//TODO: Criar modelo da classe para implementação (Velho)
	public class ContratoAditivo : IEntityBase
	{
		public int Id { get; set; }
		public int  EvtId { get; set; }
		[Display(Name = "Arquivo")]
		public string Arquivo { get; set; }
		[Display(Name = "Número do Contrato")]
		public string NumeroContrato { get; set; }
		[Display(Name = "Data do Contrato")]
		public DateTime DataContrato { get; set; }
	}
}
