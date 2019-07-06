using ProjectE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectE.Controllers
{
    public class AdminController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult BatterySpecies()
        {
            return View(db.BatterySpecies.ToList());
        }
        public ActionResult BatterySpeciesCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatterySpeciesCreate([Bind(Include = "BatterySpeciesId,Species")] BatterySpecies batterySpecies)
        {
            if (ModelState.IsValid)
            {
                db.BatterySpecies.Add(batterySpecies);
                db.SaveChanges();
                return RedirectToAction("BatterySpecies");
            }

            return View(batterySpecies);
        }
        public ActionResult BatterySpeciesEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatterySpecies batterySpecies = db.BatterySpecies.Find(id);
            if (batterySpecies == null)
            {
                return HttpNotFound();
            }
            return View(batterySpecies);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatterySpeciesEdit([Bind(Include = "BatterySpeciesId,Species")] BatterySpecies batterySpecies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batterySpecies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BatterySpecies");
            }
            return View(batterySpecies);
        }
        public ActionResult BatterySpeciesDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatterySpecies batterySpecies = db.BatterySpecies.Find(id);
            if (batterySpecies == null)
            {
                return HttpNotFound();
            }
            return View(batterySpecies);
        }
        [HttpPost, ActionName("BatterySpeciesDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BatterySpeciesDeleteConfirmed(int id)
        {
            BatterySpecies batterySpecies = db.BatterySpecies.Find(id);
            db.BatterySpecies.Remove(batterySpecies);
            db.SaveChanges();
            return RedirectToAction("BatterySpecies");
        }
        //battery
        public ActionResult Batteries()
        {
            var batteries = db.Batteries.Include(b => b.BatterySpecies).Include(b => b.Manufacturer);
            return View(batteries.ToList());
        }
        public ActionResult BatteryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Battery battery = db.Batteries.Find(id);
            if (battery == null)
            {
                return HttpNotFound();
            }
            return View(battery);
        }
        public ActionResult BatteryCreate()
        {
            ViewBag.BatterySpeciesId = new SelectList(db.BatterySpecies, "BatterySpeciesId", "Species");
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatteryCreate([Bind(Include = "BatteryId,BatteryType,Capacity,CellVoltage,CellQuantity,ManufacturerId,BatterySpeciesId")] Battery battery)
        {
            if (ModelState.IsValid)
            {
                db.Batteries.Add(battery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatterySpeciesId = new SelectList(db.BatterySpecies, "BatterySpeciesId", "Species", battery.BatterySpeciesId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", battery.ManufacturerId);
            return View(battery);
        }
        public ActionResult BatteryEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Battery battery = db.Batteries.Find(id);
            if (battery == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatterySpeciesId = new SelectList(db.BatterySpecies, "BatterySpeciesId", "Species", battery.BatterySpeciesId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", battery.ManufacturerId);
            return View(battery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatteryEdit([Bind(Include = "BatteryId,BatteryType,Capacity,CellVoltage,CellQuantity,ManufacturerId,BatterySpeciesId")] Battery battery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(battery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatterySpeciesId = new SelectList(db.BatterySpecies, "BatterySpeciesId", "Species", battery.BatterySpeciesId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", battery.ManufacturerId);
            return View(battery);
        }
        public ActionResult BatteryDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Battery battery = db.Batteries.Find(id);
            if (battery == null)
            {
                return HttpNotFound();
            }
            return View(battery);
        }
        [HttpPost, ActionName("BatteryDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BatteryDeleteConfirmed(int id)
        {
            Battery battery = db.Batteries.Find(id);
            db.Batteries.Remove(battery);
            db.SaveChanges();
            return RedirectToAction("Batteries");
        }
        //

        //manufacturer
        public ActionResult Manufacturers()
        {
            return View(db.Manufacturers.ToList());
        }
        public ActionResult ManufacturerCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManufacturerCreate([Bind(Include = "ManufacturerId,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }
        public ActionResult ManufacturerEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManufacturerEdit([Bind(Include = "ManufacturerId,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        public ActionResult ManufacturerDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        [HttpPost, ActionName("ManufacturerDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ManufacturerDeleteConfirmed(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            db.Manufacturers.Remove(manufacturer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //
        //installation
        public ActionResult Installations()
        {
            return View(db.Installations.ToList());
        }
        public ActionResult InstallationCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InstallationCreate([Bind(Include = "InstallationId,ShortcutName,Name")] Installation installation)
        {
            if (ModelState.IsValid)
            {
                db.Installations.Add(installation);
                db.SaveChanges();
                return RedirectToAction("Installations");
            }

            return View(installation);
        }
        public ActionResult InstallationEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Installation installation = db.Installations.Find(id);
            if (installation == null)
            {
                return HttpNotFound();
            }
            return View(installation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InstallationEdit([Bind(Include = "InstallationId,ShortcutName,Name")] Installation installation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(installation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Installations");
            }
            return View(installation);
        }
        public ActionResult InstallationDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Installation installation = db.Installations.Find(id);
            if (installation == null)
            {
                return HttpNotFound();
            }
            return View(installation);
        }
        [HttpPost, ActionName("InstallationDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult InstallationDeleteConfirmed(int id)
        {
            Installation installation = db.Installations.Find(id);
            db.Installations.Remove(installation);
            db.SaveChanges();
            return RedirectToAction("Installations");
        }
        //
        //load
        public ActionResult Loads()
        {
            return View(db.Loads.ToList());
        }
        public ActionResult LoadCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoadCreate([Bind(Include = "LoadId,Name")] Load load)
        {
            if (ModelState.IsValid)
            {
                db.Loads.Add(load);
                db.SaveChanges();
                return RedirectToAction("Loads");
            }

            return View(load);
        }
        public ActionResult LoadEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Load load = db.Loads.Find(id);
            if (load == null)
            {
                return HttpNotFound();
            }
            return View(load);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoadEdit([Bind(Include = "LoadId,Name")] Load load)
        {
            if (ModelState.IsValid)
            {
                db.Entry(load).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Loads");
            }
            return View(load);
        }
        public ActionResult LoadDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Load load = db.Loads.Find(id);
            if (load == null)
            {
                return HttpNotFound();
            }
            return View(load);
        }
        [HttpPost, ActionName("LoadDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LoadDeleteConfirmed(int id)
        {
            Load load = db.Loads.Find(id);
            db.Loads.Remove(load);
            db.SaveChanges();
            return RedirectToAction("Loads");
        }
        //
        
        //device
        public ActionResult Devices()
        {
            var device = db.Devices.Include(b => b.Installation).Include(b => b.DeviceModel).Include(b => b.BatteryPack).Include(b=>b.Load).Include(b => b.OperatingMode);
            return View(device.ToList());
        }
        public ActionResult DeviceDetails(int? id)
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
            return View(device);
        }
        public ActionResult DeviceCreate()
        {
            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "ShortcutName");

            var batteryPacks = (from c in db.BatteryPacks
                                select new SelectListItem
                                {
                                    Text = c.Installation.ShortcutName + " " + c.ShortcutName,
                                    Value = c.BatteryPackId.ToString()
                                });
            ViewBag.BatteryPackId = new SelectList(batteryPacks, "Value", "Text");

            //ViewBag.BatteryPackId = new SelectList(db.BatteryPacks, "BatteryPackId", "ShortcutName");
            ViewBag.LoadId = new SelectList(db.Loads, "LoadId", "Name");
            ViewBag.OperatingModeId = new SelectList(db.OperatingModes, "OperatingModeId", "Name");
            ViewBag.DeviceModelId = new SelectList(db.DeviceModels, "DeviceModelId", "Name");
            ViewBag.DeviceTypeId = new SelectList(db.DeviceTypes, "DeviceTypeId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeviceCreate([Bind(Include = "DeviceId,ShortcutName,SerialNumber,ProductionYear,AssemblyDate,LastReviewDate,PrimarySupply,SecondarySupply,InstallationId,BatteryPackId,LoadId,OperatingModeId,DeviceModelId,DeviceTypeId")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Devices.Add(device);
                db.SaveChanges();
                return RedirectToAction("Devices");
            }

            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "Name", device.InstallationId);
            ViewBag.BatteryPackId = new SelectList(db.BatteryPacks, "BatteryPackId", "ShortcutName", device.BatteryPackId);
            ViewBag.LoadId = new SelectList(db.Loads, "LoadId", "Name", device.LoadId);
            ViewBag.OperatingModeId = new SelectList(db.OperatingModes, "OperatingModeId", "Name", device.OperatingModeId);
            ViewBag.DeviceModelId = new SelectList(db.DeviceModels, "DeviceModelId", "Name", device.DeviceModelId);
            return View(device);
        }
        public ActionResult DeviceEdit(int? id)
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
            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "Name", device.InstallationId);
            ViewBag.BatteryPackId = new SelectList(db.BatteryPacks, "BatteryPackId", "ShortcutName", device.BatteryPackId);
            ViewBag.LoadId = new SelectList(db.Loads, "LoadId", "Name", device.LoadId);
            ViewBag.OperatingModeId = new SelectList(db.OperatingModes, "OperatingModeId", "Name", device.OperatingModeId);
            ViewBag.DeviceModelId = new SelectList(db.DeviceModels, "DeviceModelId", "Name", device.DeviceModelId);
            return View(device);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeviceEdit([Bind(Include = "DeviceId,ShortcutName,SerialNumber,ProductionYear,AssemblyDate,LastReviewDate,PrimarySupply,SecondarySupply,InstallationId,BatteryPackId,LoadId,OperatingModeId,DeviceModelId,DeviceTypeId")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Entry(device).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Devices");
            }
            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "Name", device.InstallationId);
            ViewBag.BatteryPackId = new SelectList(db.BatteryPacks, "BatteryPackId", "ShortcutName", device.BatteryPackId);
            ViewBag.LoadId = new SelectList(db.Loads, "LoadId", "Name", device.LoadId);
            ViewBag.OperatingModeId = new SelectList(db.OperatingModes, "OperatingModeId", "Name", device.OperatingModeId);
            ViewBag.DeviceModelId = new SelectList(db.DeviceModels, "DeviceModelId", "Name", device.DeviceModelId);
            return View(device);
        }
        public ActionResult DeviceDelete(int? id)
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
            return View(device);
        }
        [HttpPost, ActionName("DeviceDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeviceDeleteConfirmed(int id)
        {
            Device device = db.Devices.Find(id);
            db.Devices.Remove(device);
            db.SaveChanges();
            return RedirectToAction("Devices");
        }
        //operatingmode
        public ActionResult OperatingModes()
        {
            return View(db.OperatingModes.ToList());
        }
        public ActionResult OperatingModeCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OperatingModeCreate([Bind(Include = "OperatingModeId,Name")] OperatingMode operatingMode)
        {
            if (ModelState.IsValid)
            {
                db.OperatingModes.Add(operatingMode);
                db.SaveChanges();
                return RedirectToAction("OperatingModes");
            }

            return View(operatingMode);
        }
        public ActionResult OperatingModeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperatingMode operatingMode = db.OperatingModes.Find(id);
            if (operatingMode == null)
            {
                return HttpNotFound();
            }
            return View(operatingMode);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OperatingModeEdit([Bind(Include = "OperatingModeId,Name")] OperatingMode operatingMode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operatingMode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OperatingModes");
            }
            return View(operatingMode);
        }
        public ActionResult OperatingModeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperatingMode operatingMode = db.OperatingModes.Find(id);
            if (operatingMode == null)
            {
                return HttpNotFound();
            }
            return View(operatingMode);
        }
        [HttpPost, ActionName("OperatingModeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult OperatingModeDeleteConfirmed(int id)
        {
            OperatingMode operatingMode = db.OperatingModes.Find(id);
            db.OperatingModes.Remove(operatingMode);
            db.SaveChanges();
            return RedirectToAction("OperatingModes");
        }
        //
        //batterypack
        public ActionResult BatteryPacks()
        {
            var batteryPacks = db.BatteryPacks.Include(b => b.Battery).Include(b => b.Installation);
            return View(batteryPacks.ToList());
        }
        public ActionResult BatteryPackDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatteryPack batteryPack = db.BatteryPacks.Find(id);
            if (batteryPack == null)
            {
                return HttpNotFound();
            }
            return View(batteryPack);
        }
        public ActionResult BatteryPackCreate()
        {
            ViewBag.BatteryId = new SelectList(db.Batteries, "BatteryId", "BatteryType");
            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "ShortcutName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatteryPackCreate([Bind(Include = "BatteryPackId,ShortcutName,TechnologicalName,MonoblockNumber,StringNumber,DischargeCurrent1,DischargeCurrent2,DischargeCurrent3,ProductionYear,AssemblyDate,LastReviewDate,BatteryId,InstallationId")] BatteryPack batteryPack)
        {
            if (ModelState.IsValid)
            {
                db.BatteryPacks.Add(batteryPack);
                db.SaveChanges();
                return RedirectToAction("BatteryPacks");
            }

            ViewBag.BatteryId = new SelectList(db.Batteries, "BatteryId", "BatteryType", batteryPack.BatteryId);
            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "ShortcutName", batteryPack.InstallationId);
            return View(batteryPack);
        }
        public ActionResult BatteryPackEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatteryPack batteryPack = db.BatteryPacks.Find(id);
            if (batteryPack == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatteryId = new SelectList(db.Batteries, "BatteryId", "BatteryType", batteryPack.BatteryId);
            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "ShortcutName", batteryPack.InstallationId);
            return View(batteryPack);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatteryPackEdit([Bind(Include = "BatteryId,BatteryType,InstallationId")] BatteryPack batteryPack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batteryPack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BatteryPacks");
            }
            ViewBag.BatteryId = new SelectList(db.Batteries, "BatteryId", "BatteryType", batteryPack.BatteryId);
            ViewBag.InstallationId = new SelectList(db.Installations, "InstallationId", "ShortcutName", batteryPack.InstallationId);
            return View(batteryPack);
        }
        public ActionResult BatteryPackDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatteryPack batteryPack = db.BatteryPacks.Find(id);
            if (batteryPack == null)
            {
                return HttpNotFound();
            }
            return View(batteryPack);
        }
        [HttpPost, ActionName("BatteryPackDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BatteryPackDeleteConfirmed(int id)
        {
            BatteryPack batteryPack = db.BatteryPacks.Find(id);
            db.BatteryPacks.Remove(batteryPack);
            db.SaveChanges();
            return RedirectToAction("BatteryPacks");
        }
        //owners
        //public ActionResult Owners()
        //{
        //    return View(db.Owners.ToList());
        //}
        //public ActionResult OwnerCreate()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult OwnerCreate([Bind(Include = "OwnerId,Name")] Owner owner)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Owners.Add(owner);
        //        db.SaveChanges();
        //        return RedirectToAction("Owners");
        //    }

        //    return View(owner);
        //}
        //public ActionResult OwnerEdit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Owner owner = db.Owners.Find(id);
        //    if (owner == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(owner);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult OwnerEdit([Bind(Include = "OwnerId,Name")] Owner owner)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(owner).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Owners");
        //    }
        //    return View(owner);
        //}
        //public ActionResult OwnerDelete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Owner owner = db.Owners.Find(id);
        //    if (owner == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(owner);
        //}
        //[HttpPost, ActionName("OwnerDelete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult OwnerDeleteConfirmed(int id)
        //{
        //    Owner owner = db.Owners.Find(id);
        //    db.Owners.Remove(owner);
        //    db.SaveChanges();
        //    return RedirectToAction("Owners");
        //}
        //tooltype
        public ActionResult ToolTypes()
        {
            return View(db.ToolTypes.ToList());
        }
        public ActionResult ToolTypeCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToolTypeCreate([Bind(Include = "ToolTypeId,Name")] ToolType toolType)
        {
            if (ModelState.IsValid)
            {
                db.ToolTypes.Add(toolType);
                db.SaveChanges();
                return RedirectToAction("ToolTypes");
            }

            return View(toolType);
        }
        public ActionResult ToolTypeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToolType toolType = db.ToolTypes.Find(id);
            if (toolType == null)
            {
                return HttpNotFound();
            }
            return View(toolType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToolTypeEdit([Bind(Include = "ToolTypeId,Name")] ToolType toolType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toolType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ToolTypes");
            }
            return View(toolType);
        }
        public ActionResult ToolTypeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToolType toolType = db.ToolTypes.Find(id);
            if (toolType == null)
            {
                return HttpNotFound();
            }
            return View(toolType);
        }
        [HttpPost, ActionName("ToolTypeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ToolTypeDeleteConfirmed(int id)
        {
            ToolType toolType = db.ToolTypes.Find(id);
            db.ToolTypes.Remove(toolType);
            db.SaveChanges();
            return RedirectToAction("ToolTypes");
        }
        //tool
        public ActionResult Tools()
        {
            var tools = db.Tools.Include(b => b.Manufacturer).Include(b => b.ToolType);
            return View(tools.ToList());
        }
        public ActionResult ToolDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }
        public ActionResult ToolCreate()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name");
            ViewBag.ToolTypeId = new SelectList(db.ToolTypes, "ToolTypeId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToolCreate([Bind(Include = "ToolId,SerialNumber,Model,ManufacturerId,ToolTypeId")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.Tools.Add(tool);
                db.SaveChanges();
                return RedirectToAction("Tools");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", tool.ManufacturerId);
            ViewBag.ToolTypeId = new SelectList(db.ToolTypes, "ToolTypeId", "Name", tool.ToolTypeId);
            return View(tool);
        }
        public ActionResult ToolEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", tool.ManufacturerId);
            ViewBag.ToolTypeId = new SelectList(db.ToolTypes, "ToolTypeId", "Name", tool.ToolTypeId);
            return View(tool);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToolEdit([Bind(Include = "ToolId,SerialNumber,Model,ManufacturerId,ToolTypeId")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Tools");
            }
            ViewBag.ToolTypeId = new SelectList(db.ToolTypes, "ToolTypeId", "Name", tool.ToolTypeId);
            return View(tool);
        }
        public ActionResult ToolDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }
        [HttpPost, ActionName("ToolDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ToolDeleteConfirmed(int id)
        {
            Tool tool = db.Tools.Find(id);
            db.Tools.Remove(tool);
            db.SaveChanges();
            return RedirectToAction("Tools");
        }
        //workreason
        public ActionResult WorkReasons()
        {
            return View(db.WorkReasons.ToList());
        }
        public ActionResult WorkReasonCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkReasonCreate([Bind(Include = "WorkReasonId,Name")] WorkReason workReason)
        {
            if (ModelState.IsValid)
            {
                db.WorkReasons.Add(workReason);
                db.SaveChanges();
                return RedirectToAction("WorkReasons");
            }

            return View(workReason);
        }
        public ActionResult WorkReasonEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkReason workReason = db.WorkReasons.Find(id);
            if (workReason == null)
            {
                return HttpNotFound();
            }
            return View(workReason);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkReasonEdit([Bind(Include = "WorkReasonId,Name")] WorkReason workReason)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workReason).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WorkReasons");
            }
            return View(workReason);
        }
        public ActionResult WorkReasonDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkReason workReason = db.WorkReasons.Find(id);
            if (workReason == null)
            {
                return HttpNotFound();
            }
            return View(workReason);
        }
        [HttpPost, ActionName("WorkReasonDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult WorkReasonDeleteConfirmed(int id)
        {
            WorkReason workReason = db.WorkReasons.Find(id);
            db.WorkReasons.Remove(workReason);
            db.SaveChanges();
            return RedirectToAction("WorkReasons");
        }
        //devicetype
        public ActionResult DeviceTypes()
        {
            return View(db.DeviceTypes.ToList());
        }
        public ActionResult DeviceTypeCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeviceTypeCreate([Bind(Include = "DeviceTypeId,Name")] DeviceType deviceType)
        {
            if (ModelState.IsValid)
            {
                db.DeviceTypes.Add(deviceType);
                db.SaveChanges();
                return RedirectToAction("DeviceTypes");
            }

            return View(deviceType);
        }
        public ActionResult DeviceTypeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceType deviceType = db.DeviceTypes.Find(id);
            if (deviceType == null)
            {
                return HttpNotFound();
            }
            return View(deviceType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeviceTypeEdit([Bind(Include = "DeviceTypeId,Name")] DeviceType deviceType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DeviceTypes");
            }
            return View(deviceType);
        }
        public ActionResult DeviceTypeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceType deviceType = db.DeviceTypes.Find(id);
            if (deviceType == null)
            {
                return HttpNotFound();
            }
            return View(deviceType);
        }
        [HttpPost, ActionName("DeviceTypeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeviceTypeDeleteConfirmed(int id)
        {
            DeviceType deviceType = db.DeviceTypes.Find(id);
            db.DeviceTypes.Remove(deviceType);
            db.SaveChanges();
            return RedirectToAction("DeviceTypes");
        }
        //devicemodel
        public ActionResult DeviceModels()
        {
            var deviceModels = db.DeviceModels.Include(b => b.Manufacturer).Include(b => b.DeviceType);
            return View(deviceModels.ToList());
        }
        public ActionResult DeviceModelDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return HttpNotFound();
            }
            return View(deviceModel);
        }
        public ActionResult DeviceModelCreate()
        {
            ViewBag.DeviceTypeId = new SelectList(db.DeviceTypes, "DeviceTypeId", "Name");
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeviceModelCreate([Bind(Include = "DeviceModelId,Name,Power,InputVoltage,OutputVoltage,InputCurrent,OutputCurrent,InputPhaseNumber,OutputPhaseNumber,ManufacturerId,DeviceTypeId")] DeviceModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                db.DeviceModels.Add(deviceModel);
                db.SaveChanges();
                return RedirectToAction("DeviceModels");
            }

            ViewBag.DeviceTypeId = new SelectList(db.DeviceTypes, "DeviceTypeId", "Name", deviceModel.DeviceTypeId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", deviceModel.ManufacturerId);
            return View(deviceModel);
        }
        public ActionResult DeviceModelEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeviceTypeId = new SelectList(db.DeviceTypes, "DeviceTypeId", "Name", deviceModel.DeviceTypeId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", deviceModel.ManufacturerId);
            return View(deviceModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeviceModelEdit([Bind(Include = "DeviceModelId,Name,Power,InputVoltage,OutputVoltage,InputCurrent,OutputCurrent,InputPhaseNumber,OutputPhaseNumber,ManufacturerId,DeviceTypeId")] DeviceModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DeviceModels");
            }
            ViewBag.DeviceTypeId = new SelectList(db.DeviceTypes, "DeviceTypeId", "Name", deviceModel.DeviceTypeId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", deviceModel.ManufacturerId);
            return View(deviceModel);
        }
        public ActionResult DeviceModelDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return HttpNotFound();
            }
            return View(deviceModel);
        }
        [HttpPost, ActionName("DeviceModelDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeviceModelDeleteConfirmed(int id)
        {
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            db.DeviceModels.Remove(deviceModel);
            db.SaveChanges();
            return RedirectToAction("DeviceModels");
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
