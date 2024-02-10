using Microsoft.AspNetCore.Mvc;
using MedicationAPI.Model;
using MedicationAPI.Repository;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;



namespace MedicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController : Controller
    {
        [HttpGet(Name = "GetMedication")]
        public IEnumerable<Medication> GetMedications()
        {
            MedicationRepository medRepo = new MedicationRepository();
            return medRepo.GetMedications();
        }
        [HttpGet("{id:int}")]
        public Medication GetMedication(int id)
        {
            MedicationRepository medRepo = new MedicationRepository();
            return medRepo.GetMedication(id);

        }
    }
}
