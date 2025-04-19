using Microsoft.EntityFrameworkCore;
using ProjectAuction.API.Entities;

namespace ProjectAuction.API.Repositories;

public class ProjectAuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\cassa\\OneDrive\\Documentos\\C#\\ROCKET\\AuctionAPI\\leilaoDbNLW.db");
    }
}
