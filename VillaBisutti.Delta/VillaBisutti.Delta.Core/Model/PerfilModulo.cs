using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class PerfilModulo : IEntityBase
	{
		public int Id { get; set; }
		public int ModuloId { get; set; }
		public Modulo Modulo { get; set; }
        public int PerfilId { get; set; }
		[Display(Name="Leitura")]
        public bool PodeLer { get; set; }
        [Display(Name = "Acesso Total")]
        public bool PodeAlterar { get; set; }
	}
}
