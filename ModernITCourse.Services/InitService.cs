using Microsoft.Extensions.Configuration;
using ModernITCourse.DataAccessLayer;
using ModernITCourse.DataAccessLayer.Entities;
using System;
using System.Linq;

namespace ModernITCourse.Services
{
    public class InitService : ServiceBase, IInitService
    {
        private static readonly Random Random = new Random();
        private static readonly int[] Scholarship = { 0, 100, 150, 200, 250 };
        private static readonly string[] Names = { "Иван", "Петр", "Вадим", "Александр", "Николай", "Павел", "Артем", "Валерий", "Андрей", "Аркадий", "Георгий" };
        private static readonly string[] Surnames = { "Иванов", "Петров", "Сидоров", "Александров", "Николаев", "Павлов", "Красноухов", "Валерьев", "Андреев", "Аркадьев", "Георгий" };
        private const int STUDENTS_GEN_COUNT = 100;
        private readonly IConfiguration configuration;
        public InitService(CourseContext context, IConfiguration configuration) : base(context)
        {
            this.configuration = configuration;
        }

        public void InsertInitialData()
        {
            if (Context.Students.Count() > 0)
                throw new Exception();

            if (Context.Universities.Count() == 0)
                throw new Exception();


            var universities = Context.Universities.ToArray();

            for (int i = 0; i < STUDENTS_GEN_COUNT; i++)
            {
                var currentUniversity = universities[Random.Next(0, universities.Length)];
                var currentBirthDay = DateTime.Now.AddYears(-18).AddMonths(-Random.Next(0, 36));
                var currentScholarship = Scholarship[Random.Next(0, Scholarship.Length)];
                var currentName = Names[Random.Next(0, Names.Length)];
                var currentSurname = Surnames[Random.Next(0, Surnames.Length)];

                var newStudent = new Student()
                {
                    CITY = currentUniversity.CITY,
                    UNIV_ID = currentUniversity.UNIV_ID,
                    KURS = Random.Next(1, 4),
                    BIRTHDAY = currentBirthDay,
                    STIPEND = currentScholarship,
                    NAME = currentName,
                    SURNAME = currentSurname,
                };

                Context.Students.Add(newStudent);
            }

            Context.SaveChanges();
        }
    }
}
