using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Extensions.Configuration;


namespace HelloWorld
{
  internal class Program
  {
    static void Main(string[] args)
    {

      IConfiguration config = new ConfigurationBuilder()
                  .AddJsonFile("appSettings.json")
                  .Build();

      DataContextDapper dapper = new(config);

      // Test the connection
      DateTime currentDateTime = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
      Console.WriteLine($"Current date and time: {currentDateTime}");

      // Computer myComputer = new()
      // {
      //   ComputerId = 0,
      //   Motherboard = "Z690",
      //   HasWifi = true,
      //   HasLTE = false,
      //   ReleaseDate = DateTime.Now,
      //   Price = 943.87m,
      //   VideoCard = "RTX 2060"
      // };

      // Insert a new computer using myComputer object
      // string sqlInsert = $@"INSERT INTO TutorialAppSchema.Computer (
      //   Motherboard, 
      //   HasWifi, 
      //   HasLTE, 
      //   ReleaseDate, 
      //   Price, 
      //   VideoCard
      // ) VALUES (
      //   '{myComputer.Motherboard}', 
      //   '{myComputer.HasWifi}', 
      //   '{myComputer.HasLTE}',
      //   '{myComputer.ReleaseDate}',
      //   '{myComputer.Price}',
      //   '{myComputer.VideoCard}'
      // )";

      // int result = dbConnection.Execute(sqlInsert);
      // Console.WriteLine($"Inserted {result} row(s) into the Computer table.");

      // Read all computers from the Computer table
      string sqlSelect = "SELECT * FROM TutorialAppSchema.Computer";
      // Read all Motherboards field from the Computer table
      string sqlSelectMotherboards = "SELECT Motherboard FROM TutorialAppSchema.Computer";

      IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

      foreach (Computer computer in computers)
      {
        Console.WriteLine($"ComputerId: {computer.ComputerId}, Motherboard: {computer.Motherboard}, HasWifi: {computer.HasWifi}, HasLTE: {computer.HasLTE}, ReleaseDate: {computer.ReleaseDate}, Price: {computer.Price}, VideoCard: {computer.VideoCard}");
      }

      IEnumerable<string> motherboards = dapper.LoadData<string>(sqlSelectMotherboards);

      foreach (string motherboard in motherboards)
      {
        Console.WriteLine($"Motherboard: {motherboard}");
      }

    }
  }
}