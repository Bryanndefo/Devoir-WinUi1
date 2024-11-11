using App2.Models;
using System;
using System.Collections.Generic;

namespace App2.Data
{
    public class ClientDataProvider : IClientDataProvider
    {
        public void AjoutClient(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client(12345, "Alain", "Ternette", true, new DateOnly(1970,12,14)),
                new Client(23456, "Cécile", "Encieux", true, new DateOnly(1982,1,25), "Fraises"),
                new Client(34567, "Justin", "Petitpeux", false, new DateOnly(2022,7,2), "Fraises")
            };
        }

        public void RetirerClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
