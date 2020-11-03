using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace TwitterProject.ApplicationLayer.Models.DTOs
{
    public class ExternalLoginDto
    {
        public string UserName { get; set; }
        public int Name { get; set; }
        public string Email { get; set; }
        public ClaimsPrincipal Principal { get; set; }

    }
}
