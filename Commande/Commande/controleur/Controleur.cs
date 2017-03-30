using GestionCommande.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.controleur
{
    public interface Controleur
    {

        void CreerCommande(Client client, ICollection<LigneCommande> ligneCmd);
        void CreerClient(string n, string p, string m, ICollection<Commande> Commandes);
        void CreerProduit(string designation, int prix);

        ICollection<Client> GetClients();

        ICollection<Produit> GetProduits();

        ICollection<Commande> GetCommandes();
    }
}
