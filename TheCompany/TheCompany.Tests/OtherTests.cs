using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;
using System.IO;
using TheCompany;
using System.Collections.Generic;

namespace TheCompany.Tests
{
    [TestClass]
    public class OtherTests
    {
        private TheCompany.Container employeeRepo;
        AllEmployees.FulltimeEmployee FTEmployee; // A reference to a full-time employee object to be tested with

        [TestInitialize]
        public void TestInitialize()
        {
            employeeRepo = new Container();

            DateTime dateOfBirth = new DateTime(1990, 09, 10);
            DateTime dateOfHire = new DateTime(2010, 10, 11);
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 212398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        }

        // ======================================= AddEmployeeToList Tests =======================================
       [TestMethod]
        // normal
        public void AddEmployeeToList_ValidEmployee_AddsEmployeeToList()
        {
            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.AddEmployeeToList(FTEmployee);
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");

            Assert.AreEqual(1, employeeList.Count);
        }

       [TestMethod]
       // normal
       public void AddEmployeeToList_InvalidEmployee_EmployeeNotAddedToList()
       {
           DateTime dateOfBirth = new DateTime(1987, 11, 29);
           Employee employee = new Employee("Janet", "Moore", 122046045, dateOfBirth, "");

           var privateObject = new PrivateObject(employeeRepo);
           employeeRepo.AddEmployeeToList(employee);
           List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");

           Assert.AreEqual(0, employeeList.Count);
       }


        // ======================================= RemoveEmployee Tests =======================================
        [TestMethod]
        // normal
        public void RemoveEmployee_ValidEmployeeInList_RemovesEmployee()
        {
            employeeRepo.AddEmployeeToList(FTEmployee);

            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.RemoveEmployee(FTEmployee);
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");

            Assert.AreEqual(0, employeeList.Count);
        }

        [TestMethod]
        // normal
        public void RemoveEmployee_InvalidEmployeeNotInList_EmployeeIsNotRemoved()
        {
            employeeRepo.AddEmployeeToList(FTEmployee);

            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2013, 04, 12);
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 432098933, dateOfBirth, dateOfHire, dateOfTermination, 30);

            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.RemoveEmployee(PTEmployee);
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");

            Assert.AreEqual(1, employeeList.Count);
        }

        // ======================================= DisplayAllEmployees Tests =======================================
        // can't really test for output, so have to explain why this can't be tested in an automated way (has to be tested manually)
        //      - has to be tested manually because there is no way to tell in an automated way if an employee
        //        (and their details) is being displayed correctly
    }
}
