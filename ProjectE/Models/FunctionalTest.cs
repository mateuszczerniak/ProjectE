using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class FunctionalTest
    {
        public int FunctionalTestId { get; set; }
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
    }
}