using CarRepair_CommonCL.Models;
using Microsoft.AspNetCore.Mvc;
using CarRepair_server.Repositories;

namespace CarRepair_server.Controllers
{
    [ApiController]
    [Route("api/CarRecord")]
    public class CarRecordController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<CarRecord>> Get()
        {
            return Ok(CarRecordRepository.GetCarRecords());
        }

        [HttpGet("{owner}")]
        public ActionResult<CarRecord> Get(int id)
        {
            var record = CarRecordRepository.GetCarRecords().FirstOrDefault(x => x.id == id);
            return record != null? Ok(record): NotFound();
        }
        private int GenerateId(IEnumerable<CarRecord> records)
        {
            var orderedrecords = records.OrderBy(record => record.id);
            int newid = 0;
            foreach (var e in records)
            {
                if (newid == e.id)
                {
                    newid++;
                }
                else
                {
                    break;
                }
            }
            return newid;
        }
        [HttpPost]
        public ActionResult Post([FromBody]CarRecord record)
        {
            var records = CarRecordRepository.GetCarRecords().ToList();

            record.id = GenerateId(records);
            records.Add(record);

            CarRecordRepository.SaveCarRecords(records);
            return Ok();
        }
        [HttpPut]
        public ActionResult Put([FromBody] CarRecord record)
        {
            var records = CarRecordRepository.GetCarRecords();

            var recordToUpdate = records.FirstOrDefault(x => x.id == record.id);
            if (recordToUpdate != null)
            {
                recordToUpdate.Name = record.Name;
                recordToUpdate.Car_lpn = record.Car_lpn;
                recordToUpdate.Problem_desc = record.Problem_desc;
                recordToUpdate.Car_type = record.Car_type;

                CarRecordRepository.SaveCarRecords(records);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var records = CarRecordRepository.GetCarRecords().ToList();

            var recordToDelete = records.FirstOrDefault(x => x.id == id);
            if (recordToDelete != null)
            {
                records.Remove(recordToDelete);

                CarRecordRepository.SaveCarRecords(records);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }    
}
