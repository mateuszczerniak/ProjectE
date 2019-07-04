using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string ShortcutName { get; set; }
        public string SerialNumber { get; set; }
        public string PrimarySupply { get; set; }
        public string SecondarySupply { get; set; }


        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ProductionYear { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime AssemblyDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime LastReviewDate { get; set; }


        [ForeignKey("Installation")]
        public int InstallationId { get; set; }
        public virtual Installation Installation { get; set; }

        [ForeignKey("BatteryPack")]
        public int BatteryPackId { get; set; }
        public virtual BatteryPack BatteryPack { get; set; }
        
        [ForeignKey("Load")]
        public int LoadId { get; set; }
        public virtual Load Load { get; set; }

        [ForeignKey("OperatingMode")]
        public int OperatingModeId { get; set; }
        public virtual OperatingMode OperatingMode { get; set; }

        [ForeignKey("DeviceModel")]
        public int DeviceModelId { get; set; }
        public virtual DeviceModel DeviceModel { get; set; }

        [ForeignKey("DeviceType")]
        public int DeviceTypeId { get; set; }
        public virtual DeviceType DeviceType { get; set; }

        public virtual ICollection<WorkSheet> WorkSheets { get; set; }
    }
}