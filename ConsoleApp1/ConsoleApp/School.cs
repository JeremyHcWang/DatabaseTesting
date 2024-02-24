namespace ConsoleApp1;
using System;
using System.Collections.Generic;

// Interface for basic person operations
public interface IPersonService
{
    int CalculateAge(DateTime dateOfBirth);
    decimal CalculateSalary(decimal baseSalary);
}

// Interface for student-specific operations
public interface IStudentService : IPersonService
{
    double CalculateGPA(Dictionary<string, char> courseGrades);
}

// Interface for instructor-specific operations
public interface IInstructorService : IPersonService
{
    int CalculateExperience(DateTime joinDate);
}

// Interface for department-specific operations
public interface IDepartmentService
{
    void SetHeadInstructor(Instructor headInstructor);
    decimal Budget { get; set; }
    List<Course> Courses { get; }
}

// Person class representing a basic person
public class Person : IPersonService
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Address> Addresses { get; set; }

    // Calculate age of the person
    public int CalculateAge(DateTime dateOfBirth)
    {
        int age = DateTime.Now.Year - dateOfBirth.Year;
        if (DateTime.Now < dateOfBirth.AddYears(age))
        {
            age--;
        }
        return age;
    }

    // Calculate salary of the person
    public decimal CalculateSalary(decimal baseSalary)
    {
        if (baseSalary < 0)
        {
            throw new ArgumentException("Base salary cannot be negative.");
        }
        return baseSalary;
    }

    // Method to get addresses
    public List<Address> GetAddresses()
    {
        return Addresses;
    }
}

// Student class representing a student
public class Student : Person, IStudentService
{
    public List<Course> Courses { get; set; }

    // Calculate student GPA
    public double CalculateGPA(Dictionary<string, char> courseGrades)
    {
        double totalPoints = 0;
        foreach (var grade in courseGrades.Values)
        {
            totalPoints += GradeToPoint(grade);
        }
        return totalPoints / courseGrades.Count;
    }

    // Helper method to convert grade to points
    private double GradeToPoint(char grade)
    {
        switch (grade)
        {
            case 'A':
                return 4.0;
            case 'B':
                return 3.0;
            case 'C':
                return 2.0;
            case 'D':
                return 1.0;
            default:
                return 0.0;
        }
    }
}

// Instructor class representing an instructor
public class Instructor : Person, IInstructorService
{
    public Department Department { get; set; }
    public DateTime JoinDate { get; set; }

    // Calculate experience of the instructor
    public int CalculateExperience(DateTime joinDate)
    {
        return DateTime.Now.Year - joinDate.Year;
    }
}

// Course class representing a course
public class Course
{
    public string Name { get; set; }
    public List<Student> EnrolledStudents { get; set; }
}

// Department class representing a department
public class Department : IDepartmentService
{
    public Instructor HeadInstructor { get; set; }
    public decimal Budget { get; set; }
    public List<Course> Courses { get; set; }

    // Set head instructor of the department
    public void SetHeadInstructor(Instructor headInstructor)
    {
        HeadInstructor = headInstructor;
    }
}

// Address class representing an address
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}
