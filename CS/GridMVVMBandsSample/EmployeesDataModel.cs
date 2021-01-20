using System;
using System.Collections.Generic;

namespace GridMVVMBandsSample {
    public class Employee {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public class EmployeesDataModel {
        public static List<Employee> GetEmployees() {
            List<Employee> list = new List<Employee> {
            new Employee() { FirstName = "Elizabeth", LastName = "Lincoln", Country = "Canada", City = "Tsawassen", JobTitle = "Accounting Manager", BirthDate = new DateTime(1988, 12, 8) },
            new Employee() { FirstName = "Maria", LastName = "Anders", Country = "Germany", City = "Berlin", JobTitle = "Sales Representative", BirthDate = new DateTime(1975, 2, 19) },
            new Employee() { FirstName = "Ana", LastName = "Trujillo", Country = "Mexico", City = "México D.F.", JobTitle = "Owner", BirthDate = new DateTime(1965, 3, 4) },
            new Employee() { FirstName = "Antonio", LastName = "Moreno", Country = "Mexico", City = "México D.F.", JobTitle = "Owner", BirthDate = new DateTime(1983, 9, 19) },
            new Employee() { FirstName = "Thomas", LastName = "Hardy", Country = "UK", City = "London", JobTitle = "Sales Representative", BirthDate = new DateTime(1995, 8, 30) },
            new Employee() { FirstName = "Christina", LastName = "Berglund", Country = "Sweden", City = "Luleå", JobTitle = "Order Administrator", BirthDate = new DateTime(1991, 7, 2) },
            new Employee() { FirstName = "Hanna", LastName = "Moos", Country = "Germany", City = "Mannheim", JobTitle = "Sales Representative", BirthDate = new DateTime(1990, 1, 27) },
            new Employee() { FirstName = "Frédérique", LastName = "Citeaux", Country = "France", City = "Strasbourg", JobTitle = "Marketing Manager", BirthDate = new DateTime(1995, 1, 9) },
            new Employee() { FirstName = "Martín", LastName = "Sommer", Country = "Spain", City = "Madrid", JobTitle = "Owner", BirthDate = new DateTime(1970, 5, 29) },
            };
            return list;
        }
    }
}
