using Microsoft.EntityFrameworkCore;
using ProjectAuction.API.Entities;

namespace ProjectAuction.API.Repositories;

public class ProjectAuctionDbContext : DbContext
{
    public ProjectAuctionDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
