using Microsoft.AspNetCore.Mvc;
using System;

public class CreateUserController : Controller
{
    private readonly UserService _userService;

    // Constructor to initialize the UserService
    public CreateUserController()
    {
        _userService = new UserService();
    }

    // Renders the CreateUser form page
    [HttpGet]
    public IActionResult Index()
    {
        return View("CreateUser");
    }

    // Handles form submission to create a user
    [HttpPost]
    public IActionResult Create(string fullName, string email, string department, string position, string hireDate, string dateOfBirth, string employeeType, string gender, string salary)
    {
        DateTime parsedHireDate = DateTime.Parse(hireDate);
        DateTime parsedDateOfBirth = DateTime.Parse(dateOfBirth);
        decimal parsedSalary = decimal.Parse(salary);

        var user = _userService.AddUser(fullName, email, department, position, parsedHireDate, parsedDateOfBirth, employeeType, gender, parsedSalary);
        
        return RedirectToAction("Success", new
        {
            fullName = user.FullName,
            email = user.Email,
            department = user.Department,
            position = user.Position,
            hireDate = user.HireDate.ToString("dd-MM-yyyy"),
            dateOfBirth = user.DateOfBirth.ToString("dd-MM-yyyy"),
            employeeType = user.EmployeeType,
            gender = user.Gender,
            salary = user.Salary.ToString("C")
        });
    }

    // Displays the Success page with the created user details
    [HttpGet]
    public IActionResult Success(string fullName, string email, string department, string position, string hireDate, string dateOfBirth, string employeeType, string gender, string salary)
    {
        ViewBag.FullName = fullName;
        ViewBag.Email = email;
        ViewBag.Department = department;
        ViewBag.Position = position;
        ViewBag.HireDate = hireDate;
        ViewBag.DateOfBirth = dateOfBirth;
        ViewBag.EmployeeType = employeeType;
        ViewBag.Gender = gender;

        string cleanedSalary = salary.Replace("$", "").Replace(",", "").Trim();
        if (decimal.TryParse(cleanedSalary, out decimal salaryValue))
        {
            ViewBag.Salary = salaryValue.ToString("C");
        }
        else
        {
            ViewBag.Salary = "$0.00";
        }

        return View();
    }

    // API endpoint to get all users
    [HttpGet("all-users")]
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsers();

        return Ok(users);
    }
}