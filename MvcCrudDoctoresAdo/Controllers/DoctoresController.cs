using Microsoft.AspNetCore.Mvc;
using MvcCrudDoctoresAdo.Respository;
using MvcCrudDoctoresAdo.Models;

namespace MvcCrudDoctoresAdo.Controllers
{
    public class DoctoresController : Controller
    {
        private RespositoryDoctor repo;

        public DoctoresController()
        {
            this.repo = new RespositoryDoctor();
        }
        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        public IActionResult Details(int iddoctor)
        {
            Doctor doctor = this.repo.FindDoctor(iddoctor);
            return View(doctor);
        }

        public IActionResult Create()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            this.repo.InsertDoctor(doctor.IdHospital, doctor.IdDoctor
                , doctor.Apellido, doctor.Especialidad, doctor.Salario);
   
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int iddoctor)
        {
            this.repo.DeleteDoctor(iddoctor);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int iddoctor)
        {
            Doctor doctor = this.repo.FindDoctor(iddoctor);

            return View(doctor);
        }

        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            this.repo.UpdateDoctor(doctor.IdHospital, doctor.IdDoctor
                , doctor.Apellido, doctor.Especialidad, doctor.Salario);
            return RedirectToAction("Index");
        }
    }
}
