using EHIApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EHIApi.Repository
{
    public class ContactContext:DbContext
    {
        public ContactContext():base("DefaultConnection")
        {
            Database.SetInitializer<ContactContext>(new CreateDatabaseIfNotExists<ContactContext>());
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}