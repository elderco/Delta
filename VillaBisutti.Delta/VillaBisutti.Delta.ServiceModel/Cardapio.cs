using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel
{
    [Route("/cardapio/{Id}", "GET")]
    public class Get : IReturn<model.Cardapio>
    {
        public int Id { get; set; }
    }

    [Route("/cardapio/", "GET")]
    public class GetAll : IReturn<model.Cardapio>
    {

    }

}
