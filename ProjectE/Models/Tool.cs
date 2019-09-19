using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class Tool
    {
        public int ToolId { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }

        
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey("ToolType")]
        public int ToolTypeId { get; set; }
        public virtual ToolType ToolType { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}