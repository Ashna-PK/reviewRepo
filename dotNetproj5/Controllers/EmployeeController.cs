using fatWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fatWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static  List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Gender = "Male", City = "New York", Age = 30, Department = "HR" },
            new Employee { Id = 2, Name = "Jane Smith", Gender = "Female", City = "Los Angeles", Age = 25, Department = "Finance" },
            new Employee { Id = 3, Name = "Mike Johnson", Gender = "Male", City = "Chicago", Age = 40, Department = "IT" }
        };

        [HttpGet("Name")]
        public IEnumerable<Employee> GetName()
        {
            return Employees;
        }
        [HttpGet("Details")]
        public Employee GetEmployeeDetails()
        {
            return new Employee()
            {
                Id = 1001,
                Name = "Anurag",
                Age = 28,
                City = "Mumbai",
                Gender = "Male",
                Department = "IT"
            };
        }

        [HttpGet("All")]
        public List<Employee> GetAllEmployee()
        {
            return Employees;
            
        }
        [HttpGet("AllInum")]
        public IEnumerable<Employee> GetAllEmployeeIEnum()
        {
            return new List<Employee>()
            {
                new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
                new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
                new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
            };
        }
        [HttpGet("AllIaction")]
        //As we are going to return Ok, StatusCode, and NotFound Result from this action method
        //So, we are using IActionResult as the return type of this method
        public IActionResult GetAllEmployeeIaction()
        {
            try
            {
                //In Real-Time, you will get the data from the database
                //Here, we have hardcoded the data
                var listEmployees = new List<Employee>()
                {
                    new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
                    new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
                    new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
                };
                //If at least one Employee is Present return OK status code and the list of employees
                if (listEmployees.Any())
                {
                    return Ok(listEmployees);
                }
                else
                {
                    //If no Employee is Present return Not Found Status Code
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while getting all employees.");
                // Return a 500 Internal Server Error status code
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            // Find the employee with the specified ID
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                // If the employee is not found, return a 404 Not Found status with a custom message
                return NotFound(new { message = $"No employee found with ID {id}" });  // NotFoundObjectResult with additional info
            }
            // If the employee is found, return it with a 200 OK status
            return Ok(employee); // OkObjectResult with the employee
        }


        // Create (POST new employee)
        // This action creates a new employee
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            // Validate the employee data
            if (employee == null || string.IsNullOrEmpty(employee.Name))
            {
                // If the data is invalid, return a 400 Bad Request status with a custom message
                return BadRequest(new { Message = "Invalid employee data" }); // BadRequestObjectResult with data
            }
            // Assign a new ID to the employee
            employee.Id = Employees.Count + 1;
            // Add the employee to the list
            Employees.Add(employee);
            // Return a 201 Created status with a location header pointing to the newly created employee
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee); // CreatedAtActionResult
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            // Validate the employee data
            if (employee == null || id != employee.Id)
            {
                // If the data is invalid, return a 400 Bad Request status with a custom message
                return BadRequest(new { Message = "Invalid employee data" }); // BadRequestObjectResult with data
            }
            // Find the existing employee with the specified ID
            var existingEmployee = Employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                // If the employee is not found, return a 404 Not Found status
                return NotFound(); // NotFoundResult
            }
            // Update the employee properties
            existingEmployee.Name = employee.Name;
            existingEmployee.Gender = employee.Gender;
            existingEmployee.City = employee.City;
            existingEmployee.Age = employee.Age;
            existingEmployee.Department = employee.Department;
            // Return a 204 No Content status to indicate that the update was successful
            return NoContent(); // NoContentResult
        }
        // Delete (DELETE employee)
        // This action deletes an employee based on the provided ID
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            // Find the employee with the specified ID
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                // If the employee is not found, return a 404 Not Found status
                return NotFound(); // NotFoundResult
            }
            // Remove the employee from the list
            Employees.Remove(employee);
            // Return a 200 OK status with no content
            return Ok(); // OkResult without data
        }
    }
}
