using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.Automation.ContratacaoServicoTerceiro
{
    public class WacherContratacaoServicoTerceiro
    {
        public void EmailContratacaoServicoTerceiro()
        {
            List<model.Evento> eventos = new data.Evento().GetEventosServicoTerceiroRobo();

            //contratação responsa da bisutti = true
            //fornecedor bisutti = false
            //definidos = true
            //contratato = false
            //
        }
    }
}
