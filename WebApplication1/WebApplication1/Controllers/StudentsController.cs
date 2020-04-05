using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _service;

        public  StudentsController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult getStudents(String orderBy)

        {
            var lista = new List<Student>();
            string querry = "select * from student";
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18511;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = querry;
                con.Open();
                SqlDataReader dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    var student = new Student();
                    student.IdEnrollment = Int32.Parse(dataReader["idenrollment"].ToString());
                    student.IndexNumber = (dataReader["indexnumber"].ToString());
                    student.FirstName = dataReader["FirstName"].ToString();
                    student.BirbDate = dataReader["BirthDate"].ToString();
                    student.LastName = dataReader["LastName"].ToString();

                    lista.Add(student);

                }
            }
            return Ok(lista);
        }


        [HttpGet("{id}")]

        public IActionResult GetStudentWpis(String id)
        {
            var list = new List<Enrollment>();
            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18511;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Student where Student.IndexNumber=@id";
                com.Parameters.AddWithValue("id", id);
                con.Open();
                var dr = com.ExecuteReader();
                
                while (dr.Read())
                {
                    var en = new Enrollment();
                    en.IdEnrollment = Int32.Parse(dr["idenrollment"].ToString());
                    en.StartDate = dr["Semester"].ToString();
                    en.IdStudy = Int32.Parse(dr["IdStudy"].ToString());
                    en.StartDate = dr["startDate"].ToString();
                    list.Add(en);

                }
            }
            return Ok(list);
        }


        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 2000)}";

            return Ok(student);
        }


        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Ąktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Usuwanie ukończone");
        }
    }
}