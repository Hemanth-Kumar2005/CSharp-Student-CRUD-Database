using System;
using System.Data.SqlClient;

namespace CRUDApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                Console.WriteLine("Connection established successfully!\n");
                StudentManager manager = new StudentManager(conn);
                string answer;

                do
                {
                    Console.WriteLine("Select an option:\n1. Create\n2. Retrieve\n3. Update\n4. Delete");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            manager.CreateStudent();
                            break;
                        case 2:
                            manager.RetrieveStudents();
                            break;
                        case 3:
                            manager.UpdateStudent();
                            break;
                        case 4:
                            manager.DeleteStudent();
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    Console.WriteLine("Do you want to continue (Yes/No)?");
                    answer = Console.ReadLine();
                } while (!answer.Equals("No", StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}