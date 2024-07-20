using AmericanSpecialtyHealth.DTO;
using AmericanSpecialtyHealth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AmericanSpecialtyHealth.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees() {
            try {
                var empployees = _employeeService.GetAllEmployees();
                return Ok(empployees);
            }
            catch (Exception e) {
                return StatusCode(500, $"error: {e.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDto employee) {
            if (employee == null) {
                return BadRequest("Employee data is null.");
            }

            try {
                _employeeService.AddEmployee(employee);
                return Ok(employee);
            }
            catch (Exception e) {
                return StatusCode(500, $"error: {e.Message}");
            }
        }
    }
}