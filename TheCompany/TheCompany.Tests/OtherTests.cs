/*
* FILE   : OtherTests.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Lauren Machan
* FIRST VERSION : 2015-11-29
* DESCRIPTION : 
* This file contains the OtherTests class, which is used to test 
* miscellaneous methods in the Container class.
*/

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
        private Container employeeRepo;         // A reference to a Container object
        private FulltimeEmployee FTEmployee;    // A reference to a FulltimeEmployee object

        [TestInitialize]
        public void TestInitialize()
        {
            // Instantiate the container and a full-time employee
            employeeRepo = new Container();
            DateTime dateOfBirth = new DateTime(1990, 09, 10);
            DateTime dateOfHire = new DateTime(2010, 10, 11);
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            FTEmployee = new FulltimeEmployee("Sam", "Jones", 212398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        }

        // ======================================= AddEmployeeToList Tests =======================================
       [TestMethod]
        // normal
        public void AddEmployeeToList_ValidEmployee_AddsEmployeeToList()
        {
            // Instantiate a private object 
            var privateObject = new PrivateObject(employeeRepo);
            // Execute the method that is being tested
            employeeRepo.AddEmployeeToList(FTEmployee);
            // Check if the expected result and actual result are the same
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
            Assert.AreEqual(1, employeeList.Count);
        }

       [TestMethod]
       // normal
       public void AddEmployeeToList_InvalidEmployee_EmployeeNotAddedToList()
       {
           // Instantiate an Employee object and a private object
           DateTime dateOfBirth = new DateTime(1987, 11, 29);
           Employee employee = new Employee("Janet", "Moore", 122046045, dateOfBirth, "");
           var privateObject = new PrivateObject(employeeRepo);

           // Execute the method that is being tested
           employeeRepo.AddEmployeeToList(employee);
           // Check if the expected result and actual result are the same
           List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
           Assert.AreEqual(0, employeeList.Count);
       }


        // ======================================= RemoveEmployee Tests =======================================
        [TestMethod]
        // normal
        public void RemoveEmployee_ValidEmployeeInList_RemovesEmployee()
        {
            // Instantiate a private object 
            var privateObject = new PrivateObject(employeeRepo);
            // Add an employee to the list before attempting to remove it
            employeeRepo.AddEmployeeToList(FTEmployee);

            // Execute the method that is being tested
            employeeRepo.RemoveEmployee(FTEmployee);
            // Check if the expected result and actual result are the same
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
            Assert.AreEqual(0, employeeList.Count);
        }

        [TestMethod]
        // normal
        public void RemoveEmployee_InvalidEmployeeNotInList_EmployeeIsNotRemoved()
        {
            // Instantiate a ParttimeEmployee object and a private object
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2013, 04, 12);
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 432098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
            var privateObject = new PrivateObject(employeeRepo);

            // Add an employee to the list before attempting to remove one
            employeeRepo.AddEmployeeToList(FTEmployee);
            // Execute the method that is being tested
            employeeRepo.RemoveEmployee(PTEmployee);
            // Check if the expected result and actual result are the same
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
            Assert.AreEqual(1, employeeList.Count);
        }

        // ======================================= DisplayAllEmployees Tests =======================================
        // can't really test for output, so have to explain why this can't be tested in an automated way (has to be tested manually)
        //      - has to be tested manually because there is no way to tell in an automated way if an employee
        //        (and their details) is being displayed correctly
    }
}
