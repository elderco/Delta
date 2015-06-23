using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemDecoracaoSelecionado : IEntityBase
	{
		public int Id { get; set; }
		public int EventoId { get; set; }
		public Evento Evento { get; set; }
		public int ContratoAditivoId { get; set; }
		public ContratoAditivo ContratoAditivo { get; set; }
		public int ItemDecoracaoId { get; set; }
		public ItemDecoracao ItemDecoracao { get; set; }
		public bool Definido { get; set; }
		public bool FornecimentoBisutti { get; set; }
		public bool ContratacaoBisutti { get; set; }
		public bool Contratado { get; set; }
		public int Quantidade { get; set; }
		public string ContatoFornecimento { get; set; }
		public string Observacoes { get; set; }
		public List<Foto> Fotos { get; set; }
		public int HorarioMontagem { get; set; }
		public Horario Montagem
		{
			get
			{
				return Horario.Parse(HorarioMontagem);
			}
			set
			{
				HorarioMontagem = value.ToInt();
			}
		}
	}
}
