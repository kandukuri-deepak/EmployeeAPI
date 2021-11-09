using EmployeeBusinessLogicLayer;
using EmployeeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
       
        private readonly ILogger<EmployeeController> _logger;
        IEmployeeBusiness employeeBusiness;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeBusiness iemployeeBusiness)
        {
            _logger = logger;
            employeeBusiness=iemployeeBusiness;
        }

        [Route("GetToken")]
        [HttpGet]


        public IActionResult GetAuthorizedToken()
        {
            try
            {
                var client = new RestClient("https://dev-yr44od18.us.auth0.com/oauth/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", "{\"client_id\":\"DLOHwLfCvXCr1RFCclx4wjwFsyGbhOLu\",\"client_secret\":\"8OY2-1kXJoF05uAwJrBjNwBo1W4-1Qy4O2oAVf77zQg9_WBEZNvmuUJfqdnhfGLj\",\"audience\":\"https://localhost:44391/\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                return Ok(response.Content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }



        [Route("GetAllEmployeeDetails")]
        [HttpGet]


        public IActionResult GetAllEmployeeDetails()
        {
            try
            {
                
                return Ok(employeeBusiness.getAllEmployeeDetails());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }



        [Route("GetEmployeeDetail")]
        [HttpGet]
        public IActionResult GetEmployeeDetail([FromQuery] int employeeid)
        {
            try
            {
              
                return Ok(employeeBusiness.getEmployeeDetail(new EmployeeInfo {EmployeeID=employeeid }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }



        [Route("InsertEmployeeDetail")]
        [HttpPost]
        [Authorize]
        public IActionResult InsertEmployeeDetail(EmployeeInfo employeeinfo)
        {
            try
            {

                return Ok(employeeBusiness.InsertEmployeeDetail(employeeinfo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [Route("DeleteEmployeeDetail")]
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteEmployeeDetail([FromQuery] int employeeid)
        {
            try
            {

                return Ok(employeeBusiness.DeleteEmployeeDetail(new EmployeeInfo { EmployeeID = employeeid }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

    }
}
