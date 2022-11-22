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


            //Работает!!! Сохраняет в таблицу
            //Client? client = db.Clients.FirstOrDefault(p => p.Id == 1);
            //Doctor doct = db.Doctors.FirstOrDefault(p => p.Id == 1);
            //client.Appointments.Add(new Appointment { Doctor= doct, Complaints="uJH", CreatedDate=new DateTime(2022,11,11), Diagnosis = "Горло" });
            //db.SaveChanges();



            //robit add row to appointment
            /*Client? client = db.Clients.FirstOrDefault(p => p.Id == 1);
            Doctor doct = db.Doctors.FirstOrDefault(p => p.Id == 1);
            var res = db.Appointments.Add(new Appointment { Doctor = doct, Client = client, Complaints="UHO", Diagnosis="ORVI", CreatedDate = new DateTime(2022, 11, 11) });
            db.SaveChanges()*/;
            //return View(db.Appointments.ToList()));

            var res = db.Appointments.Include("Doctor").Include("Client").ToList();

            //TODO
            //Реализация с помощью DropDown в 4-5 раз больше запросов
            //ViewBag.Clients = db.Clients.ToList();
            //ViewBag.Doctors = db.Doctors.ToList();
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
