using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ContratoAditivo : IEntityBase
	{
		public int Id { get; set; }
		public int TipoEventoId { get; set; }
		public TipoEvento TipoEvento
		{
			get
			{
				return (TipoEvento)TipoEventoId;
			}
			set
			{
				TipoEventoId = (int)value;
			}
		}
	}
}
