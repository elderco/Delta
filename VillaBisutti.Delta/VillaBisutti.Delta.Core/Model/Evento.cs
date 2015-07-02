using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Evento : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Tipo de Evento"), Required]
		public TipoEvento TipoEvento { get; set; }
		
		public int LocalId { get; set; }
		[Display(Name = "Local")]
		public Local Local { get; set; }
		[Display(Name = "Data")]
		//Dados do evento
		public DateTime Data { get; set; }
		[Display(Name = "Horário Inicio")]
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
		[Display(Name = "Horário Termino")]
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

		[Display(Name = "Pax?????")]
		public int Pax { get; set; }
		public int PaxAproximado
		{
			get
			{
				return (int)(Pax * 1.1);
			}
		}


		//Dados do contratante
		[Display(Name = "Nome do Responsável")]
		public string NomeResponsavel { get; set; }
		[Display(Name = "CPF do Responsável")]
		public string CPFResponsavel { get; set; }
		[Display(Name = "Email de Contato")]
		public string EmailContato { get; set; }
		[Display(Name = "Telefone de Contato")]
		public string TelefoneContato { get; set; }
		[Display(Name = "Nomes dos Homenageados")]
		public string NomeHomenageados { get; set; }
		[Display(Name = "Perfil da Festa")]
		public string PerfilFesta { get; set; }
		public int? ProdutoraId { get; set; }
		[Display(Name = "Nome da Produtora")]
		public Usuario Produtora { get; set; }
		public int? PosVendedoraId { get; set; }
		[Display(Name = "Pós Vendedora")]
		public Usuario PosVendedora { get; set; }
		[Display(Name = "Local da Cerimonia")]
		public LocalCerimonia LocalCerimonia { get; set; }
		[Display(Name = "Endereço da Cerimonia")]
		public string EnderecoCerimonia { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
		public int CardapioId { get; set; }
		[Display(Name = "Cardápio")]
		public Cardapio Cardapio { get; set; }
		[Display(Name = "Email de Boas Vindas Enviado")]
		public bool EmailBoasVindasEnviado { get; set; }
		[Display(Name = "OS-Finalizada")]
		public bool OSFinalizada { get; set; }
		[Display(Name = "Tipo de Servico")]
		public TipoServico TipoServico { get; set; }
		[Display(Name = "Layout")]
		public Foto Layout { get; set; }
		[Display(Name = "Contratos")]
		public List<ContratoAditivo> Contratos { get; set; }
		[InverseProperty("Evento"), Display(Name = "Bebida")]
		public Bebida Bebida { get; set; }
		[InverseProperty("Evento"), Display(Name = "Bolo e Doces")]
		public BoloDoceBemCasado BoloDoceBemCasado { get; set; }
		[InverseProperty("Evento"), Display(Name = "Decoração")]
		public Decoracao Decoracao { get; set; }
		[InverseProperty("Evento"), Display(Name = "Foto & Video")]
		public FotoVideo FotoVideo { get; set; }
		[InverseProperty("Evento"), Display(Name = "Montagem")]
		public Montagem Montagem { get; set; }
		[InverseProperty("Evento"), Display(Name = "Outros Itens")]
		public OutrosItens OutrosItens { get; set; }
		[InverseProperty("Evento"), Display(Name = "Som & Iluminacao")]
		public SomIluminacao SomIluminacao { get; set; }
		[Display(Name = "Roteiro")]
		public List<ItemRoteiro> Roteiro { get; set; }
		[Display(Name = "Cerimonial")]
		public List<ItemCerimonial> Cerimonial { get; set; }


	}
}
