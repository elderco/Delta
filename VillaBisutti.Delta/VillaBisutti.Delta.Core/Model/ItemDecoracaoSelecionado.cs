﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemDecoracaoSelecionado : IEntityBase
	{
		public int Id { get; set; }
		public int EventoId { get; set; }
		[Display(Name = "Decoração"), ForeignKey("EventoId")]
		public Decoracao Decoracao { get; set; }
		public int ContratoAditivoId { get; set; }
		[Display(Name = "Contrato Aditivo")]
		public ContratoAditivo ContratoAditivo { get; set; }
		public int ItemDecoracaoId { get; set; }
		[Display(Name = "Decoração")]
		public ItemDecoracao ItemDecoracao { get; set; }
		[Display(Name = "Definido")]
		public bool Definido { get; set; }
		[Display(Name = "Contratado")]
		public bool Contratado { get; set; }
		[Display(Name = "Responsabilidade da Villa Bisutti (contratar)")]
		public bool ContratacaoBisutti { get; set; }
		[Display(Name = "Fornecido pela Villa Bisutti")]
		public bool FornecimentoBisutti { get; set; }
		[Display(Name = "Fornecedor Acionado")]
        public bool FornecedorStartado { get; set; }
		[Display(Name = "Quantidade"), Range(0, 9*10E6)]
		public int Quantidade { get; set; }
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
		[Display(Name = "Contato do Fornecedor")]
		public string ContatoFornecimento { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
		[Display(Name = "Fotos")]
		public List<Foto> Fotos { get; set; }
		[NotMapped]
		public bool StateErrorBisutti
		{
			get
			{
				return (
					(ItemDecoracao != null && (new Business.ItemDecoracao().GetQuantidadeItens(ItemDecoracaoId) < Quantidade))
					);
			}
		}
		[NotMapped]
		public bool StateErrorContratante
		{
			get
			{
				return (ContatoFornecimento == null || ContatoFornecimento == string.Empty)
					|| (HorarioMontagem == 0); ;
			}
		}
		[NotMapped]
		public bool StateErrorFornecedor
		{
			get
			{
				return (ContratacaoBisutti && !FornecimentoBisutti && (!Definido || !FornecedorStartado || !Contratado));
			}
		}
	}
}
