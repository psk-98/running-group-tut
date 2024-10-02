using System;
using running_apps.Data.Enum;

namespace running_apps.ViewModels;

public class CreateClubViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public IFormFile Image { get; set; }
    public string Description { get; set; }
    public int AddressId { get; set; }
    // public Address Address { get; set; }
    public ClubCategory ClubCategory { get; set; }
}
