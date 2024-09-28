using System;
using Microsoft.EntityFrameworkCore;
using running_apps.Models;

namespace running_apps.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }
    public DbSet<Race> Races { get; set; }
    public DbSet<Club> Clubs { get; set; }

    public DbSet<AppUser> AppUsers { get; set; }

    public DbSet<Address> Addresses { get; set; }

}
