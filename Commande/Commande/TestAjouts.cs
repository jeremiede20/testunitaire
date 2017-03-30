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
        /**
         *  Test unitaire de l'ajout d'un client
         * */
        [TestMethod]
        public void TestAjoutClient()
        {
            CommandeControleur ctrl = new CommandeControleur();

            Client c = new Client();
            c.Nom = "Tourman";
            c.Prenom = "Benjamin";
            c.Mail = "produjava44@gmail.com";
            c.Commandes = new List<Commande>();

            ctrl.CreerClient(c.Nom, c.Prenom, c.Mail, c.Commandes);
            Assert.AreEqual("Benjamin", ctrl.GetClients().Last().Prenom);
        }


        /**
         * Test unitaire d'ajout de produit
         * */
        [TestMethod]
        public void TestAjoutProduit()
        {
            CommandeControleur ctrl = new CommandeControleur();
            
            Produit p = new Produit();
            p.Designation = "String XL";
            p.Prix = 15;

            ctrl.CreerProduit(p.Designation,p.Prix);
            Assert.AreEqual("String XL", ctrl.GetProduits().Last().Designation);
        }




        // Test unitaire hors fonction à implémenter

        /**
         * Test unitaire de commande
         * */
        [TestMethod]
        public void TestCommande()
        {
            CommandeControleur ctrl = new CommandeControleur();

            Commande co = new Commande();
            co.Client = "Tony";
            co.LignesCommande = 3;



            ctrl.CreerCommande(co.Client,co.LignesCommande);
            Assert.AreEqual("Tony", ctrl.GetCommandes().Last().Client);
        }
    }
}