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