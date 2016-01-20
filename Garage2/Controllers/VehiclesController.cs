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

        public ActionResult Index(string searchString, string sortOrder )
        {

            ViewBag.TypeSortParm = sortOrder == "type_desc" ? "type_asc" : "type_desc";
            ViewBag.RegNrSortParm = sortOrder == "regnr_desc" ? "regnr_asc" : "regnr_desc";
            ViewBag.BrandSortParm = sortOrder == "brand_desc" ? "brand_asc" : "brand_desc";
            ViewBag.CheckinTimeSortParm = sortOrder == "checkintime_desc" ? "checkintime_asc" : "checkintime_desc";
            ViewBag.ParkingTimeSortParm = sortOrder == "parkingtime_desc" ? "parkingtime_asc" : "parkingtime_desc";
            ViewBag.SearchString = searchString;

            var vehicle = from v in db.Vehicles
                          select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicle = vehicle.Where(s => s.RegNr.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "regnr_desc":
                    vehicle = vehicle.OrderByDescending(v => v.RegNr);
                    break;
                case "regnr_asc":
                    vehicle = vehicle.OrderBy(v => v.RegNr);
                    break;
                case "type_desc":
                    vehicle = vehicle.OrderByDescending(v => v.Type);
                    break;
                case "type_asc":
                    vehicle = vehicle.OrderBy(v => v.Type);
                    break;
                case "brand_desc":
                    vehicle = vehicle.OrderByDescending(v => v.Brand);
                    break;
                case "brand_asc":
                    vehicle = vehicle.OrderBy(v => v.Brand);
                    break;
                case "checkintime_desc":
                    vehicle = vehicle.OrderByDescending(v => v.CheckInTime);
                    break;
                case "checkintime_asc":
                    vehicle = vehicle.OrderBy(v => v.CheckInTime);
                    break;
                case "parkingtime_desc":
                    vehicle = vehicle.OrderByDescending(v => v.CheckInTime);
                    break;
                case "parkingtime_asc":
                    vehicle = vehicle.OrderBy(v => v.CheckInTime);
                    break;

                default:
                    vehicle = vehicle.OrderBy(v => v.Type);
                    break;
            }

            return View(vehicle);

       
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
