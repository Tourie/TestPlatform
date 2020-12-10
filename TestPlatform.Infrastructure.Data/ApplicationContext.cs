using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestPlatform.Core;

namespace TestPlatform.Infrastructure.Data
{
    public class ApplicationContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        /*public DbSet<Profile> Profiles { get; set; }*/
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            /*Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Tests)
                .WithMany(s => s.Categories);
            modelBuilder.Entity<Category>()
                .HasData(
                new Category[]
                {
                    new Category{ Id = 1, Name="Математика", Description="Вопросы по математике" },
                    new Category{ Id = 2, Name="Физика", Description="Вопросы по физике"},
                    new Category{ Id = 3, Name="Программирование", Description="Вопросы по программированию"}
                });
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Categories)
                .WithMany(c => c.Tests);
            modelBuilder.Entity<Test>().HasData(
                new Test[]
                {
                    new Test{Id=1, Name="Вопросы начального уровня", Description="Описание", Time=12/*, Categories = Categories*/ },
                    new Test{Id=2, Name="Вопросы среднего уровня", Description="Описание 2 теста", Time = 16/*, Categories = Categories*/ },
                    new Test{Id=3, Name="Вопросы повышенного уровня", Description="Описание 3 теста", Time=20/*, Categories = Categories*/ }
                });
            modelBuilder.Entity<Question>().HasData(
                new Question[]
                {
                    new Question{ Id=1, Name="1 вопрос 1 теста", Testid=1 },
                    new Question{ Id=2, Name="2 вопрос 1 теста", Testid=1 },

                    new Question{ Id=3, Name="1 вопрос 2 теста", Testid=2 },
                    new Question{ Id=4, Name="2 вопрос 2 теста", Testid=2 },

                    new Question{ Id=5, Name="1 вопрос 3 теста", Testid=3 },
                });

            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer{ Id=1, Name="1 ответ 1 вопроса", QuestionId=1/*, Test=Tests.Find(1)*/ },
                    new Answer{ Id=2, Name="2 ответ 1 вопроса", QuestionId=1/*, Test=Tests.Find(1)*/ },
                    new Answer{ Id=3, Name="1 ответ 2 вопроса", QuestionId=2/*, Test=Tests.Find(1)*/ },
                    new Answer{ Id=4, Name="2 ответ 2 вопроса", QuestionId=2/*, Test=Tests.Find(1)*/ },

                    new Answer{ Id=5, Name="1 ответ", QuestionId=3/*, Test=Tests.Find(1)*/ },
                    new Answer{ Id=6, Name="2 ответ", QuestionId=3/*, Test=Tests.Find(1)*/ },
                    new Answer{ Id=7, Name="1 ответ", QuestionId=4/*, Test=Tests.Find(1)*/ },
                    new Answer{ Id=8, Name="2 ответ", QuestionId=4/*, Test=Tests.Find(1)*/ },

                    new Answer{ Id=9, Name="1 овтет", QuestionId=5/*, Test=Tests.Find(1)*/ },
                    new Answer{ Id=10, Name="2 ответ", QuestionId=5/*, Test=Tests.Find(1)*/ },
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "email@gmail.com",
                    NormalizedEmail = "EMAIL@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "password"),
                    SecurityStamp = string.Empty

                });
        }
    }
}
