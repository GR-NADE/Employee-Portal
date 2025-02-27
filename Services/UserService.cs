using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

public class UserService
{
    // Defines the path for the LiteDB database file
    private readonly string _dbPath = "CreateUser.db";

    // Adds a new user to the database
    public User AddUser(string fullName, string email, string department, string position, DateTime hireDate, DateTime dateOfBirth, string employeeType, string gender, decimal salary)
    {
        using (var db = new LiteDatabase(_dbPath))
        {
            var users = db.GetCollection<User>("users");
            var user = new User
            {
                FullName = fullName,
                Email = email,
                Department = department,
                Position = position,
                HireDate = hireDate,
                DateOfBirth = dateOfBirth,
                EmployeeType = employeeType,
                Gender = gender,
                Salary = salary
            };
            users.Insert(user);
            
            return user;
        }
    }

    // Retrieves all users from the database
    public List<User> GetAllUsers()
    {
        using (var db = new LiteDatabase(_dbPath))
        {
            var users = db.GetCollection<User>("users");
            return users.FindAll().ToList();
        } 
    }
}