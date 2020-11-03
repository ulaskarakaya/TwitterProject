using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace TwitterProject.ApplicationLayer.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return (Convert.ToInt32(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
        public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.Email);
        }
        public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.Name);
        }
        public static bool IsCurrentUser(this ClaimsPrincipal claimsPrincipal, string id)
        {
            var currentUserId = GetUserId(claimsPrincipal).ToString();
            return string.Equals(currentUserId, id, StringComparison.OrdinalIgnoreCase);
        }
    }
}
