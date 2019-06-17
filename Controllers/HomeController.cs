using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test2.Context;
using test2.Models;

namespace test2.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller


    {
        private readonly EmployeeDbContext employeeDbContext;

        public HomeController(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        public ActionResult Index()
        {

            return Ok(this.employeeDbContext.Employees.ToList());
            //return View();
        }


        [HttpGet("TestInsert")]
        public ActionResult TestInsert()
        {

            var employee = new Employee()
            {
                Name = "Test" + DateTime.Now.Millisecond.ToString(),
                CompanyName = "test",
                //Address = " trst",
                Designation = "sdsad",
            };


            this.employeeDbContext.Add(employee);

            this.employeeDbContext.SaveChanges();
        

            return Ok(employee);

        }



    }
}
