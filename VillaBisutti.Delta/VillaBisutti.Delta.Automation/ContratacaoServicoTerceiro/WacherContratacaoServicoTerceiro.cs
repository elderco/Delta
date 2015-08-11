using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using VillaBisutti.Delta.Core.Business;

namespace VillaBisutti.Delta.Automation.ContratacaoServicoTerceiro
{
    public class WacherContratacaoServicoTerceiro
    {
        private const string EmailContratacaoTerceiro = "EmailContratacaoServicoTerceiro.txt";
        public void EmailContratacaoServicoTerceiro()
        {
            string message = Util.ReadFileEmail(EmailContratacaoTerceiro);
			List<model.ItemDecoracaoCerimonialSelecionado> itemDecoracaoCerimonial = ItemEvento.GetItemDecoracaoCerimonial();
			List<model.ItemMontagemSelecionado> itemMontagem = ItemEvento.GetItemMontagem();
			List<model.ItemBebidaSelecionado> itemBebida = ItemEvento.GetItemBebida();
			List<model.ItemBoloDoceBemCasadoSelecionado> itemBoloDoceBemCasado = ItemEvento.GetItemBoloDoceBemCasado();
			List<model.ItemFotoVideoSelecionado> itemFotoVideo = ItemEvento.GetItemFotoVideo();
			List<model.ItemSomIluminacaoSelecionado> itemSomIluminacao = ItemEvento.GetItemSomIluminacao();
            List<model.ItemDecoracaoSelecionado> itemDecoracao = ItemEvento.GetItemDecorao();
            List<model.ItemOutrosItensSelecionado> itemOutrosItens = ItemEvento.GetItemOutrosItens();

            foreach (model.ItemDecoracaoCerimonialSelecionado item in itemDecoracaoCerimonial)
            {
                message.Replace("{EVENTO}", item.DecoracaoCerimonial.Evento.TipoEvento.ToString())
                    .Replace("{DIA}", item.DecoracaoCerimonial.Evento.Data.ToString("dd/MM"))
                    .Replace("{ITEM}", item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Nome);
            }
            foreach (model.ItemMontagemSelecionado item in itemMontagem)
            {
                
            }
            foreach (model.ItemBebidaSelecionado item in itemBebida)
            {
               
            }
            foreach (model.ItemBoloDoceBemCasadoSelecionado item in itemBoloDoceBemCasado)
            {
                
            }
            foreach (model.ItemFotoVideoSelecionado item in itemFotoVideo)
            {
                
            }
            foreach (model.ItemSomIluminacaoSelecionado item in itemSomIluminacao)
            {
                
            }
            foreach (model.ItemDecoracaoSelecionado item in itemDecoracao)
            {

            }
            foreach (model.ItemOutrosItensSelecionado item in itemOutrosItens)
            {
                
            }
        }
    }
}
