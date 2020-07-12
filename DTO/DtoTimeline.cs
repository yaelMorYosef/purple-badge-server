using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoTimeline
    {
        public int businessID { get; set; }
        public string customerID { get; set; }
        public DateTime entranceDate { get; set; }
        public DateTime entranceTime { get; set; }
        public DateTime exitTime { get; set; }

    }
}
