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
            return View(db.Clients.ToList());
        }

        public IActionResult Create() {
            return PartialView("_ClientPartialView", new Client());
        }

        [HttpPost]
        public IActionResult Create(Client client) {
            try {
                if (ModelState.IsValid) {
                    db.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Client");
                }
                return View(client);
            } catch (Exception ex) {
                return Content(ex.Message);
            }                   
        }

        public IActionResult Edit(int? id) {
            try {
                if (id != null) {
                    Client? client = db.Clients.FirstOrDefault(p => p.Id == id);
                    if (client != null) {
                        return PartialView("_EditClientPartialView", client);
                    }
                }
                return NotFound();
            } catch (Exception ex) {
                return Content(ex.Message);
            }            
        }

        [HttpPost]
        public IActionResult Edit(Client client) {
            try {
                if (ModelState.IsValid) {
                    db.Clients.Update(client);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Client");
                }
                return View(client);
            } catch (Exception ex) {
                return Content(ex.Message);
            }        
        }
        
        public IActionResult Delete(int? id) {
            try {
                if (id != null) {
                    Client? client = db.Clients.FirstOrDefault(p => p.Id == id);
                    if (client != null) {
                        return PartialView("_DeleteClientPartialView", client);
                    }
                }
                return NotFound();
            } catch (Exception ex) {
                return Content(ex.Message);
            }            
        }

        [HttpPost]
        public IActionResult Delete(Client client) {
            try {
                db.Clients.Remove(client);
                db.SaveChanges();
                return RedirectToAction("Index", "Client");
            } catch (Exception ex) {
                return Content(ex.Message);
            }                 
        }
    }
}
