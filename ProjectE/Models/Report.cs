using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        [ForeignKey("WorkSheet")]
        public int WorkSheetId { get; set; }
        public virtual WorkSheet WorkSheet { get; set; }

        [ForeignKey("WorkReason")]
        public int WorkReasonId { get; set; }
        public virtual WorkReason WorkReason { get; set; }
    }
}