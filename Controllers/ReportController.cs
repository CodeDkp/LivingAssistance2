﻿using LivingAssistance2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LivingAssistance2.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Display(Report R)
        {
            return View();
        }
    }
}
