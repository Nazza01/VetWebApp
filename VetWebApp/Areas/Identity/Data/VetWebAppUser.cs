using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VetWebApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the VetWebAppUser class
public class VetWebAppUser : IdentityUser
{
    [PersonalData]
    public string ? FirstName { get; set; }

    [PersonalData]
    public string ? LastName { get; set; }

    [PersonalData]
    public string ? Suburb { get; set; }

    [PersonalData]
    public int ? Postcode { get; set; }

    [PersonalData]
    public string ? PetName { get; set; }

    [PersonalData]
    public string ? PetBreed { get; set; }

    [PersonalData]
    public string ? PetAge { get; set; }

    [PersonalData]
    public string? PetGender { get; set;  }

    [PersonalData]
    public string ? PetImage { get; set; }
}

