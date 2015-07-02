using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
    public class OutrosItens : IEntityBase
    {
		public int Id { get; set; }
		[Key, ForeignKey("Evento")]
        public int EventoId { get; set; }
		[Display(Name = "Evento")]
        public Evento Evento { get; set; }
		[Display(Name = "Observacoes")]
        public string Observacoes { get; set; }
        public List<ItemOutrosItensSelecionado> Itens { get; set; }
		public List<Foto> Fotos { get; set; }
	}
}
