using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemDecoracaoCerimonialSelecionado : IEntityBase
	{
		public int Id { get; set; }
		public int EventoId { get; set; }
		[Display(Name = "Evento")]
		public Evento Evento { get; set; }
		public int ContratoAditivoId { get; set; }
		[Display(Name = "Contrato Aditivo")]
		public ContratoAditivo ContratoAditivo { get; set; }
		public int ItemDecoracaoCerimonialId { get; set; }
		[Display(Name = "Item Decoração")]
		public ItemDecoracaoCerimonial ItemDecoracaoCerimonial { get; set; }
		[Display(Name = "Definido")]
		public bool Definido { get; set; }
		[Display(Name = "Responsabilidade da Villa Bisutti (contratar)")]
		public bool ContratacaoBisutti { get; set; }
		[Display(Name = "Fornecido pela Villa Bisutti")]
		public bool FornecimentoBisutti { get; set; }
		[Display(Name = "Contratado")]
		public bool Contratado { get; set; }
		[Display(Name = "Fornecedor Iniciado")]
		public bool FornecedorStartado { get; set; }
		[Display(Name = "Quantidade"), Range(0, 9 * 10E6)]
		public int Quantidade { get; set; }
		[Display(Name = "Contato Fornecimento")]
		public string ContatoFornecimento { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
		[Display(Name = "Horário Montagem")]
		public int HorarioMontagem { get; set; }
		[NotMapped]
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