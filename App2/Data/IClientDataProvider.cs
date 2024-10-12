using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Data;

public interface IClientDataProvider
{
    List<Client> GetClients();
}

