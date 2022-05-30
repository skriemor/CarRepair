using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override string ToString()
        {
            return $"{id}, {Name}, {Car_type}: {Car_lpn} - {Problem_desc}";
        }
    }
}
