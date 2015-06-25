﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta
{
	public static class Util
	{
		public static string GetDescription(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DescriptionAttribute attribute =
				(DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
			return attribute == null ? value.ToString() : attribute.Description;
		}
	}
}
