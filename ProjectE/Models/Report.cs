﻿using System;
using System.Collections.Generic;
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

        [ForeignKey("FunctionalTest")]
        public int FunctionalTestId { get; set; }
        public virtual FunctionalTest FunctionalTest { get; set; }

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
        public decimal OutputVoltage { get; set; }

        public decimal BufferVoltage { get; set; }
        public int BatteryTemperature { get; set; }
        public decimal DensityBefore { get; set; }
        public decimal DensityAfter { get; set; }
        public int WaterAmount { get; set; }
        public bool BatteryHousing { get; set; }
        public bool BatteryJumper { get; set; }
        public bool BatteryCleaning { get; set; }
        public decimal[] Measurement {get;set;}

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