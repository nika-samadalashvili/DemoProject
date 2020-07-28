using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace DemoProject.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
