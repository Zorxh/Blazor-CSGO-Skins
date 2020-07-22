using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CSGOSkinsWeb.Database.Models.Profiles;
using Microsoft.AspNetCore.Identity;

namespace CSGOSkinsWeb.Database.Models
{
    public class AppUser : IdentityUser
    {
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; } = new Profile();
    }
}
