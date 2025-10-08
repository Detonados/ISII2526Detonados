using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppForSEII2526.API.Models;

namespace AppForSEII2526.API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<Repair> Repairs { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<RentDevice> RentDevices { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<ReceiptItem> ReceiptItems { get; set; }
    public DbSet<PurchaseItem> PurchaseItems { get; set; }
    public DbSet<ReviewItem> ReviewItems { get; set; }
    public DbSet<Scale> Scales { get; set; }
   
    // Agrega aquí cualquier otro DbSet relevante de tus modelos
}
