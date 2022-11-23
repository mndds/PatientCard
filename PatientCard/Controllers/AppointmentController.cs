using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCard.Models;
using PatientCard.Repository;

namespace PatientCard.Controllers {
    public class AppointmentController : Controller {

        ApplicationContext db;

        public AppointmentController(ApplicationContext context) {
            db = context;
        }
        public IActionResult Index() {       
            
            //Реализация с помощью DropDown в 4-5 раз больше запросов
            //ViewBag.Clients = db.Clients.ToList();
            //ViewBag.Doctors = db.Doctors.ToList();

            var res = db.Appointments.Include("Doctor").Include("Client").ToList();
            return View(res);

        }

        public IActionResult Create() {
            return PartialView("_AppointmentPartialView", new Appointment());
        }


        [HttpPost]
        public IActionResult Create(Appointment appointment) { 

            if (ModelState.IsValid) {               
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index", "Appointment");
            }
            return View(appointment);

        }

        public IActionResult Delete(int? id) {
            if (id != null) {
                Appointment? appointment = db.Appointments.FirstOrDefault(p => p.id == id);
                if (appointment != null) {
                    return PartialView("_DeleteAppointmentPartialView", appointment);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(Appointment appointment) {
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
