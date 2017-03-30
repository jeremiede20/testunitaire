using GestionCommande.dao;
using GestionCommande.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.controleur
{
    class CommandeControleur:Controleur
    {
        private ClientDao ClientDao { get; }
        private ProduitDao ProduitDao { get; }
        private CommandeDao CommandeDao { get; }

        public CommandeControleur()
        {
            this.ClientDao = new ClientDao();
            this.ProduitDao = new ProduitDao();
            this.CommandeDao = new CommandeDao();
        }

        public void CreerClient(string name, string surname, string mail, ICollection<Commande> Commandes)

        {
            int id2 = ClientDao.Clients.Count + 1;

            ClientDao.Clients.Add(new Client() { Id = id2, Nom = name, Prenom = surname, Mail = mail, Commandes = new Collection<Commande>() });
        }

        public void CreerProduit(string nom, int prix)
        {
            int idproduit = ProduitDao.Produits.Count + 1;

            ProduitDao.Produits.Add(new Produit() { Id = idproduit, Designation = nom, Prix = prix });
        }

        public void CreerCommande(Client client,ICollection<LigneCommande> ligneCmd)
        {
            Commande cmd = new Commande { Id = CommandeDao.Commandes.Count + 1, Client = client, LignesCommande = ligneCmd };
            foreach (LigneCommande ligne in ligneCmd)
            {
                ligne.Commande = cmd;
            }
            client.Commandes.Add(cmd);
            CommandeDao.AjouterCommande(cmd);
        }

        public ICollection<Client>  GetClients()
        {
            return ClientDao.Clients;
        }

        public ICollection<Produit> GetProduits()
        {
            return ProduitDao.Produits;
        }

        public ICollection<Commande> GetCommandes()
        {
            return CommandeDao.Commandes;
        }
    }
}
