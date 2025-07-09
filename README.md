# CSharp Student CRUD Database

A simple C# console application demonstrating CRUD (Create, Read, Update, Delete) operations on a SQL Server database. This project manages student records, allowing you to add, view, update, and delete student data using a SQL database as storage.

## Features

- **Create**: Add new student records with details like name, roll number, age, district, and grade.
- **Read**: View all student records stored in the database.
- **Update**: Modify existing student records (update age and grade).
- **Delete**: Remove student records from the database.
- **SQL Server Database**: Uses SQL Server for persistent data storage.

## Technologies Used

- **C# (.NET 8.0)**
- **SQL Server (Local or Remote)**
- **System.Data.SqlClient** NuGet package

## Database Setup

1. **Create a Database:**
   - Open SQL Server Management Studio or your preferred SQL client.
   - Create a database named `CoDB` (or change the connection string in `Database.cs` to match your database name).

2. **Create the Table:**
   ```sql
   CREATE TABLE Stud_Details (
       student_id INT PRIMARY KEY,
       student_name NVARCHAR(100) NOT NULL,
       student_roll_no BIGINT NOT NULL,
       student_age INT NOT NULL,
       student_district NVARCHAR(100) NOT NULL,
       student_grade NVARCHAR(10) NOT NULL
   );
   ```

3. **(Optional) Insert Sample Data:**
   ```sql
   INSERT INTO Stud_Details (student_id, student_name, student_roll_no, student_age, student_district, student_grade)
   VALUES (1, 'John Doe', 1001, 18, 'Bangalore', 'A');
   ```

## How to Run

1. **Clone the Repository:**
   ```sh
   git clone https://github.com/Hemanth-Kumar2005/CSharp-Student-CRUD-Database.git
   cd CSharp-Student-CRUD-Database
   ```

2. **Restore NuGet Packages:**
   ```sh
   dotnet restore
   ```

3. **Build and Run the Application:**
   ```sh
   dotnet run
   ```

4. **Follow the Console Menu:**
   - Choose options to create, retrieve, update, or delete student records.
   - The application will prompt for required details and interact with the SQL database.

## Configuration

- The SQL Server connection string is set in `Database.cs`:
  ```csharp
  private static readonly string connectionString = @"Data Source=.;Initial Catalog=CoDB;Integrated Security=True;TrustServerCertificate=True";
  ```
  - If your SQL Server instance is different, update `Data Source` accordingly.
  - For remote databases, provide the correct server address and authentication.

## Project Structure

- `Program.cs` — Entry point, handles user menu and main loop.
- `Database.cs` — Provides SQL Server connection logic.
- `StudentManager.cs` — Contains CRUD operations for student records.
- `CRUD Application.csproj` — Project file with dependencies.

## Example

```sh
Select an option:
1. Create
2. Retrieve
3. Update
4. Delete
```

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Author

- [Hemanth Kumar](https://github.com/Hemanth-Kumar2005)

## Contributions

Feel free to fork this repo, open issues, or submit pull requests for improvements or bug fixes!
