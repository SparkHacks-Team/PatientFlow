using Microsoft.AspNetCore.Mvc;
using PatientAPI.Model;
using PatientAPI.Repository;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;


namespace PatientAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : Controller
    {

        [HttpPost(Name = "Add")]
        public void AddPatient(Patient pat)
        {
            PatientRepository patRepo = new PatientRepository();
            patRepo.AddPatient(pat);
        }
    }
}
