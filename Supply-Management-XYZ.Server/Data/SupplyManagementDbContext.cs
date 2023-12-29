using Microsoft.EntityFrameworkCore;
using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Data;

public class SupplyManagementDbContext : DbContext
{
    public SupplyManagementDbContext(DbContextOptions<SupplyManagementDbContext> options) : base(options) { }

    //Tables
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<AccountVendor> AccountVendors { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Vendor> Vendors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Contraints Unique
        modelBuilder.Entity<Employee>()
            .HasIndex(e => new
            {
                e.Email
            }).IsUnique();

        modelBuilder.Entity<Vendor>()
            .HasIndex(v => new
            {
                v.Email,
                v.PhoneNumber
            }).IsUnique();

        // Account - AccountRole (One to Many)
        modelBuilder.Entity<Account>()
            .HasMany(account => account.AccountRoles)
            .WithOne(accountRole => accountRole.Account)
            .HasForeignKey(accountRole => accountRole.AccountGuid);

        // Account - Employee (One to One)
        modelBuilder.Entity<Account>()
            .HasOne(account => account.Employee)
            .WithOne(employee => employee.Account)
            .HasForeignKey<Account>(account => account.Guid);

        // Account Vendor - Vendor (One to One)
        modelBuilder.Entity<AccountVendor>()
            .HasOne(accountVendor => accountVendor.Vendor)
            .WithOne(Vendor => Vendor.AccountVendor)
            .HasForeignKey<AccountVendor>(accountVendor => accountVendor.Guid);

        // Role - AccountRole (One to Many)
        modelBuilder.Entity<Role>()
            .HasMany(role => role.AccountRoles)
            .WithOne(accountRole => accountRole.Role)
            .HasForeignKey(accountRole => accountRole.RoleGuid);

        // Vendor - Project (One to Many)
        modelBuilder.Entity<Vendor>()
            .HasMany(vendor => vendor.Projects)
            .WithOne(project => project.Vendor)
            .HasForeignKey(project => project.VendorGuid);
    }
}
