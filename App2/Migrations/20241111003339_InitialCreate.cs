﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    EstClientRegulier = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TartePreferee = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
