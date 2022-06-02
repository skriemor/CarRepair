using CarRepair_CommonCL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarRepair_Dispatch_Client.Provider
{
    internal class CarRecordProvider
    {
        private const string _url = "http://localhost:5297/api/CarRecord";

        public static IEnumerable<CarRecord> GetCarRecords()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var carData = response.Content.ReadAsStringAsync().Result;
                    var CarRecords = JsonConvert.DeserializeObject<IEnumerable<CarRecord>>(carData);
                    CarRecords = CarRecords.OrderBy(carRecord => carRecord.AcceptDate);
                    return CarRecords;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateRecord(CarRecord record)
        {
            using var client = new HttpClient();

            var carData = JsonConvert.SerializeObject(record);
            var content = new StringContent(carData, Encoding.UTF8, "application/json");

            var response = client.PostAsync(_url, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void UpdateRecord(CarRecord record)
        {
            using var client = new HttpClient();

            var carData = JsonConvert.SerializeObject(record);
            var content = new StringContent(carData, Encoding.UTF8, "application/json");

            var response = client.PutAsync(_url, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void DeleteRecord(int id)
        {
            using var client = new HttpClient();

            var response = client.DeleteAsync($"{_url}/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }
    }
}
