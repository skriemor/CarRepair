using CarRepair_CommonCL.Models;
using System.Text.Json;

namespace CarRepair_server.Repositories
{
    public static class CarRecordRepository
    {
        private const string filename = "CarRecords.json";

        public static IEnumerable<CarRecord> GetCarRecords()
        {
            try
            {
                var jsonInputData = File.ReadAllText(filename);
                var carRecords = JsonSerializer.Deserialize<IEnumerable<CarRecord>>(jsonInputData);
                return carRecords;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return new List<CarRecord>();
            }
        }

        public static void SaveCarRecords(IEnumerable<CarRecord> carRecords)
        {
            var jsonOutputData = JsonSerializer.Serialize(carRecords);
            File.WriteAllText(filename, jsonOutputData);
        }
    }
}
