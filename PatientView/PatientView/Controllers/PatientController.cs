using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientView.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Text;
using Dapper;
using Microsoft.Identity.Client;
using System.Net.Http.Formatting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PatientView.Controllers
{
    public class PatientController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Patient> pat = null;


            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:7277/");
                //HTTP GET
                var responseTask = client.GetAsync("Patient");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Patient>>();
                    readTask.Wait();
                    pat = readTask.Result;
                    

                }
                else 
                {

                    pat = Enumerable.Empty<Patient>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(pat);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Patient pat = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7277/");
                var responseTask = client.GetAsync("Patient/" + id.ToString());
                responseTask.Wait();
                //var departments = GetDepartments();
                //ViewBag.Departments = new SelectList(departments, "ID", "DepartmentName");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Patient>();
                    readTask.Wait();
                    pat = readTask.Result;
                }
            }
            return View(pat);
        }

        [HttpPost]
        public ActionResult Edit(IFormCollection formCollection)
        {
            Patient pat = new Patient();
            pat.Patient_ID = Convert.ToInt32(formCollection["Patient_ID"]);
            pat.FirstName = formCollection["FirstName"];
            pat.LastName = formCollection["LastName"];
            pat.Gender = formCollection["Gender"];
            pat.Age = Convert.ToInt32(formCollection["Age"]);
            return EditPatient(pat);
        }
        private ActionResult EditPatient(Patient pat)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7277");
                var putTask = client.PutAsJsonAsync<Patient>("/Patient", pat);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(IFormCollection formCollection)
        {
            //foreach(string key in formCollection.All)
            //var formKeys = Request.Form.Keys;
            Patient pat = new Patient();
            pat.FirstName = formCollection["FirstName"];
            pat.LastName = formCollection["LastName"];
            pat.Gender = formCollection["Gender"];
            pat.Age = Convert.ToInt32(formCollection["Age"]);
            //InsertEmployee(emp);

            return InsertPatient(pat);
        }
        private ActionResult InsertPatient(Patient pat)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7277/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Patient>("Patient", pat);
                //postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
