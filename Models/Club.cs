using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using running_apps.Data.Enum;

namespace running_apps.Models;

public class Club
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    [ForeignKey("Address")]
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public ClubCategory ClubCategory { get; set; }
    [ForeignKey("AppUser")]
    public string? UserId { get; set; }
    public AppUser? AppUser { get; set; }
}
