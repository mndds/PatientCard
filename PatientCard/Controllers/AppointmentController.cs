using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCard.Models;
using PatientCard.Repository;

namespace PatientCard.Controllers {
    public class AppointmentController : Controller {

        ApplicationContext db;

        public AppointmentController(ApplicationContext context) {
            db = context;
            if (!db.Doctors.Any()) {
                Doctor doc1 = new Doctor() { Specialist= "ЛОР", FirstName = "Тест1", LastName = "Тест1" };
                Doctor doc2 = new Doctor() { Specialist= "Терапевт", FirstName = "Тест2", LastName = "Тест2" };
                db.Doctors.AddRange(doc1,doc2);
                db.SaveChanges();
            }
        }
        public IActionResult Index() {

           
            ViewBag.Clients = db.Clients.ToList();       
            ViewBag.Doctors = db.Doctors.ToList();

            try {
                var res = db.Appointments.Include("Doctor").Include("Client").ToList();
                return View(res);
            } catch (Exception ex) {
                return Content(ex.Message);
            }         
        }

        public IActionResult Create() {
            return PartialView("_AppointmentPartialView", new Appointment());
        }


        [HttpPost]
        public IActionResult Create(Appointment appointment, string doctorId, string clientId) {
            try {
                if (ModelState.IsValid) {
                    appointment.DoctorId = Convert.ToInt32(doctorId);
                    appointment.ClientId = Convert.ToInt32(clientId);
                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Appointment");
                }
                return View("Index",appointment);
            } catch (Exception ex) {
                return Content(ex.Message);                
            }           
        }

        public IActionResult Delete(int? id) {
            try {
                if (id != null) {
                    Appointment? appointment = db.Appointments.FirstOrDefault(p => p.id == id);
                    if (appointment != null) {
                        return PartialView("_DeleteAppointmentPartialView", appointment);
                    }
                }
                return NotFound();
            } catch (Exception ex) {
                return Content(ex.Message);
            }            
        }

        [HttpPost]
        public IActionResult Delete(Appointment appointment) {
            try {
                db.Appointments.Remove(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            } catch (Exception ex) {
                return Content(ex.Message);
            }
        }
    }
}
