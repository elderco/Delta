using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Shared
{
	public static class Properties
	{
		private static Data.Context _context;
		private static Data.Context context
		{
			get
			{
				if (_context == null)
					_context = new Data.Context();
				return _context;
			}
		}

	}
}
