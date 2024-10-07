using System.Data;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

// Connection string for SQL Server on Windows parts:
// Server=localhost; - the server address
// Database=DotNetCourseDatabase; - the database name
// Trusted_Connection=True; - use Windows authentication
// TrustServerCertificate=True; - trust the server certificate (no SSL only for development)

string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";
// Connection string for SQL Server on Linux parts:
// string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;User Id=sa;Password=Password123";


IDbConnection dbConnection = new SqlConnection(connectionString);

string sql = "SELECT GETDATE() AS CurrentDateTime";

// Test the connection
DateTime currentDateTime = dbConnection.QuerySingle<DateTime>(sql);
Console.WriteLine($"Current date and time: {currentDateTime}");

Computer myComputer = new()
{
  ComputerId = 0,
  Motherboard = "Z690",
  HasWifi = true,
  HasLTE = false,
  ReleaseDate = DateTime.Now,
  Price = 943.87m,
  VideoCard = "RTX 2060"
};

// Insert a new computer using myComputer object

string sqlInsert = $@"INSERT INTO TutorialAppSchema.Computer (
  Motherboard, 
  HasWifi, 
  HasLTE, 
  ReleaseDate, 
  Price, 
  VideoCard
) VALUES (
  '{myComputer.Motherboard}', 
  '{myComputer.HasWifi}', 
  '{myComputer.HasLTE}',
  '{myComputer.ReleaseDate}',
  '{myComputer.Price}',
  '{myComputer.VideoCard}'
)";

int result = dbConnection.Execute(sqlInsert);

Console.WriteLine($"Inserted {result} row(s) into the Computer table.");