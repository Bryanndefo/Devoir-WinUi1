using System;

namespace App2.Models
{
    public class Client
    {
        public int Id { get; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public bool EstClientRegulier { get; set; }
        public DateOnly DateCreation { get; }
        public string TartePreferee { get; set; }
        public Client(int id, string prenom = "Prénom", string nom = "Nom",
            bool estClientRegulier = false, DateOnly dateCreation = new DateOnly(), string tartePreferee = "Farlouche")
        {
            Id = id;
            Prenom = prenom;
            Nom = nom;
            EstClientRegulier = estClientRegulier;
            if (dateCreation > DateOnly.MinValue)
            {
                DateCreation = dateCreation;
            }
            else
            {
                DateCreation = DateOnly.FromDateTime(DateTime.Now);
            }

            TartePreferee = tartePreferee;
        }
    }
}
