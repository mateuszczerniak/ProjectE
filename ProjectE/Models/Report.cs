using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [ForeignKey("Tool")]
        public int ToolId { get; set; }
        public virtual Tool Tool { get; set; }

        public bool StartStop { get; set; }
        public bool RegisterEntries { get; set; }
        public bool PrimarySupplyOff { get; set; }
        public bool PrimarySupplyBack { get; set; }
        public bool BypassSwitch { get; set; }
        public bool ShortCircuitTest { get; set; }
        public bool RapidLoadChanges { get; set; }
        public bool SignallingCheck { get; set; }
        public bool WorkCorrect { get; set; }
        public bool HousingCondition { get; set; }
        public bool WiringCondition { get; set; }
        public bool DisplayCondition { get; set; }
        public bool Cleaning { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime WorkTimeDay { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{HH.mm.f}", ApplyFormatInEditMode = true)]
        public System.DateTime WorkTimeFrom { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{HH.mm.f}", ApplyFormatInEditMode = true)]
        public System.DateTime WorkTimeTo { get; set; }

        public string Comment { get; set; }
        public string Damage { get; set; }
        public string ReplacedPart { get; set; }
        public string FinalResult { get; set; }
        public int Load { get; set; }
        public double PowerFactor { get; set; }
        public double InputCurrentTHD { get; set; }
        public double OutputVoltageTHD { get; set; }
        public int Frequency { get; set; }
        public double OutputVoltage { get; set; }
        public double BufferVoltage { get; set; }
        public int BatteryTemperature { get; set; }
        public double DensityBefore { get; set; }
        public double DensityAfter { get; set; }
        public int WaterAmount { get; set; }
        public bool BatteryHousing { get; set; }
        public bool BatteryJumper { get; set; }
        public bool BatteryCleaning { get; set; }
        public string Measurment { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime BatteryTest { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{HH.mm.f}", ApplyFormatInEditMode = true)]
        public System.DateTime BatteryStart { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{HH.mm.f}", ApplyFormatInEditMode = true)]
        public System.DateTime BatteryEnd { get; set; }
    }
}