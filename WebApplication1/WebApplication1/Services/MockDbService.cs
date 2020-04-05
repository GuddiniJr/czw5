using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> students = new List<Student> { 
                new Student{IdStudent=1,FirstName="Jan",LastName="Kowalski",IndexNumber="s1221"},
                new Student{IdStudent=2,FirstName="Anna",LastName="Malewski",IndexNumber="s1231"},
                new Student{IdStudent=3,FirstName="Gleb",LastName="Xdddd",IndexNumber="s1213"},
        };

        public IEnumerable<Student> GetStudents()
        {
           return students;
        }
    }
}
