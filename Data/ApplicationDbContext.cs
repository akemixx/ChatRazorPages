using System;
using System.Collections.Generic;
using System.Text;
using ChatRazorPages.ModelsDB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatRazorPages.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Message> Message { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
