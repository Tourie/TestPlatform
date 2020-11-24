using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestPlatform.Core;

namespace TestPlatform.Infrastructure.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Category> Categories { get; private set; }
        public DbSet<Test> Tests { get; private set; }
        public DbSet<Question> Questions { get; private set; }
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
            /* var categories = new List<Category>
                 {
                     new Category{ Id = 1, Name="Математика", Description="Вопросы по математике" },
                     new Category{ Id = 2, Name="Физика", Description="Вопросы по физике"},
                     new Category{ Id = 3, Name="Программирование", Description="Вопросы по программированию"}
                 };
             categories.ForEach(category => Categories.Add(category));*/
            modelBuilder.Entity<Test>().HasData(
                new Test[]
                {
                    new Test{Id=1, Name="Вопросы начального уровня", Description="Описание", Time=12/*, Categories = Categories*/ },
                    new Test{Id=2, Name="Вопросы среднего уровня", Description="Описание 2 теста", Time = 16/*, Categories = Categories*/ },
                    new Test{Id=3, Name="Вопросы повышенного уровня", Description="Описание 3 теста", Time=20/*, Categories = Categories*/ }
                });
            /*var tests = new List<Test>
                {
                    new Test{Id=1, Name="Вопросы начального уровня", Description="Описание", Time=12, Categories = Categories },
                    new Test{Id=2, Name="Вопросы среднего уровня", Description="Описание 2 теста", Time = 16, Categories = Categories },
                    new Test{Id=3, Name="Вопросы повышенного уровня", Description="Описание 3 теста", Time=20, Categories = Categories }
                };
            tests.ForEach(test => Tests.Add(test));*/
            modelBuilder.Entity<Question>().HasData(
                new Question[]
                {
                    new Question{ Id=1, Name="1 вопрос 1 теста", Testid=1/*, Test=Tests.Find(1)*/ },
                    new Question{ Id=2, Name="2 вопрос 1 теста", Testid=1/*, Test=Tests.Find(1)*/ },

                    new Question{ Id=3, Name="1 вопрос 2 теста", Testid=2/*, Test=Tests.Find(2)*/ },
                    new Question{ Id=4, Name="2 вопрос 2 теста", Testid=2/*, Test=Tests.Find(2)*/ },

                    new Question{ Id=5, Name="1 вопрос 3 теста", Testid=3/*, Test=Tests.Find(3)*/ },
                });
           /* var questions = new List<Question>
                {
                    new Question{ Id=1, Name="1 вопрос 1 теста", Testid=1, Test=Tests.Find(1) },
                    new Question{ Id=2, Name="2 вопрос 1 теста", Testid=1, Test=Tests.Find(1) },

                    new Question{ Id=3, Name="1 вопрос 2 теста", Testid=2, Test=Tests.Find(2) },
                    new Question{ Id=4, Name="2 вопрос 2 теста", Testid=2, Test=Tests.Find(2) },

                    new Question{ Id=5, Name="1 вопрос 3 теста", Testid=3, Test=Tests.Find(3) },
                };
            questions.ForEach(question => Questions.Add(question));*/
        }
    }
}
