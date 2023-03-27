﻿using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, IEntity<Guid>
    {
    }
}
