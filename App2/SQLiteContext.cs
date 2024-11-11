using System;
using System.Collections.Generic;
using System.Diagnostics;
using App2.Models;
using Microsoft.EntityFrameworkCore;

namespace App2;

public partial class SQLiteContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public SQLiteContext()
    {
    }

    public SQLiteContext(DbContextOptions<SQLiteContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder
        //Changer le chemin d'acces complet au changement de l'ordinateur
        .UseSqlite("Data Source=C:\\Users\\info1\\Source\\Repos\\Devoir-WinUi1\\App2\\Database.sqlite")
        .LogTo(
        // Indiquer la sortie utilisée
        delegate (string text) { Debug.WriteLine(text); },
        [DbLoggerCategory.Database.Command.Name],
        Microsoft.Extensions.Logging.LogLevel.Information
        ).EnableSensitiveDataLogging();
            

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
