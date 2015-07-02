using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class BoloDoceBemCasado : IEntityBase
	{
		public int Id { get; set; }
		[Key, ForeignKey("Evento")]
		public int EventoId { get; set; }
		[Display(Name = "Evento"), Required]
		public Evento Evento { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
		[Display(Name = "Itens")]
		public List<ItemBoloDoceBemCasadoSelecionado> Itens { get; set; }
		[Display(Name = "Fotos")]
		public List<Foto> Fotos { get; set; }

	}
}
