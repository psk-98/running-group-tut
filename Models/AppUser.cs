using System;
using Microsoft.AspNetCore.Identity;

namespace running_apps.Models;

public class AppUser : IdentityUser
{
    public int Pace { get; set; }
    public int? Distance { get; set; }
    public Address? Address { get; set; }
    public ICollection<Club> Clubs { get; set; }
    public ICollection<Race> Races { get; set; }
}
