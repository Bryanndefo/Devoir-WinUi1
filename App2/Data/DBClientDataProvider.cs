using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Data
{
    internal class DBClientDataProvider : IClientDataProvider
    {
        public void AjoutClient(Client client)
        {
            using SQLiteContext context = new SQLiteContext();
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public List<Client> GetClients()
        {
            //permet de fermer la ressource apres les instructions
            using SQLiteContext context = new SQLiteContext();
            //Lire les données et transformer en liste
            List<Client> clients = 
                context.Clients
                .OrderBy(c => c.Nom)
                .ThenBy(c => c.Prenom)
                //.Where(c => c.EstClientRegulier == true)
                .ToList();
            return clients;
        }

        public void RetirerClient(Client client)
        {
            using SQLiteContext context = new SQLiteContext();
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}
