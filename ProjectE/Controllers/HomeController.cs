using ProjectE.Models;
using ProjectE.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectE.Controllers
{
    public class HomeController : Controller
    {
        private Context db = new Context();
        public ActionResult Index()
        {
            return View(db.WorkSheets.ToList());
        }

        public ActionResult WorkSheetCreate()
        {
            var devices = db.Devices.ToList();
            var lista = devices.OrderBy(s => s.Installation.ShortcutName).Select(s => new DeviceListElement()
            {
                DeviceId = s.DeviceId,
                ShortcutName = s.ShortcutName,
                SerialNumber = s.SerialNumber,
                PrimarySupply = s.PrimarySupply,
                SecondarySupply = s.SecondarySupply,
                ProductionYear = s.ProductionYear,
                AssemblyDate = s.AssemblyDate,
                LastReviewDate = s.LastReviewDate,
                InstallationId = s.InstallationId,
                Installation = s.Installation.ShortcutName,
                BatteryPackId = s.BatteryPackId,
                BatteryPack = s.BatteryPack.ShortcutName,
                LoadId = s.LoadId,
                Load = s.Load.Name,
                OperatingModeId = s.OperatingModeId,
                OperatingMode = s.OperatingMode.Name,
                DeviceModelId = s.DeviceModelId,
                DeviceModel = s.DeviceModel.Name,
                ManufacturerId = s.DeviceModel.ManufacturerId,
                Manufacturer = s.DeviceModel.Manufacturer.Name,
                WorkSheets = s.WorkSheets.Count(),
            });
            return View(lista);
        }
        public ActionResult WorkSheetDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSheet workSheet = db.WorkSheets.Find(id);
            if (workSheet == null)
            {
                return HttpNotFound();
            }
            return View(workSheet);
        }
        public ActionResult WorkSheetEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSheet workSheet = db.WorkSheets.Find(id);
            if (workSheet == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeviceId = new SelectList(db.Devices, "DeviceId", "ShortcutName", workSheet.DeviceId);
            return View(workSheet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkSheetEdit([Bind(Include = "WorkSheetId,DeviceId")] WorkSheet workSheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workSheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeviceId = new SelectList(db.Devices, "DeviceId", "ShortcutName", workSheet.DeviceId);
            return View(workSheet);
        }

        public ActionResult WorkSheetDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSheet workSheet = db.WorkSheets.Find(id);
            if (workSheet == null)
            {
                return HttpNotFound();
            }
            return View(workSheet);
        }

        [HttpPost, ActionName("WorkSheetDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult WorkSheetDeleteConfirmed(int id)
        {
            WorkSheet workSheet = db.WorkSheets.Find(id);
            db.WorkSheets.Remove(workSheet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /////////////////////////////////////////////////////////////////////////////////
        public ActionResult AddDevice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatteryPackId = new SelectList(db.BatteryPacks, "BatteryPackId", "ShortcutName", device.BatteryPackId);
            ViewBag.DeviceModelId = new SelectList(db.DeviceModels, "DeviceModelId", "Name", device.DeviceModelId);
            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "ShortcutName", device.InstallationId);
            ViewBag.LoadId = new SelectList(db.Loads, "LoadId", "Name", device.LoadId);
            ViewBag.OperatingModeId = new SelectList(db.OperatingModes, "OperatingModeId", "Name", device.OperatingModeId);
            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDevice([Bind(Include = "WorkSheetId,DeviceId,ShortcutName,SerialNumber,PrimarySupply,SecondarySupply,ProductionYear,AssemblyDate,LastReviewDate,InstallationId,BatteryPackId,LoadId,OperatingModeId,DeviceModelId,DeviceTypeId")] WorkSheet workSheet)
        {
            if (ModelState.IsValid)
            {
                db.WorkSheets.Add(workSheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatteryPackId = new SelectList(db.BatteryPacks, "BatteryPackId", "ShortcutName", workSheet.Device.BatteryPackId);
            ViewBag.DeviceModelId = new SelectList(db.DeviceModels, "DeviceModelId", "Name", workSheet.Device.DeviceModelId);
            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "ShortcutName", workSheet.Device.InstallationId);
            ViewBag.LoadId = new SelectList(db.Loads, "LoadId", "Name", workSheet.Device.LoadId);
            ViewBag.OperatingModeId = new SelectList(db.OperatingModes, "OperatingModeId", "Name", workSheet.Device.OperatingModeId);
            return View(workSheet);
        }
        /////////////////////
        public ActionResult ReportCreate(int? id)
        {
            var context = new Models.Context();

            var workSheets = context.WorkSheets.FirstOrDefault(ps => ps.WorkSheetId == id);
            var workReasons = context.WorkReasons.Select(w =>
                new SelectListItem()
                {
                    Text = w.Name,
                    Value = w.WorkReasonId.ToString()
                }
            ).ToList();
            var reportVM = new ReportVM
            {
                workreason = workReasons,
                worksheet = workSheets
            };
            return View(reportVM);
        }

        public ActionResult Report(int? id)
        {
            var context = new Models.Context();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var workSheets = context.WorkSheets.FirstOrDefault(ps => ps.WorkSheetId == id);
            if (workSheets == null)
            {
                return HttpNotFound();
            }
            var workReasons = context.WorkReasons.Select(w =>
                new SelectListItem()
                {
                    Text = w.Name,
                    Value = w.WorkReasonId.ToString()
                }
                ).ToList();
            var workReason = context.WorkReasons.FirstOrDefault(wr => wr.WorkReasonId == id);
            var tools = context.Tools.Select(w =>
                new SelectListItem()
                {
                    Text = w.ToolType.Name + " " + w.Manufacturer.Name + " " + w.Model,
                    Value = w.ToolTypeId.ToString()
                }
                ).ToList();
            var report = new Report();
            var device = db.Devices.FirstOrDefault();

            var tool = context.Tools.FirstOrDefault();
            
            var reportViewModel = new ReportViewModel
            {
                WorkSheetId = workSheets.WorkSheetId,
                ShortcutName = workSheets.Device.ShortcutName,
                Installation = workSheets.Device.Installation.ShortcutName,
                WorkReasonId = workReason.WorkReasonId,
                WorkReason = workReasons,
                Device = device,
                StartStop = false,
                RegisterEntries = false,
                PrimarySupplyOff = false,
                PrimarySupplyBack = false,
                BypassSwitch = false,
                ShortCircuitTest = false,
                RapidLoadChanges = false,
                SignallingCheck = false,
                WorkCorrect = false,
                HousingCondition = false,
                WiringCondition = false,
                DisplayCondition = false,
                Cleaning = false,
                WorkTimeDay = DateTime.Now,
                WorkTimeFrom = DateTime.Now,
                WorkTimeTo = DateTime.Now,
                Comment = report.Comment,
                Damage = report.Damage,
                ReplacedPart = report.ReplacedPart,
                FinalResult = report.FinalResult,
                Load = 0,
                OutputVoltage = 230,
                PowerFactor = 0.75,
                InputCurrentTHD = 12,
                OutputVoltageTHD = 0.3,
                Frequency = 50,
                BufferVoltage = 230,
                BatteryTemperature = 20,
                DensityBefore = 1.24,
                DensityAfter = 1.16,
                WaterAmount = 0,
                BatteryHousing = false,
                BatteryJumper = false,
                BatteryCleaning = false,
                BatteryTest = DateTime.Now,
                BatteryStart = DateTime.Now,
                BatteryEnd = DateTime.Now,
                LastFunctionalTest = device.LastFunctionalTest,
                LastReviewDate = device.LastReviewDate,
                Tool = tools,
                ToolId = tool.ToolId,
                Measurment = null
            };
            return View(reportViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report(Report report)
        {
            var context = new Models.Context();

            if (!ModelState.IsValid)
            {
                return View(report);
            }
            context.Reports.Add(report);
            context.SaveChanges();

            return RedirectToAction("");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}