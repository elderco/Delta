﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public enum TipoServico
	{
		Inglesa=0,
		[Display(Name = "Franco-Americano")]
		FrancoAmericano = 1,
		[Display(Name = "Menu-Degustação")]
		MenuDegustacao = 2
	}
}