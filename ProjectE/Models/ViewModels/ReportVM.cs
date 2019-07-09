using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectE.Models.ViewModels
{
    public class ReportVM
    {
        public WorkSheet workSheet { get; set; }
        public WorkReason workReason { get; set; }


        //public ReportVM()
        //{

        //}
        //public int DeviceId { get; set; }
        //public string ShortcutName { get; set; }
        //public string SerialNumber { get; set; }
        //public string PrimarySupply { get; set; }
        //public string SecondarySupply { get; set; }


        //[DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        //[DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        //public System.DateTime ProductionYear { get; set; }

        //[DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        //[DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        //public System.DateTime AssemblyDate { get; set; }

        //[DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        //public System.DateTime LastReviewDate { get; set; }


        //public int InstallationId { get; set; }
        //public string Installation { get; set; }

        //public int BatteryPackId { get; set; }
        //public string BatteryPack { get; set; }

        //public int LoadId { get; set; }
        //public string Load { get; set; }

        //public int OperatingModeId { get; set; }
        //public string OperatingMode { get; set; }

        //public int DeviceModelId { get; set; }
        //public string DeviceModel { get; set; }

        //public int DeviceTypeId { get; set; }
        //public string DeviceType { get; set; }

        //public int ManufacturerId { get; set; }
        //public string Manufacturer { get; set; }
    }
}