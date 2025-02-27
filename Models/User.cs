using LiteDB;
using System;

public class User
{
    [BsonId]
    public int Id { get; set; }

    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Department { get; set; }
    public required string Position { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string EmployeeType { get; set; }
    public required string Gender { get; set; }
    public decimal Salary { get; set; }
}