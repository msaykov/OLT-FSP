namespace OLT_FSP.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OltDbContext : IdentityDbContext
    {
        public OltDbContext(DbContextOptions<OltDbContext> options)
            : base(options)
        {
        }
    }
}
