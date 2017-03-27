using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apparatenbeheer.Definitions.Apparaten;

namespace Apparatenbeheer.Business.Repositories {
    internal class AanvraagRepository : List<Aanvraag> {

        private static AanvraagRepository _instance;
        private AanvraagRepository() : base() { }

        public static AanvraagRepository GetInstance()
            => _instance ?? (_instance = new AanvraagRepository());

    }
}
