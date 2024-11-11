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
        public List<Client> GetClients()
        {
            //permet de fermer la ressource apres les instructions
            using SQLiteContext context = new SQLiteContext();
            //Lire les données et transformer en liste
            List<Client> clients = context.Clients.ToList();
            return clients;
        }
    }
}
