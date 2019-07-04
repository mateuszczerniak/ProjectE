using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class WorkSheet
    {
        public WorkSheet()
        {

        }
        public int? WorkSheetId { get; set; }

        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }
    }
}