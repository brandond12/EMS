using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supporting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileIOTests
{
    /// \class FileIOTests
    ///
    /// \brief <b>Brief Description</b> 
    /// This class is used to test the Methods in the FileIO class. The methods tested 
    /// include WriteRecord, ReadAllRecords, ParsRecord. ReadAllRecords inherantly uses ParsRecord so they are tested at the same time 
    [TestClass]
    public class FileIOTests
    {
        /// -----------------------------
        ///      WriteRecord tests
        /// -----------------------------
        /// 

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid contract employee to a empty file.
        * 
        * \<b>Name of Method/b>
        * The method being tested is WriteRecord.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.70|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.WriteRecord will write "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.WriteRecord will wrote "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        */
        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataToEmptyFileCT()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.ContractEmployee CTEmp = new AllEmployees.ContractEmployee("", "Brandon", 933456789, DOB, DOH, DOT, 18.78);
            List<AllEmployees.Employee> empList = new List<AllEmployees.Employee>();
            empList.Add(CTEmp);
            FileIO.WriteRecord(empList, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec == (CTEmp.ToString() + "\r\n" ));
        }

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid full time employee to a empty file.
        * 
        * \<b>Name of Method/b>
        * The method being tested is WriteRecord.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.WriteRecord will write "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.WriteRecord will wrote "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        */
        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataToEmptyFileFT()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.FulltimeEmployee FTEmp = new AllEmployees.FulltimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);

            List<AllEmployees.Employee> empList = new List<AllEmployees.Employee>();
            empList.Add(FTEmp);
            FileIO.WriteRecord(empList, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec == (FTEmp.ToString() + "\r\n"));
        }

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid part time employee to a empty file.
        * 
        * \<b>Name of Method/b>
        * The method being tested is WriteRecord.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.WriteRecord will write "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.WriteRecord will wrote "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        */
        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataToEmptyFilePT()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.ParttimeEmployee PTEmp = new AllEmployees.ParttimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);

            List<AllEmployees.Employee> empList = new List<AllEmployees.Employee>();
            empList.Add(PTEmp);
            FileIO.WriteRecord(empList, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec == (PTEmp.ToString() + "\r\n"));
        }

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid seasonal employee to a empty file.
        * 
        * \<b>Name of Method/b>
        * The method being tested is WriteRecord.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.WriteRecord will write "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.WriteRecord will wrote "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|" to the file.
        */
        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataToEmptyFileSN()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            DateTime DOB = new DateTime(1993, 04, 24);
            AllEmployees.SeasonalEmployee SNEmp = new AllEmployees.SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "Summer", 10);

            List<AllEmployees.Employee> empList = new List<AllEmployees.Employee>();
            empList.Add(SNEmp);
            FileIO.WriteRecord(empList, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec == (SNEmp.ToString() + "\r\n"));
        }

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid contract employee to a existing file.
        * 
        * \<b>Name of Method/b>
        * The method being tested is WriteRecord.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.70|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.WriteRecord will write "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.WriteRecord will wrote "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        */
        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataExistingFileCT()
        {
            string path = @"DBase\DBase.txt";
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.ContractEmployee CTEmp = new AllEmployees.ContractEmployee("", "Brandon", 933456789, DOB, DOH, DOT, 18.78);

            List<AllEmployees.Employee> empList = new List<AllEmployees.Employee>();
            empList.Add(CTEmp);
            FileIO.WriteRecord(empList, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec.Contains(CTEmp.ToString() + "\r\n"));
        }

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid full time employee to a existing file.
        * 
        * \<b>Name of Method/b>
        * The method being tested is WriteRecord.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.WriteRecord will write "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.WriteRecord will wrote "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        */
        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataExistingFileFT()
        {
            string path = @"DBase\DBase.txt";
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.FulltimeEmployee FTEmp = new AllEmployees.FulltimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);

            List<AllEmployees.Employee> empList = new List<AllEmployees.Employee>();
            empList.Add(FTEmp);
            FileIO.WriteRecord(empList, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec.Contains(FTEmp.ToString() + "\r\n"));
        }

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid part time employee to a exisiting file.
        * 
        * \<b>Name of Method/b>
        * The method being tested is WriteRecord.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.WriteRecord will write "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.WriteRecord will wrote "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        */
        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataExistingFilePT()
        {
            string path = @"DBase\DBase.txt";
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.ParttimeEmployee PTEmp = new AllEmployees.ParttimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);

            List<AllEmployees.Employee> empList = new List<AllEmployees.Employee>();
            empList.Add(PTEmp);
            FileIO.WriteRecord(empList, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec.Contains(PTEmp.ToString() + "\r\n"));
        }

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid seasonal employee to a exisiting file.
        * 
        * \<b>Name of Method/b>
        * The method being tested is WriteRecord.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.WriteRecord will write "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.WriteRecord will wrote "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|" to the file.
        */
        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataExistingFileSN()
        {
            string path = @"DBase\DBase.txt";
            DateTime DOB = new DateTime(1993, 04, 24);
            AllEmployees.SeasonalEmployee SNEmp = new AllEmployees.SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "Summer", 10);

            List<AllEmployees.Employee> empList = new List<AllEmployees.Employee>();
            empList.Add(SNEmp);
            FileIO.WriteRecord(empList, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec.Contains(SNEmp.ToString() + "\r\n"));
        }

        /// -----------------------------
        ///      ReadAllRecords tests
        /// -----------------------------
        /// 

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read four valid employees, one for each type of employee and return those employees to a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        * "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        * "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        * "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|", "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|", "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|", "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|".
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|", "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|", "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|", "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|".
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readGoodData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" + "\r\n" + "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" + "\r\n" + "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" + "\r\n" + "SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            List<AllEmployees.Employee> sampleRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.ContractEmployee CTEmp = new AllEmployees.ContractEmployee("", "Brandon", 933456789, DOB, DOH, DOT, 18.78);
            AllEmployees.FulltimeEmployee FTEmp = new AllEmployees.FulltimeEmployee("Davies", "Brandon", 933456789, DOB, DOH, DOT, 18.78);
            AllEmployees.ParttimeEmployee PTEmp = new AllEmployees.ParttimeEmployee("Davies", "Brandon", 933456789, DOB, DOH, DOT, 18.78);
            AllEmployees.SeasonalEmployee SNEmp = new AllEmployees.SeasonalEmployee("Davies", "Brandon", 123456789, DOB, "Summer", 10);

            sampleRecords.Add(CTEmp);
            sampleRecords.Add(FTEmp);
            sampleRecords.Add(PTEmp);
            sampleRecords.Add(SNEmp);

            Assert.IsTrue(((AllEmployees.ContractEmployee)EmpRecords[0]).ToString() == CTEmp.ToString());
            Assert.IsTrue(((AllEmployees.FulltimeEmployee)EmpRecords[1]).ToString() == FTEmp.ToString());
            Assert.IsTrue(((AllEmployees.ParttimeEmployee)EmpRecords[2]).ToString() == PTEmp.ToString());
            Assert.IsTrue(((AllEmployees.SeasonalEmployee)EmpRecords[3]).ToString() == SNEmp.ToString());
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an invalid first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employees with an invalid first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an invalid first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with an invalid first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|123456!@#$%^|Davies|123456789|1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|123456!@#$%^|Davies|123456789|1993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|123456!@#$%^|Davies|123456789|1993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|123456!@#$%^|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an invalid last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 1);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with an invalid last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an invalid last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with an invalid last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|123456!@#$%^|123456789|1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|123456!@#$%^|123456789|1993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|123456!@#$%^|123456789|1993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|123456!@#$%^|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an invalid social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||54347589|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||54347589|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||54347589|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||54347589|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with an invalid social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an invalid social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with an invalid social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|54347589|1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|54347589|1993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|54347589|1993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|54347589|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an invalid date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|3993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|3993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|3993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|3993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with an invalid date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an invalid date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with an invalid date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|3993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|123456789|3993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|123456789|3993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|123456789|3993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an invalid start date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|1000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|1000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|1000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|1000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with an invalid start date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an invalid start date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with an invalid season and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|1993-04-24|datTimeOvYearDoe|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|123456789|1993-04-24|datTimeOvYearDoe|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|123456789|1993-04-24|datTimeOvYearDoe|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNSeasonData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|123456789|1993-04-24|datTimeOvYearDoe|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an invalid stop date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12|1004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|2000-12-12|1004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|2000-12-12|1004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|2000-12-12|1004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with an invalid stop date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an invalid stop date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with an invalid piece pay and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|1993-04-24|Summer|-10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|123456789|1993-04-24|Summer|-10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|123456789|1993-04-24|Summer|-10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNPiecePayData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|123456789|1993-04-24|Summer|-10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an invalid contract amount and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTfixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with an invalid contract amount and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTfixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an invalid contract amount and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTfixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an missing first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with an missing first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an missing first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with an missing first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Davies|123456789|1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Davies|123456789|1993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Davies|123456789|1993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an missing last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with an missing last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an missing last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with an missing last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|123456789|1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|123456789|1993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|123456789|1993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with an missing social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with an missing social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with an missing social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with an missing social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|1993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|1993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a missing date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a missing date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a missing date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with a missing date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|123456789|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|123456789|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|123456789|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a missing start date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a missing start date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTDateOfHireData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a missing start date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTDateOfHireData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with a missing season and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|1993-04-24|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|123456789|1993-04-24|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|123456789|1993-04-24|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNSeasonData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|123456789|1993-04-24|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a missing stop date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|2000-12-12|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|2000-12-12|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|2000-12-12|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a missing stop date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTDateOfTerminationData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a missing stop date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTDateOfTerminationData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with a missing piece pay and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|1993-04-24|Summer|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|123456789|1993-04-24|Summer|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|123456789|1993-04-24|Summer|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNPiecePayData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|123456789|1993-04-24|Summer|";//"SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a missing contract amount and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTFixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a missing salary and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTSalaryData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a missing hourly rate and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTHourlyRateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a blank first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a blank first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a blank first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with a blank first name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN||Davies|123456789|1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN||Davies|123456789|1993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN||Davies|123456789|1993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN||Davies|123456789|1993-04-24|Summer|10|";//"SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a blank last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 1);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a blank last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a blank last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with a blank last name and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon||123456789|1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon||123456789|1993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon||123456789|1993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon||123456789|1993-04-24|Summer|10|";//"SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a blank social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon|||1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon|||1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon|||1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon|||1993-04-24|2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a blank social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a blank social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with a blank social insurance number and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies||1993-04-24|Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies||1993-04-24|Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies||1993-04-24|Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies||1993-04-24|Summer|10|";//"SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a blank date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789||2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789||2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789||2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789||2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a blank date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a blank date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with a blank date of birth and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789||Summer|10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|123456789||Summer|10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|123456789||Summer|10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|123456789||Summer|10|";//"SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a blank start date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24||2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24||2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24||2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24||2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a blank start date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTDateOfHireData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a blank start date and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTDateOfHireData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with a blank season and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|1993-04-24||10|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|123456789|1993-04-24||10|" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|123456789|1993-04-24||10|" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNSeasonData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|123456789|1993-04-24||10|";//"SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a blank stop date and return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Normal/Functional.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12||18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|2000-12-12||18.78|" and add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|2000-12-12||18.78|" and add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|2000-12-12||18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(0001, 01, 01);
            AllEmployees.ContractEmployee CTEmp = new AllEmployees.ContractEmployee("", "Brandon", 933456789, DOB, DOH, DOT, 18.78);

            Assert.IsTrue(((AllEmployees.ContractEmployee)EmpRecords[0]).ToString() == CTEmp.ToString());
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a blank stop date and return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Normal/Functional.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|" and add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|" and add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTDateOfTerminationData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(0001, 01, 01);
            AllEmployees.FulltimeEmployee CTEmp = new AllEmployees.FulltimeEmployee("Davies", "Brandon", 933456789, DOB, DOH, DOT, 18.78);

            Assert.IsTrue(((AllEmployees.FulltimeEmployee)EmpRecords[0]).ToString() == CTEmp.ToString());
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a blank stop date and return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Normal/Functional.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|" and add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|" and add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTDateOfTerminationData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(0001, 01, 01);
            AllEmployees.ParttimeEmployee CTEmp = new AllEmployees.ParttimeEmployee("Davies", "Brandon", 933456789, DOB, DOH, DOT, 18.78);

            Assert.IsTrue(((AllEmployees.ParttimeEmployee)EmpRecords[0]).ToString() == CTEmp.ToString());
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a seasonal employee with a blank peice pay and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "SN|Brandon|Davies|123456789|1993-04-24|Summer||"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "SN|Brandon|Davies|123456789|1993-04-24|Summer||" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "SN|Brandon|Davies|123456789|1993-04-24|Summer||" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNPiecePayData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "SN|Brandon|Davies|123456789|1993-04-24|Summer||";//"SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a contract employee with a blank contract and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02||"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02||" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02||" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTFixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02||";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a full time employee with a blank salary and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTSalaryData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /**
        * \brief The unit test's purpose is to test if the method ReadAllRecords
        * will read a part time employee with a blank hour rate and not return that employee in a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is ReadAllRecords.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is Fault/Exception.
        * 
        * \<b>Sample Data Sets</b>
        * "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the FileIO.ReadAllRecords will read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||" but not add it to the list.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the FileIO.ReadAllRecords read "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||" but not add it to the list.
        */
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTHourlyRateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||";//"CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = FileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        /// -----------------------------
        ///      ParsRecord tests
        /// -----------------------------
        ///Everything that could be tested for ParsRecord is already tested through ReadAllRecords as ReadAllRecords always uses ParsRecord after it reads the string out of the file to seperate/parse the data to put it into a list
        ///

        //[TestMethod]
        //[TestCategory("FileIO ParsRecord")]
        //public void parseGoodData()
        //{
        //    string fileData = "CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";

        //    FileIOParse = new FileIO();
        //    List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
        //    var privateObject = PrivateObject(FileIOParse); 
        //    EmpRecords = FileIOParse.ParsRecord(fileData);

        //    Assert.IsTrue(EmpRecords.Count() == 0);
        //}

        //[TestMethod]
        //[TestCategory("FileIO ParsRecord")]
        //public void parseBadData()
        //{

        //}

        //[TestMethod]
        //[TestCategory("FileIO ParsRecord")]
        //public void parseMissingData()
        //{

        //}

        //[TestMethod]
        //[TestCategory("FileIO ParsRecord")]
        //public void parseBlankData()
        //{

        //}
    }
}
