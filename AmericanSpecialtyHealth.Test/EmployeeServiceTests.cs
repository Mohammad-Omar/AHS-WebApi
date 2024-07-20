using AmericanSpecialtyHealth.Services;

namespace AmericanSpecialtyHealth.Test {
    public class EmployeeServiceTests {
        private readonly EmployeeService _employeeService;

        public EmployeeServiceTests() {
            _employeeService = new EmployeeService();
        }

        [Fact]
        public void GetAllEmployees_ListsAllEmployees() {
            // Act
            var result = _employeeService.GetAllEmployees();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Contains(result, e => e.FirstName == "Mohamamd" && e.RoleDesc == "Employee");
        }
    }
}