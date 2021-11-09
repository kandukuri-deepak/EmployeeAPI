using ClassLibrary1;
using EmployeeBusinessLogicLayer;
using EmployeeModels;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmployeeUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        public Mock<IEmployeeRepo> MockObject;

        public UnitTest1()
        {
            MockObject = new Mock<IEmployeeRepo>();
        }

        [TestMethod]
        [DataRow("[{\"EmployeeID\":1001,\"EmployeeName\":\"Dhoni\",\"EmployeeDesignation\":\"Player\",\"EmployeeSalary\":10000.0000,\"EmployeeYearsOfExperience\":16},{\"EmployeeID\":1002,\"EmployeeName\":\"Dravid\",\"EmployeeDesignation\":\"Player\",\"EmployeeSalary\":80000.0000,\"EmployeeYearsOfExperience\":20},{\"EmployeeID\":1003,\"EmployeeName\":\"kohli\",\"EmployeeDesignation\":\"Player\",\"EmployeeSalary\":150000.0000,\"EmployeeYearsOfExperience\":14},{\"EmployeeID\":1004,\"EmployeeName\":\"Rohit\",\"EmployeeDesignation\":\"Player\",\"EmployeeSalary\":70000.0000,\"EmployeeYearsOfExperience\":15},{\"EmployeeID\":1005,\"EmployeeName\":\"Ravi\",\"EmployeeDesignation\":\"coach\",\"EmployeeSalary\":1245670.0000,\"EmployeeYearsOfExperience\":7}]")]

        public void getAllEmployeeDetails(string dboutput)
        {
            EmployeeBusiness employeeBusiness = new EmployeeBusiness(MockObject.Object);
            IEnumerable<EmployeeInfo> deserializedOutput = JsonConvert.DeserializeObject<IEnumerable<EmployeeInfo>>(dboutput);
            MockObject.Setup(x => x.getAllEmployeeDetails()).Returns(deserializedOutput);
            IEnumerable<EmployeeInfo> output = employeeBusiness.getAllEmployeeDetails();
            Assert.IsNotNull(output);
        }

        [TestMethod]
        [DataRow("[{\"EmployeeID\":1001,\"EmployeeName\":\"Dhoni\",\"EmployeeDesignation\":\"Player\",\"EmployeeSalary\":10000.0000,\"EmployeeYearsOfExperience\":16}]")]
        public void getEmployeeDetail(string dboutput)
        {
            EmployeeBusiness employeeBusiness = new EmployeeBusiness(MockObject.Object);
            IEnumerable<EmployeeInfo> deserializedOutput = JsonConvert.DeserializeObject<IEnumerable<EmployeeInfo>>(dboutput);
            MockObject.Setup(x => x.getEmployeeDetail(new EmployeeInfo ())).Returns(deserializedOutput);
            IEnumerable<EmployeeInfo> output = employeeBusiness.getEmployeeDetail(new EmployeeInfo { EmployeeID = 1 });
            Assert.IsNotNull(output);
        }


        [TestMethod]
        
        public void InsertEmployeeDetail()
        {
            EmployeeBusiness employeeBusiness = new EmployeeBusiness(MockObject.Object);
            MockObject.Setup(x => x.InsertEmployeeDetail(new EmployeeInfo ())).Returns(true);
           bool output= employeeBusiness.InsertEmployeeDetail(new EmployeeInfo());
            Assert.IsNotNull(output);
        }


        [TestMethod]
        public void DeleteEmployeeDetail()
        {
            EmployeeBusiness employeeBusiness = new EmployeeBusiness(MockObject.Object);
            MockObject.Setup(x => x.DeleteEmployeeDetail(new EmployeeInfo())).Returns(true);
            bool output = employeeBusiness.DeleteEmployeeDetail(new EmployeeInfo());
            Assert.IsNotNull(output);
        }
    }
}
