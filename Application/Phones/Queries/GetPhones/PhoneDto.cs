using System;
using System.Collections.Generic;
using System.Text;
using DemoProject.Application.Common.Mappings;
using DemoProject.Domain.Entities;

namespace DemoProject.Application.Phones.Queries.GetPhones
{
    public class PhoneDto : IMapFrom<Phone>
    {
        public string PhoneNumber { get; set; }
    }
}
