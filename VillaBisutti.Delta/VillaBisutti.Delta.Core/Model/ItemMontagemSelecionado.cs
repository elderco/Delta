using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemMontagemSelecionado : IEntityBase
	{
		public int Id { get; set; }
		public int EventoId { get; set; }
		public Evento Evento { get; set; }
		public int ContratoAditivoId { get; set; }
		public ContratoAditivo ContratoAditivo { get; set; }
		public int ItemBebidaId { get; set; }
		public ItemBebida ItemBebida { get; set; }
		public bool Definido { get; set; }
		public bool Contratado { get; set; }
		public bool ContratacaoBisutti { get; set; }
		public bool FornecimentoBisutti { get; set; }
		public int Quantidade { get; set; }
		public int HorarioEntrega { get; set; }
		public string ContatoFornecimento { get; set; }
		public string Observacoes { get; set; }
		public List<Foto> Fotos { get; set; }
		public Horario Entrega
		{
			get
			{
				return Horario.Parse(HorarioEntrega);
			}
			set
			{
				HorarioEntrega = value.ToInt();
			}
		}
	}
}