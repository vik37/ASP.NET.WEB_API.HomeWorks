using Data.AdoNetRepositories;
using Data.DatabaseContext;
using Data.DataRepositories;
using Data.Interfaces;
using Data.Repositories;
using Domain_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Services.Helpers
{
    public class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services,
            string connectionString)
        {
           services.AddDbContext<NotesDbContext>(x => x.UseSqlServer(connectionString));
            services.AddTransient<IRepository<User>, UserRepository>();
            //services.AddTransient<IRepository<User>>(x => new AdoUserRepo(connectionString));
            //services.AddTransient<IRepository<User>>(x =>
            //    new DaperUserRepo(connectionString));
            services.AddTransient<IRepository<Note>, NoteRepository>();
            return services;
        }
    }
}
