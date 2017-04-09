using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Apparatenbeheer.Business;
using Apparatenbeheer.Definitions.Gebruikers;
using Apparatenbeheer.Definitions.Apparaten;

namespace Apparatenbeheer.UnitTest {

	[TestClass]
	public class ApparatenbeheerTest {

		[TestMethod]
		public void TestLogin1() {

			Controller controller = new Controller();

			bool result = controller.Login("Joh_Poo", "JP456") != null;

			Assert.AreEqual(true, result);

		}

        [TestMethod]
        public void TestAanvragen() {

            Controller controller = new Controller();

            controller.Login("Joh_Poo", "JP456");
            List<Aanvraag> aanvragen = controller.GetAanvragen();

            controller.AanvraagToewijzen(aanvragen[0], "Joh_Poo");

            Assert.AreEqual(aanvragen[0].Verantwoordelijke.Username, "Joh_Poo");

            controller.AcceptAanvraag(aanvragen[0], "Test");
            aanvragen = controller.GetAanvragen();

            Assert.AreEqual(aanvragen[0].Commentaar, "Joh_Poo - Accepted: Test");

            controller.Login("Sam_Pee", "SP123");
            decimal waarde = controller.GetTotaleWaarde();

            Assert.AreEqual(waarde, 800.0m);

        }

    }

}
