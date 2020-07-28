using DemoProject.Application.Common.Interfaces;
using System;

namespace DemoProject.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
