using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Domain.Entities
{
    public class Phone
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
