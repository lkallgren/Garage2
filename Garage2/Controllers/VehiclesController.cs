using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.Models;


namespace Garage2.Controllers
{
    public class VehiclesController : Controller
    {
        private Garage2Context db = new Garage2Context();
        private Vehicle tmpVehicle;

        // GET: Vehicles

        public ActionResult Index(string searchString)
        {
            var vehicle = from v in db.Vehicles
                          select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicle = vehicle.Where(s => s.RegNr.Contains(searchString));
            }
            return View(vehicle);
            
          //Sort start

        //  public ActionResult Index(string sortOrder)
        //{
        //    List<Vehicle> sortVehicles = db.Vehicles.ToList();

        //    ViewBag.TypeSortParm = sortOrder == "type_desc" ? "Type" : "type_desc";
        //    ViewBag.RegNrSortParm = sortOrder == "regnr_desc" ? "RegNr" : "regnr_desc";
        //    ViewBag.BrandSortParm = sortOrder == "brand_desc" ? "Brand" : "brand_desc";
        //    ViewBag.CheckinTimeSortParm = sortOrder == "checkintime_desc" ? "Date" : "checkintime_desc";
            

        //     var vehicles = from v in db.Vehicles
        //          select v;
        //            switch (sortOrder)
        //            {
        //                case "regnr_desc":
        //                    vehicles = vehicles.OrderByDescending(v => v.RegNr);
        //                    break;
        //                case "RegNr":
        //                    vehicles = vehicles.OrderBy(v => v.RegNr);
        //                    break;
        //                case "type_desc":
        //                    vehicles = vehicles.OrderByDescending(v => v.Type);
        //                    break;
        //                case "Type":
        //                    vehicles = vehicles.OrderBy(v => v.Type);
        //                    break;
        //                case "brand_desc":
        //                    vehicles = vehicles.OrderByDescending(v => v.Brand);
        //                    break;
        //                case "Brand":
        //                    vehicles = vehicles.OrderBy(v => v.Brand);
        //                    break;
        //                case "checkintime_desc":
        //                    vehicles = vehicles.OrderByDescending(v => v.CheckInTime);
        //                    break;
        //                case "Date":
        //                    vehicles = vehicles.OrderBy(v => v.CheckInTime);
        //                    break;
        //                default:
        //                    vehicles = vehicles.OrderBy(v => v.Type);
        //                    break;
        //            }

        //    return View(vehicles);

       
        }

        // GET: Vehicles/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegNr,Brand,ProdName,Color,Wheels,CheckInTime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.CheckInTime = DateTime.Now;

                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Create");     // Ändrades till "Create" för att skapa loopen.
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegNr,Brand,ProdName,Color,Wheels,CheckInTime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);

        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            tmpVehicle = vehicle;

            db.Vehicles.Remove(vehicle);
            db.SaveChanges();

            // return RedirectToAction("Index");
            return RedirectToAction("Receipe", tmpVehicle);
        }

        public ActionResult Receipe(Vehicle tmp)
        {
            return View(tmp);
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
