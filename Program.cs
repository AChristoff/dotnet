using System.Data;
using Dapper;
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