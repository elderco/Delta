using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemSomIluminacaoSelecionado : IEntityBase
	{
		public int Id { get; set; }
		public int EventoId { get; set; }
		public Evento Evento { get; set; }
		public int ContratoAditivoId { get; set; }
		public ContratoAditivo ContratoAditivo { get; set; }
		public int ItemSomIId { get; set; }
		public ItemBebida ItemBebida { get; set; }

		public bool Definido { get; set; }
		public bool Contratado { get; set; }
		public bool ContratacaoBisutti { get; set; }
		public bool FornecimentoBisutti { get; set; }
		public int Quantidade { get; set; }
		public int HorarioMontagem { get; set; }
		public string ContatoFornecimento { get; set; }

		public string Observacoes { get; set; }
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
