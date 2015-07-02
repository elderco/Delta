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
		//Dados do evento
		[Display(Name = "Data")]
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
		[Display(Name = "Pax (real)")]
		public int Pax { get; set; }
		public int PaxAproximado
		{
			get
			{
				return (int)(Pax * 1.1);
			}
		}
		public int CardapioId { get; set; }
		[Display(Name = "Cardápio")]
		public Cardapio Cardapio { get; set; }
		[Display(Name = "Tipo de Serviço")]
		public TipoServico TipoServico { get; set; }

		//Responsáveis
		public int? ProdutoraId { get; set; }
		[Display(Name = "Produtora")]
		public Usuario Produtora { get; set; }
		public int? PosVendedoraId { get; set; }
		[Display(Name = "Pós Vendedora")]
		public Usuario PosVendedora { get; set; }

		//Dados do contratante
		[Display(Name = "Nome do Responsável"), Required]
		public string NomeResponsavel { get; set; }
		[Display(Name = "CPF do Responsável"), Required]
		public string CPFResponsavel { get; set; }
		[Display(Name = "Email de Contato"), Required]
		public string EmailContato { get; set; }
		[Display(Name = "Telefone de Contato"), Required]
		public string TelefoneContato { get; set; }
		[Display(Name = "Nomes dos Homenageados"), Required]
		public string NomeHomenageados { get; set; }
		[Display(Name = "Perfil da Festa")]
		public string PerfilFesta { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
		[Display(Name = "Layout do salão")]
		public Foto Layout { get; set; }

		
		//Dados da cerimônia
		[Display(Name = "Cerimônia")]
		public LocalCerimonia LocalCerimonia { get; set; }
		[Display(Name = "Endereço da Cerimônia")]
		public string EnderecoCerimonia { get; set; }
		[Display(Name = "Observações da cerimônia")]
		public string ObservacoesCerimonia { get; set; }


		[Display(Name = "Email de Boas Vindas Enviado")]
		public bool EmailBoasVindasEnviado { get; set; }
		[Display(Name = "OS Finalizada")]
		public bool OSFinalizada { get; set; }


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
