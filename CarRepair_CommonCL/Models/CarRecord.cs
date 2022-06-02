using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRepair_CommonCL.Models
{
    public class CarRecord
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Car_type { get; set; }
        //lpn ~license plate number
        public string Car_lpn { get; set; }
        public string Problem_desc { get; set; }
        public string Repair_status { get; set; }
        public DateTime AcceptDate { get; set; }

        public override string ToString()
        {
            if (Repair_status == null)
            {
                if (AcceptDate == default(DateTime))
                {
                    return $"{id}, {Name}, {Car_type}: {Car_lpn} - {Problem_desc}";
                }
                return $"{id}, {Name}, {Car_type}: {Car_lpn} - {Problem_desc} - {AcceptDate.ToString()}";
            }
            return $"{id}, {Name}, {Car_type}: {Car_lpn} - {Problem_desc} - {AcceptDate.ToString()} {Repair_status}";
        }


        
    }
}
