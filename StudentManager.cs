using System;
using System.Data.SqlClient;

namespace CRUDApplication
{
    public class StudentManager
    {
        private SqlConnection connection;

        public StudentManager(SqlConnection conn)
        {
            connection = conn;
        }

        public void CreateStudent()
        {
            string nextIdQuery = @"
                SELECT ISNULL(MIN(t1.student_id + 1), 1) AS NextAvailableId
                FROM Stud_Details t1
                LEFT JOIN Stud_Details t2 ON t1.student_id + 1 = t2.student_id
                WHERE t2.student_id IS NULL";

            SqlCommand idCommand = new SqlCommand(nextIdQuery, connection);
            int nextStudentId = Convert.ToInt32(idCommand.ExecuteScalar());

            string checkId1 = "SELECT COUNT(*) FROM Stud_Details WHERE student_id = 1";
            SqlCommand checkCommand = new SqlCommand(checkId1, connection);
            int id1Exists = Convert.ToInt32(checkCommand.ExecuteScalar());
            if (id1Exists == 0) nextStudentId = 1;

            Console.WriteLine("Enter Student Name : ");
            string studentName = Console.ReadLine();
            Console.WriteLine("Enter Student Roll No : ");
            long studentRollNo = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Age : ");
            int studentAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student District : ");
            string studentDistrict = Console.ReadLine();
            Console.WriteLine("Enter Student Grade : ");
            string studentGrade = Console.ReadLine();

            new SqlCommand("SET IDENTITY_INSERT Stud_Details ON", connection).ExecuteNonQuery();

            string insertQuery = "INSERT INTO Stud_Details (student_id, student_name, student_roll_no, student_age, student_district, student_grade) " +
                                 $"VALUES ({nextStudentId}, '{studentName}', {studentRollNo}, {studentAge}, '{studentDistrict}', '{studentGrade}')";
            new SqlCommand(insertQuery, connection).ExecuteNonQuery();

            new SqlCommand("SET IDENTITY_INSERT Stud_Details OFF", connection).ExecuteNonQuery();

            Console.WriteLine("Student inserted with ID: " + nextStudentId);
        }

        public void RetrieveStudents()
        {
            string displayQuery = "SELECT * FROM Stud_Details";
            SqlCommand displayCommand = new SqlCommand(displayQuery, connection);
            SqlDataReader dataReader = displayCommand.ExecuteReader();

            if (!dataReader.HasRows)
            {
                Console.WriteLine("No student records found!");
            }
            else
            {
                while (dataReader.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine($"Student Id      : {dataReader[0]}");
                    Console.WriteLine($"Name            : {dataReader[1]}");
                    Console.WriteLine($"Roll No         : {dataReader[2]}");
                    Console.WriteLine($"Age             : {dataReader[3]}");
                    Console.WriteLine($"District        : {dataReader[4]}");
                    Console.WriteLine($"Grade           : {dataReader[5]}");
                }
            }

            dataReader.Close();
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Enter Student Id to update:");
            int updateId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Age:");
            int newAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Grade:");
            string newGrade = Console.ReadLine();

            string updateQuery = $"UPDATE Stud_Details SET student_age = {newAge}, student_grade = '{newGrade}' WHERE student_id = {updateId}";
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            int rows = updateCommand.ExecuteNonQuery();

            Console.WriteLine(rows > 0 ? "Student updated successfully!" : "No record found with that ID.");
        }

        public void DeleteStudent()
        {
            Console.WriteLine("Enter Student Id to delete:");
            int deleteId = int.Parse(Console.ReadLine());

            string deleteQuery = $"DELETE FROM Stud_Details WHERE student_id = {deleteId}";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            int rows = deleteCommand.ExecuteNonQuery();

            Console.WriteLine(rows > 0 ? "Deleted successfully!" : "No record found with that ID.");
        }
    }
}