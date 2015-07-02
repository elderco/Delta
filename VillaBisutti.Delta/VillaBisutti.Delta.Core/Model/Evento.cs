﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Evento : IEntityBase
	{
		public int Id { get; set; }
		public TipoEvento TipoEvento { get; set; }
		
		public int LocalId { get; set; }
		public Local Local { get; set; }

		//Dados do evento
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


		//Dados do contratante
		public string NomeResponsavel { get; set; }
		public string CPFResponsavel { get; set; }
		public string EmailContato { get; set; }
		public string TelefoneContato { get; set; }
		public string NomeHomenageados { get; set; }
		public string PerfilFesta { get; set; }


		public int? ProdutoraId { get; set; }
		public Usuario Produtora { get; set; }
		public int? PosVendedoraId { get; set; }
		public Usuario PosVendedora { get; set; }


		public LocalCerimonia LocalCerimonia { get; set; }
		public string EnderecoCerimonia { get; set; }
		public string Observacoes { get; set; }


		public int CardapioId { get; set; }
		public Cardapio Cardapio { get; set; }

		public bool EmailBoasVindasEnviado { get; set; }
		public bool OSFinalizada { get; set; }

		public TipoServico TipoServico { get; set; }

		public Foto Layout { get; set; }
		
		public List<ContratoAditivo> Contratos { get; set; }
		[InverseProperty("Evento")]
		public Bebida Bebida { get; set; }
		[InverseProperty("Evento")]
		public BoloDoceBemCasado BoloDoceBemCasado { get; set; }
		[InverseProperty("Evento")]
		public Decoracao Decoracao { get; set; }
		[InverseProperty("Evento")]
		public FotoVideo FotoVideo { get; set; }
		[InverseProperty("Evento")]
		public Montagem Montagem { get; set; }
		[InverseProperty("Evento")]
		public OutrosItens OutrosItens { get; set; }
		[InverseProperty("Evento")]
		public SomIluminacao SomIluminacao { get; set; }
		public List<ItemRoteiro> Roteiro { get; set; }
		public List<ItemCerimonial> Cerimonial { get; set; }


	}
}
