﻿using Microsoft.AspNetCore.Identity;

namespace MShopIdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
		public string Name { get; set; }

		public string Surname { get; set; }
	}
}
