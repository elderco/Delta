using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.DTO
{
	public class ItemEvento
	{
		public int Ordem { get; set; }
		public string Texto { get; set; }
		public int Quantidade { get; set; }
		public List<SubItemEvento> SubItens { get; set; }
	}
	public class SubItemEvento
	{
		public string NomeItem { get; set; }
		public int QuantidadeItem { get; set; }
		public bool BloqueiaOutrasPropriedades { get; set; }
		public bool Responsabilidade { get; set; }
		public bool Fornecido { get; set; }
		public string Observacao { get; set; }
		public string ContatoFornecedor { get; set; }
		public int HorarioEntrega { get; set; }
	}
	public class ItemRoteiroEvento
	{
		public string Acontecimento { get; set; }
		public string Observacoes { get; set; }
		public Model.Horario Horario { get; set; }
		public bool Importante { get; set; }
	}
}
