using System;
using System.Net.Http;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Client
{
    public class Program
    {
        public class Employee
        {
            public int EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }
        }

        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:31434");

            var newEmployee = new
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Title = "Developer"
            };

            var response = await client.PostAsJsonAsync("/api/employees", newEmployee);
            response.EnsureSuccessStatusCode();
            var createdEmployee = await response.Content.ReadAsAsync<Employee>();
            Console.WriteLine("Новый сотрудник создан:");
            Console.WriteLine($"ID: {createdEmployee.EmployeeId}");
            Console.WriteLine($"Имя: {createdEmployee.FirstName}");
            Console.WriteLine($"Фамилия: {createdEmployee.LastName}");
            Console.WriteLine($"Должность: {createdEmployee.Title}");

            var employeeId = createdEmployee.EmployeeId;
            response = await client.GetAsync($"/api/employees/{employeeId}");
            response.EnsureSuccessStatusCode();
            var retrievedEmployee = await response.Content.ReadAsAsync<Employee>();
            Console.WriteLine("Информация о сотруднике:");
            Console.WriteLine($"ID: {retrievedEmployee.EmployeeId}");
            Console.WriteLine($"Имя: {retrievedEmployee.FirstName}");
            Console.WriteLine($"Фамилия: {retrievedEmployee.LastName}");
            Console.WriteLine($"Должность: {retrievedEmployee.Title}");

            var updatedEmployee = new
            {
                FirstName = "Jane",
                LastName = "Smith",
                Title = "Senior Developer"
            };

            response = await client.PutAsJsonAsync($"/api/employees/{employeeId}", updatedEmployee);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Информация о сотруднике обновлена");

            response = await client.DeleteAsync($"/api/employees/{employeeId}");
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Сотрудник удален");
        }
    }
}

