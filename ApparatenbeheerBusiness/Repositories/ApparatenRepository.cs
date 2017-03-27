using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apparatenbeheer.Definitions.Apparaten;

namespace Apparatenbeheer.Business.Repositories {

	internal class ApparaatRepository : List<Apparaat> {

		private static ApparaatRepository _instance;
		private ApparaatRepository() : base() { }

		public static ApparaatRepository GetInstance()
			=> _instance ?? (_instance = new ApparaatRepository());

	}

}
