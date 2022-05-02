using LivingAssistance2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LivingAssistance2.Controllers
{
    public class ReportController : Controller
    {
        private readonly ORGContext _context;

        public ReportController(ORGContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
           return View();
                       
        }

        public IActionResult Display(Report R)
        {
        //    if(true)
        //    {
        //        string usertype = "Caregiver", name = "minu", address= "Hydrabad", date1= "2021-03-27", date2= "2022-11-27";
        //       var data = _context.PatientDetails.FromSqlRaw("[dbo].[Search_Procedure] @usertype,@name, @Hydrabad,@2021-03-27,@2022-11-27", new SqlParameter("usertype,name,address,date1,date2", usertype,name, address, date1, date2)).ToList();
        //        return View(data);
        //    }
        //    else if(false)
        //    {
        //        string Name = "Raaj";
        //        List<PatientDetail>? data = _context.PatientDetails.FromSqlRaw("[dbo].[SearchPatient] @Name", new SqlParameter("Name", Name)).ToList();
        //        return View();
        //    }
              return View();
        }
    }
}
