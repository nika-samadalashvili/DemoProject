using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Application.Common.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }

        public TimeSpan TokenLifetime { get; set; }
    }
}
