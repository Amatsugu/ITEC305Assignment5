using Nancy.ViewEngines.Razor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noriko.Bootstrap
{
	public class RazorConfig : IRazorConfiguration
	{
		public IEnumerable<string> GetAssemblyNames()
		{
			return null;
		}

		public IEnumerable<string> GetDefaultNamespaces()
		{
			yield return "Maika";
			yield return "Maika.Models";
		}

		public bool AutoIncludeModelNamespace
		{
			get { return true; }
		}
	}
}
