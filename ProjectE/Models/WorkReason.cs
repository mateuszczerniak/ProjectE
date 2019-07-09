using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class WorkReason
    {

        public int WorkReasonId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkSheet> WorkSheets { get; set; }
    }
}