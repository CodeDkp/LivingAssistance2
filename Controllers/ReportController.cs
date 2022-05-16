using LivingAssistance2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LivingAssistance2.Controllers
{
    public class ReportController : Controller
    {
        private readonly ORGContext _context;

        public ReportController(ORGContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "CareGiver")]
        public IActionResult Index(Report R)
        {
            if(R.Name != null)
            {
                ViewBag.GridData = GetData(R);
                return View("Display");
            }
            else {
                return View();
            }
        }

        //public IActionResult Display(Report R)
        //{
        //    return View();
        //}

        private List<ReportDetail> GetData(Report R)
        {

            SqlConnection con = new SqlConnection("Data Source=192.168.6.196; Initial Catalog=ORG; user id=Tanya;password=Tanya@123");
            List<ReportDetail> stud = new List<ReportDetail>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Search_Procedure";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            SqlParameter param1 = new SqlParameter
            {
                ParameterName = "@usertype",
                SqlDbType = SqlDbType.NVarChar,
                Value = R.Usertype,
                Direction = ParameterDirection.Input
            };
            SqlParameter param2 = new SqlParameter
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.NVarChar,
                Value = R.Name,
                Direction = ParameterDirection.Input
            };
            SqlParameter param3 = new SqlParameter
            {
                ParameterName = "@address",
                SqlDbType = SqlDbType.NVarChar,
                Value = R.Address,
                Direction = ParameterDirection.Input
            };
            SqlParameter param4 = new SqlParameter
            {
                ParameterName = "@date1",
                SqlDbType = SqlDbType.Date,
                Value = R.dt1,
                Direction = ParameterDirection.Input
            };
            SqlParameter param5 = new SqlParameter
            {
                ParameterName = "@date2",
                SqlDbType = SqlDbType.Date,
                Value = R.dt2,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                stud.Add(new ReportDetail
                {
                    Patient = Convert.ToString(sqlDataReader["Fname"]),
                    Address = Convert.ToString(sqlDataReader["Address"]),
                    CareGive = Convert.ToString(sqlDataReader["care"]),
                    Services = Convert.ToString(sqlDataReader["Services_Req"]),
                    Experience = Convert.ToInt32(sqlDataReader["Experiance"]),
                    VerificationStatus = Convert.ToString(sqlDataReader["VFStatus"]),
                });
            }
            return stud;

        }
    }
}
