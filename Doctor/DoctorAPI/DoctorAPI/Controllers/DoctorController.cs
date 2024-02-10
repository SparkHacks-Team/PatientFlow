using Microsoft.AspNetCore.Mvc;
using DoctorAPI.Model;
using DoctorAPI.Repository;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
namespace DoctorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : Controller
    {
        [HttpGet(Name = "GetDoctor")]
        public IEnumerable<Doctor> GetDoctors()
        {
            DoctorRepository docRepo = new DoctorRepository();
            return docRepo.GetDoctors();
        }
        [HttpPost(Name = "Add")]
        public void AddDoctor(Doctor doc)
        {
            DoctorRepository docRepo = new DoctorRepository();
            docRepo.AddDoctor(doc);
        }

        [HttpPut(Name = "Edit")]
        public void EditDoctor(Doctor doc)
        {
            DoctorRepository docRepo = new DoctorRepository();
            docRepo.UpdateDoctor(doc);
        }
        [HttpGet("{id:int}")]
        public Doctor GetDoctor(int id)
        {
            DoctorRepository docRepo = new DoctorRepository();
            return docRepo.GetDoctor(id);

        }
    }
}
