using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Evento : IEntityBase
	{
		public int Id { get; set; }
		public int TipoEventoId { get; set; }
		public int LocalId { get; set; }
		public Local Local { get; set; }
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
		public string NomeContratante { get; set; }
		public string CPFContratante { get; set; }
		public string EmailContato { get; set; }
		public string TelefoneContato { get; set; }
		public string NomeHomenageado { get; set; }
		public string PerfilHomenageado { get; set; }
		public DateTime DataEvento { get; set; }
		public int HorarioEvento { get; set; }
		public Horario Horario { get; set; }
		public int Pax { get; set; }
		public int LayoutId { get; set; }
		public Foto Layout { get; set; }
		public int ProdutoraId { get; set; }
		public Usuario Produtora { get; set; }
		public int PosVendedoraId { get; set; }
		public Usuario PosVendedora { get; set; }
	}
}
