using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
    public class SomIluminacao 
    {
        [Key, ForeignKey("Evento")]
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public string CoresCerimonia { get; set; }
        public string Observacoes { get; set; }
        public List<ItemSomIluminacaoSelecionado> Itens { get; set; }

    }
}
