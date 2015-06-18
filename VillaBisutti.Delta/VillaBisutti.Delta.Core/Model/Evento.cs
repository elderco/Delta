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
		public int LocalId { get; set; }
		public Local Local { get; set; }
		public DateTime Data { get; set; }
		public int HorarioInicio { get; set; }
		public Horario Inicio
		{
			get
			{
				return Horario.Parse(HorarioInicio);
			}
			set
			{
				HorarioInicio = value.ToInt();
			}
		}
		public int HorarioTermino { get; set; }
		public Horario Termino
		{
			get
			{
				return Horario.Parse(HorarioTermino);
			}
			set
			{
				HorarioTermino = value.ToInt();
			}
		}
		public int Pax { get; set; }
		public int PaxAproximado
		{
			get
			{
				return (int)(Pax * 1.1);
			}
		}
		public string NomeResponsavel { get; set; }
		public string CPFResponsavel { get; set; }
		public string EmailContato { get; set; }
		public string TelefoneContato { get; set; }
		public string NomeHomenageados { get; set; }
		public string PerfilFesta { get; set; }
		public int ProdutoraId { get; set; }
		public Usuario Produtora { get; set; }
		public int PosVendedoraId { get; set; }
		public Usuario PosVendedora { get; set; }
		public int LocalCerimoniaId { get; set; }
		public LocalCerimonia LocalCerimonia
		{
			get
			{
				return (LocalCerimonia)LocalCerimoniaId;
			}
			set
			{
				LocalCerimoniaId = (int)value;
			}
		}
		public string EnderecoCerimonia { get; set; }
		public string Observacoes { get; set; }
		public Foto Layout { get; set; }
		public List<ContratoAditivo> Contratos { get; set; }
	}
}
