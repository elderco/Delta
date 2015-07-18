﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemDecoracaoCerimonial : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Item"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade"), Range(0, 9 * 10E6)]
		public int Quantidade { get; set; }
		public int TipoItemDecoracaoCerimonialId { get; set; }
		[Display(Name = "Tipo")]
		public TipoItemDecoracao TipoItemDecoracaoCerimonial { get; set; }
	}
}