using MartinGrove_API.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MartinGrove_API.Controllers
{
    public class EmployeesController : ApiController
    {
        public IQueryable<Employee> Get()
        {
            using(EmployeeDBContext ent = new EmployeeDBContext())
            {
                return ent.Employees;
            }
        }

    }
}
