using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCommande.model;
using GestionCommande.dao;
using System.Collections.ObjectModel;

namespace GestionCommande.controleur
{
    public class SqlServerControleur : Controleur
    {
        private GestionCommandeContext ctx;
        public SqlServerControleur()
        {
            ctx = new GestionCommandeContext();
        }
        public void CreerCommande(Client client, ICollection<LigneCommande> ligneCmd)
        {
            Commande cmd = new Commande { Id = ctx.Commandes.Count() + 1, Client = client, LignesCommande = ligneCmd };
            foreach (LigneCommande ligne in ligneCmd)
            {
                ligne.Commande = cmd;
            }
            client.Commandes.Add(cmd);
            ctx.Commandes.Add(cmd);
            ctx.Entry(client).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public void CreerClient(string name, string surname, string mail, ICollection<Commande> Commandes)
        {
            ctx.Clients.Add(new Client() { Nom = name, Prenom = surname, Mail = mail, Commandes = new Collection<Commande>() });
        }

        public void CreerProduit(string nom, int prix)
        {
            ctx.Produits.Add(new Produit() { Designation = nom, Prix = prix });
        }

        public ICollection<Client> GetClients()
        {
            return ctx.Clients.ToList();
        }

        public ICollection<Commande> GetCommandes()
        {
            return ctx.Commandes.ToList();
        }

        public ICollection<Produit> GetProduits()
        {
            return ctx.Produits.ToList();
        }
    }
}
