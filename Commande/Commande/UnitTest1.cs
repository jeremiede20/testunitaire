using GestionCommande.controleur;
using GestionCommande.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.Test
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void TestAjoutClient()
        {
            CommandeControleur ctrl = new CommandeControleur();

            //initilisation d'un client
            Client c = new Client();
            c.Nom = "Tourman";
            c.Prenom = "Benjamin";
            c.Mail = "produjava44@gmail.com";

            ctrl.CreerClient(c);
            
            Assert.AreEqual("Benjamin", ctrl.GetClients().Last().Prenom);
        }
    }
}