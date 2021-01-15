using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AsmStudentClient.Controllers
{
    public class HomeController : Controller
    {
        private ServiceReference1.ServiceClient client;
        public HomeController()
        {
            client = new ServiceReference1.ServiceClient();
        }
       
        public ActionResult Index()
        {
            return View(client.GetStudents());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RollNumber,Name,Birthday,Gender,Email,Description")] AsmStudentClient.ServiceReference1.Student student)
        {
            if (ModelState.IsValid)
            {
                client.Add(student);
                TempData["message"] = "Action Success!";
                return RedirectToAction("Index");
            }
            ViewData["Message"] = "Action failed";
            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsmStudentClient.ServiceReference1.Student student = client.getDetailStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RollNumber,Name,Birthday,Gender,Email,Description")] AsmStudentClient.ServiceReference1.Student student)
        {
            if (ModelState.IsValid)
            {
                if (client.updateStudent(student))
                {
                    TempData["message"] = "Action Success!";
                    return RedirectToAction("Index");
                }
                TempData["message"] = "Action Fail!";
                return View(student);
            }
            return View(student);
        }
    }
}