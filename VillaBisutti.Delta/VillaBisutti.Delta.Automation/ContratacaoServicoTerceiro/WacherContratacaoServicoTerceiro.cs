using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using VillaBisutti.Delta.Core.DTO;

namespace VillaBisutti.Delta.Automation.ContratacaoServicoTerceiro
{
    public class WacherContratacaoServicoTerceiro
    {
        public void EmailContratacaoServicoTerceiro()
        {
			List<model.ItemDecoracaoCerimonialSelecionado> itemDecoracao = ItemEvento.GetItemDecoracaoCerimonial();
			List<model.ItemMontagemSelecionado> itemMontagem = ItemEvento.GetItemMontagem();
			List<model.ItemBebidaSelecionado> itemBebida = ItemEvento.GetItemBebida();
			List<model.ItemBoloDoceBemCasadoSelecionado> itemBoloDoceBemCasado = ItemEvento.GetItemBoloDoceBemCasado();
			List<model.ItemFotoVideoSelecionado> itemFotoVideo = ItemEvento.GetItemFotoVideo();
			List<model.ItemSomIluminacaoSelecionado> itemSomIluminacao = ItemEvento.GetItemSomIluminacao();

               

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
