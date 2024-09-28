using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace running_apps.Models;

public class Address
{
    [Key]
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
}
