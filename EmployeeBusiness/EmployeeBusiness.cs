using ClassLibrary1;
using EmployeeModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeBusinessLogicLayer
{
    public class EmployeeBusiness : IEmployeeBusiness
    {

        IEmployeeRepo employeeRepo;
       
        public EmployeeBusiness(IEmployeeRepo iemployeeRepo)
        {
            employeeRepo = iemployeeRepo;
        }

        public IEnumerable<EmployeeInfo> getAllEmployeeDetails()
        {

            return employeeRepo.getAllEmployeeDetails().OrderBy(x=>x.EmployeeID);

        }


        public IEnumerable<EmployeeInfo> getEmployeeDetail(EmployeeInfo employeeInfo)
        {

            return employeeRepo.getEmployeeDetail(employeeInfo);


        }
        public Boolean InsertEmployeeDetail(EmployeeInfo employeeInfo)
        {

            return employeeRepo.InsertEmployeeDetail(employeeInfo);

        }

        public Boolean DeleteEmployeeDetail(EmployeeInfo employeeInfo)
        {

            return employeeRepo.DeleteEmployeeDetail(employeeInfo);

        }
    }
}
