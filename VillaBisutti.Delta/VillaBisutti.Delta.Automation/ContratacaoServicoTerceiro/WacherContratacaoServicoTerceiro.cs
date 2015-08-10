using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.Automation.ContratacaoServicoTerceiro
{
    public class WacherContratacaoServicoTerceiro
    {
        public void EmailContratacaoServicoTerceiro()
        {
            List<model.Evento> eventos = Util.context.Evento
                .Include(e => e.DecoracaoCerimonial).Include(e => e.DecoracaoCerimonial.Itens)
                .Include(e => e.Montagem).Include(e => e.Montagem.Itens)
                .Include(e => e.Bebida).Include(e => e.Bebida.Itens)
                .Include(e => e.BoloDoceBemCasado).Include(e => e.BoloDoceBemCasado.Itens)
                .Include(e => e.FotoVideo).Include(e => e.FotoVideo.Itens)
                .Include(e => e.SomIluminacao).Include(e => e.SomIluminacao.Itens)
                .Include(e => e.OutrosItens).Include(e => e.OutrosItens.Itens)
                .ToList();
               

            //contratação responsa da bisutti = true
            //fornecedor bisutti = false
            //definidos = true
            //contratados = false
            //avisa uma pessoa espevifica q a bisuti precisa contratar sevicços que seraão disponibilizados no evento
            //o que a vila bi terceiriza

            //item ... selecionado
            
        }
    }
}
