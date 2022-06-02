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

        [HttpGet("{id:int}")]
        public ActionResult<CarRecord> Get(int id)
        {
            var record = CarRecordRepository.GetCarRecords().FirstOrDefault(x => x.id == id);
            return record != null? Ok(record): NotFound();
        }
        private int GenerateId(IEnumerable<CarRecord> records)
        {
            var orderedrecords = records.OrderBy(record => record.id);
            int newid = 0;
            foreach (var e in orderedrecords)
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

            record.AcceptDate = DateTime.Now;
            record.Repair_status = "Accepted";
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
                recordToUpdate.Repair_status = record.Repair_status;
                recordToUpdate.Name = record.Name;
                recordToUpdate.Car_lpn = record.Car_lpn;
                recordToUpdate.Problem_desc = record.Problem_desc;
                recordToUpdate.Car_type = record.Car_type;
                recordToUpdate.AcceptDate = DateTime.Now;

                CarRecordRepository.SaveCarRecords(records);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id:int}")]
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
