using EmployeeModels;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public interface IEmployeeRepo
    {
        bool DeleteEmployeeDetail(EmployeeInfo employeeInfo);
        IEnumerable<EmployeeInfo> getAllEmployeeDetails();
        IEnumerable<EmployeeInfo> getEmployeeDetail(EmployeeInfo employeeInfo);
        bool InsertEmployeeDetail(EmployeeInfo employeeInfo);
    }
}