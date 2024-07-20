using AmericanSpecialtyHealth.DTO;
using AmericanSpecialtyHealth.Models;

namespace AmericanSpecialtyHealth.Services;

public class EmployeeService : IEmployeeService {
    public IEnumerable<EmployeeDto> GetAllEmployees() {
        //use db context to make the call
        // e.g. var employees = _dbContext.GetAllEmployees(sqlQuery);
        var employees = new List<Employee>();

        var employeeDto = employees.Select(employee => {
            var dto = new EmployeeDto {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address1 = employee.Address1,
                RoleDesc = employee.RoleDesc,
                AnnualSalary = null,
                PayPerHour = null,
                MaxExpenseAmount = null
            };

            if (employee is HourlyEmployee hourlyEmployee) {
                dto.PayPerHour = hourlyEmployee.PayPerHour;
            }

            if (employee is Supervisor supervisor) {
                dto.AnnualSalary = supervisor.AnnualSalary;
            }

            if (employee is Manager manager) {
                dto.AnnualSalary = manager.AnnualSalary;
                dto.MaxExpenseAmount = manager.MaxExpenseAmount;
            }

            return dto;
        }).ToList();

        return employeeDto;
    }

    public void AddEmployee(EmployeeDto employee) {
        switch (employee.RoleDesc) {
            case "Manager":
                var manager = new Manager {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address1 = employee.Address1,
                    AnnualSalary = employee.AnnualSalary,
                    MaxExpenseAmount = employee.MaxExpenseAmount
                };
                // Insert manager into the database
                break;

            case "Supervisor":
                var supervisor = new Supervisor {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address1 = employee.Address1,
                    AnnualSalary = employee.AnnualSalary
                };
                // Insert supervisor into the database
                break;

            case "Hourly":
                var hourlyEmployee = new HourlyEmployee {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address1 = employee.Address1,
                    PayPerHour = employee.PayPerHour
                };
                // Insert hourlyEmployee into the database
                break;

            default:
                throw new ArgumentException("Invalid role description");
        }
    }
}