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
        [HttpGet(Name = "GetPatient")]
        public IEnumerable<Patient> GetPatient()
        {
            PatientRepository patRepo = new PatientRepository();
            return patRepo.GetPatients();
        }

        [HttpPost(Name = "Add")]
        public void AddPatient(Patient pat)
        {
            PatientRepository patRepo = new PatientRepository();
            patRepo.AddPatient(pat);
        }
        [HttpPut(Name = "Edit")]
        public void EditPatient(Patient pat)
        {
            PatientRepository patRepo = new PatientRepository();
            patRepo.UpdatePatient(pat);
        }

        [HttpDelete(Name = "Delete")]
        public void DeletePatient(int id)
        {
            PatientRepository patRepo = new PatientRepository();
            patRepo.DeletePatient(id);
        }

        [HttpGet("{id:int}")]
        public Patient GetEmployee(int id)
        {
            PatientRepository patRepo = new PatientRepository();
            return patRepo.GetPatient(id);

        }
    }
}
