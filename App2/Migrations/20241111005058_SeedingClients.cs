using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace App2.Migrations
{
    /// <inheritdoc />
    public partial class SeedingClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] {"Prenom", "Nom", "EstClientRegulier", "DateCreation", "TartePreferee"},
                values: new object[,]
                {
                    { "Alain", "Ternette",true, new DateOnly(1970,12,14), "Farlouche"},
                    { "Cécile", "Encieux",false, new DateOnly(1985,11,25), "Fraises"},
                    { "Justin", "Petitpeux",true, new DateOnly(1999,08,07), "Sucre"}
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Clients", true);
        }
    }
}
