using EmployeeModels;
using System.Collections.Generic;

namespace EmployeeBusinessLogicLayer
{
    public interface IEmployeeBusiness
    {
        bool DeleteEmployeeDetail(EmployeeInfo employeeInfo);
        IEnumerable<EmployeeInfo> getAllEmployeeDetails();
        IEnumerable<EmployeeInfo> getEmployeeDetail(EmployeeInfo employeeInfo);
        bool InsertEmployeeDetail(EmployeeInfo employeeInfo);
    }
}