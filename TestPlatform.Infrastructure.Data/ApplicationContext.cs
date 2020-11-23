using Microsoft.EntityFrameworkCore;
using System;
using TestPlatform.Core;

namespace TestPlatform.Infrastructure.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Category> Categories { get; private set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
           /* Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                    new Category{ Id = 1, Name="Математика", Description="Вопросы по математике" },
                    new Category{ Id = 2, Name="Физика", Description="Вопросы по физике"},
                    new Category{ Id = 3, Name="Программирование", Description="Вопросы по программированию"}
                });
        }
    }
}
