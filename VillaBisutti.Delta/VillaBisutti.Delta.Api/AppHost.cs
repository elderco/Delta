using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VillaBisutti.Delta.ServiceInterface;

namespace VillaBisutti.Delta.Api
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("VillaBisutti.Delta.Api", typeof(Class1).Assembly)
        {

        }

        public override void Configure(Funq.Container container)
        {
            throw new NotImplementedException();
        }
    }
}