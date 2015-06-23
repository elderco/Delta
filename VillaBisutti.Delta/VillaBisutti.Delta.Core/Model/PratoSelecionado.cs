using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class PratoSelecionado : IEntityBase
	{
		public int Id { get; set; }
		public int PratoId { get; set; }
		public Prato Prato { get; set; }
		public int EventoId { get; set; }
		public Evento Evento { get; set; }
		public string Observacoes { get; set; }
	}
}
