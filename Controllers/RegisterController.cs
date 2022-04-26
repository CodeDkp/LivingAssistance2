using LivingAssistance2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivingAssistance2.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Index(RegisterOption op)
        {
            if (op.Option == "Patient")
                return RedirectToAction("Patient");
            if (op.Option == "Caregiver")
                return RedirectToAction("Caregiver");
            else
                return RedirectToAction("Index");
        }

        public IActionResult Patient()
        {
            return View();
        }
        [HttpPut]
        public IActionResult Patient(PatientDetail patientDetail)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Caregiver()
        {
            return View();
        }
        [HttpPut]
        public IActionResult Caregiver(CareGiver careGiver)
        {
            return RedirectToAction("Index");
        }
    }
}
