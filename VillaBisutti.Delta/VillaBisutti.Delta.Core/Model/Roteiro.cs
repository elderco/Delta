using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Roteiro : IEntityBase
	{
		public int Id { get; set; }
		[Key, ForeignKey("Evento")]
		public int EventoId { get; set; }
		public Evento Evento { get; set; }
		public List<ItemRoteiro> Acontecimentos { get; set; }
	}
}
