using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Automation
{
	public static class Settings
	{
		public static int[] QuantidadesDiasAntesEvento 
		{ 
			get
			{
				return new int[] {17, 20, 30};
			}
		}
		public static int AcabouPrazoEvento
		{
			get
			{
				return 47;
			}
		}

		public static int EventosProximosDias
		{
			get
			{
				return 15;
			}
		}
		public static int EnviarEmailAposXDiasEvento 
		{
			get
			{
				return 30;
			}
		}

	}
}
