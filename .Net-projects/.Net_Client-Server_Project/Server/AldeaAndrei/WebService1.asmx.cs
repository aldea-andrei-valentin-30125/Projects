using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace AldeaAndrei
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
       

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Student> getStudents()
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            myCon.Open();
            SqlCommand cmd = myCon.CreateCommand();
            SqlDataReader dr;

            cmd.CommandText = "Select * From Studenti";
            dr = cmd.ExecuteReader();

            List<Student> students = new List<Student>();

            while (dr.Read())
            {
                var x = new Student
                {
                    Id = Convert.ToInt32(dr.GetValue(0)),
                    Name = dr.GetString(1),
                    Materia = dr.GetString(2),
                    Nota = Convert.ToInt32(dr.GetValue(3))
                };

                students.Add(x);
            }
            myCon.Close();
            
            return students;
        }

        [WebMethod]
        public void  addStudent(string name, string materia ,int nota)
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            myCon.Open();
            SqlCommand cmd = myCon.CreateCommand();
            name = name.Trim();
            materia = materia.Trim();

            cmd.CommandText = "Insert into Studenti(Name, Materia, Nota) values ('" + name + "','" + materia + "','" + nota + "')";
            cmd.ExecuteNonQuery();
            myCon.Close();

        }

        [WebMethod]
        public void deleteStudent(int id)
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            myCon.Open();
            SqlCommand cmd = myCon.CreateCommand();
            var ID = Convert.ToInt32(id);

            cmd.CommandText = "DELETE From Studenti WHERE Id= '" + ID + "'";
            cmd.ExecuteNonQuery();
            myCon.Close();

        }

        [WebMethod]
        public Student getStudent(int id)
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            myCon.Open();
            SqlCommand cmd = myCon.CreateCommand();
            SqlDataReader dr;
            var ID = Convert.ToInt32(id);

            cmd.CommandText = "Select * From Studenti WHERE Id= '" + ID + "'";
            dr = cmd.ExecuteReader();
            var studentGol = new Student
            {
                Id = Convert.ToInt32("0"),
                Name = "eroare",
                Materia = "eroare",
                Nota = Convert.ToInt32("0")
            };
            if (dr.Read())
            {
                var student = new Student
                {
                    Id = Convert.ToInt32(dr.GetValue(0)),
                    Name = dr.GetString(1),
                    Materia = dr.GetString(2),
                    Nota = Convert.ToInt32(dr.GetValue(3))
                };
                myCon.Close();
                return student;
            }
            else {
                myCon.Close(); return studentGol; }

        }

        [WebMethod]
        public void editStudent(int id, string name, string materia, int nota)
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            myCon.Open();
            SqlCommand cmd = myCon.CreateCommand();
            id = Convert.ToInt32(id);
            nota = Convert.ToInt32(nota);
            name = name.Trim();
            materia = materia.Trim();

            cmd.CommandText = "UPDATE Studenti SET Name = '" + name + "' , Materia ='" + materia + "' , Nota = '" + nota + "' WHERE Id = '" + id + "'";
            cmd.ExecuteNonQuery();

            myCon.Close();
        }
    }
}
