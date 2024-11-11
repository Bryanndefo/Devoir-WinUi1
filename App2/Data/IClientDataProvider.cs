using App2.Models;
using System.Collections.Generic;

namespace App2.Data;

public interface IClientDataProvider
{
    List<Client> GetClients();
    void AjoutClient(Client client);
    void RetirerClient(Client client);
}

