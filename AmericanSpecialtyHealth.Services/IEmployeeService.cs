using AmericanSpecialtyHealth.DTO;

namespace AmericanSpecialtyHealth.Services {
    public interface IEmployeeService {
        IEnumerable<EmployeeDto> GetAllEmployees();
        void AddEmployee(EmployeeDto employee);
    }
}