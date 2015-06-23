﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Foto : IEntityBase
	{
		/// <summary>
		/// no upload da imagem, adicionar o texto padrão na base da imagem
		/// literatura escrever na imagem:
		/// http://stackoverflow.com/questions/3580635/can-you-open-a-jpeg-add-text-and-resave-as-a-jpeg-in-net
		/// literatura redimensionar imagem:
		/// http://stackoverflow.com/questions/249587/high-quality-image-scaling-library
		/// </summary>
		public int Id { get; set; }
		public string URL { get; set; }
		public string Legenda { get; set; }
	}
}