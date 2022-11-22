using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCard.Models;
using PatientCard.Repository;
using System.Diagnostics;
namespace PatientCard.Controllers {
    public class ClientController : Controller {

        ApplicationContext db;

        public ClientController(ApplicationContext context) {
            db = context;
        }
        public IActionResult Index() {
            return View( db.Clients.ToList());
        }

        public IActionResult Create() {
            return PartialView("_ClientPartialView", new Client());
        }

        [HttpPost]
        public IActionResult Create(Client client) {
            if (ModelState.IsValid) {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index", "Client");
            }
            return View(client);        
        }


        public IActionResult Edit(int? id) {
            if (id != null) {
                Client? client = db.Clients.FirstOrDefault(p => p.Id == id);
                if (client != null) {
                    return PartialView("_EditClientPartialView", client);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Client client) {
            if (ModelState.IsValid) {
                db.Clients.Update(client);
                db.SaveChanges();
                return RedirectToAction("Index", "Client");
            }
            return View(client);
        }
        
        public IActionResult Delete(int? id) {
            if (id != null) {
                Client? client = db.Clients.FirstOrDefault(p => p.Id == id);
                if (client != null) {                   
                    return PartialView("_DeleteClientPartialView", client);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(Client client) {
            
                db.Clients.Remove(client);
                db.SaveChanges();
                return RedirectToAction("Index", "Client");
            
            
        }





    }
}
