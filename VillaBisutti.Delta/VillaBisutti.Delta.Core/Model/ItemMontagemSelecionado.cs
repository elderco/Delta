using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemMontagemSelecionado : IEntityBase
	{
		public int Id { get; set; }
		public int EventoId { get; set; }
		[Display(Name = "Evento")]
		public Evento Evento { get; set; }
		public int ContratoAditivoId { get; set; }
		[Display(Name = "Contrato Aditivo")]
		public ContratoAditivo ContratoAditivo { get; set; }
		public int ItemMontagemId { get; set; }
		[Display(Name = "Montagem")]
		public ItemMontagem ItemMontagem { get; set; }
		[Display(Name = "Definido")]
		public bool Definido { get; set; }
		[Display(Name = "Contratado")]
		public bool Contratado { get; set; }
		[Display(Name = "Contratacao Bisutti")]
		public bool ContratacaoBisutti { get; set; }
		[Display(Name = "Fornecimento Bisutti")]
		public bool FornecimentoBisutti { get; set; }
		[Display(Name = "Fornecedor Iniciado")]
        public bool FornecedorStartado { get; set; }
		[Display(Name = "Quantidade"), Range(0, 161)]
		public int Quantidade { get; set; }
		[Display(Name = "Contato Fornecedor")]
		public string ContatoFornecimento { get; set; }
		[Display(Name = "Observaçõess")]
		public string Observacoes { get; set; }
		[Display(Name = "Fotos")]
		public List<Foto> Fotos { get; set; }
		[Display(Name = "Horario de Entrega")]
		public int HorarioEntrega { get; set; }
		[NotMapped]
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