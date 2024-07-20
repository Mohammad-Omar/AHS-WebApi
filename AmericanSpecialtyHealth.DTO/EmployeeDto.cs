using System.Text.Json.Serialization;

namespace AmericanSpecialtyHealth.DTO {
    public class EmployeeDto {
        [JsonPropertyName("employeeId")] public int EmployeeId { get; set; }

        [JsonPropertyName("firstName")] public string FirstName { get; set; }

        [JsonPropertyName("lastName")] public string LastName { get; set; }

        [JsonPropertyName("roleId")] public int RoleId { get; set; }

        [JsonPropertyName("roleDesc")] public string RoleDesc { get; set; }

        [JsonPropertyName("address1")] public string Address1 { get; set; }

        [JsonPropertyName("payPerHour")] public decimal? PayPerHour { get; set; }

        [JsonPropertyName("annualSalary")] public decimal? AnnualSalary { get; set; }

        [JsonPropertyName("maxExpenseAmount")] public decimal? MaxExpenseAmount { get; set; }
    }
}