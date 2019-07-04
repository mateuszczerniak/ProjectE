using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class BatteryPack
    {
        public int BatteryPackId { get; set; }
        public string ShortcutName { get; set; }
        public string TechnologicalName { get; set; }
        public int MonoblockNumber { get; set; }
        public int StringNumber { get; set; }
        public float DischargeCurrent1 { get; set; }
        public float DischargeCurrent2 { get; set; }
        public float DischargeCurrent3 { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ProductionYear { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime AssemblyDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime LastReviewDate { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("Battery")]
        public int BatteryId { get; set; }
        public virtual Battery Battery { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}