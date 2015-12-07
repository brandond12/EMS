using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supporting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileIOTests
{
    [TestClass]
    public class FileIOTests
    {
        /// -----------------------------
        ///      WriteRecord tests
        /// -----------------------------
        /// 

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid contract employee to the file.
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
        * "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the myFileIO.WriteRecord will write "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the myFileIO.WriteRecord will wrote "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
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
            AllEmployees.ContractEmployee CTEmp = new AllEmployees.ContractEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);
            FileIO myFileIO = new FileIO();
            myFileIO.WriteRecord(CTEmp, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec == (CTEmp.ToString() + "\r\n" ));
        }

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid full time employee to the file.
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
        * "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the myFileIO.WriteRecord will write "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the myFileIO.WriteRecord will wrote "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
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
            FileIO myFileIO = new FileIO();
            myFileIO.WriteRecord(FTEmp, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec == (FTEmp.ToString() + "\r\n"));
        }

        /**
        * \brief The unit test's purpose is to test if the method WriteRecord
        * will write a valid part time employee to the file.
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
        * "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the myFileIO.WriteRecord will write "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the myFileIO.WriteRecord will wrote "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.70|" to the file.
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
            FileIO myFileIO = new FileIO();
            myFileIO.WriteRecord(PTEmp, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec == (PTEmp.ToString() + "\r\n"));
        }

        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataToEmptyFileSN()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            DateTime DOB = new DateTime(1993, 04, 24);
            AllEmployees.SeasonalEmployee SNEmp = new AllEmployees.SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "Summer", 10);
            FileIO myFileIO = new FileIO();
            myFileIO.WriteRecord(SNEmp, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec == (SNEmp.ToString() + "\r\n"));
        }

        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataExistingFileCT()
        {
            string path = @"DBase\DBase.txt";
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.ContractEmployee CTEmp = new AllEmployees.ContractEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);
            FileIO myFileIO = new FileIO();
            myFileIO.WriteRecord(CTEmp, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec.Contains(CTEmp.ToString() + "\r\n"));
        }

        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataExistingFileFT()
        {
            string path = @"DBase\DBase.txt";
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.FulltimeEmployee FTEmp = new AllEmployees.FulltimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);
            FileIO myFileIO = new FileIO();
            myFileIO.WriteRecord(FTEmp, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec.Contains(FTEmp.ToString() + "\r\n"));
        }

        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataExistingFilePT()
        {
            string path = @"DBase\DBase.txt";
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.ParttimeEmployee PTEmp = new AllEmployees.ParttimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);
            FileIO myFileIO = new FileIO();
            myFileIO.WriteRecord(PTEmp, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec.Contains(PTEmp.ToString() + "\r\n"));
        }

        [TestMethod]
        [TestCategory("FileIO WriteRecord")]
        public void writeGoodDataExistingFileSN()
        {
            string path = @"DBase\DBase.txt";
            DateTime DOB = new DateTime(1993, 04, 24);
            AllEmployees.SeasonalEmployee SNEmp = new AllEmployees.SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "Summer", 10);
            FileIO myFileIO = new FileIO();
            myFileIO.WriteRecord(SNEmp, path);//if true the data was correct and written to the file

            string rawEmployeeRec = File.ReadAllText(path);
            Assert.IsTrue(rawEmployeeRec.Contains(SNEmp.ToString() + "\r\n"));
        }

        /// -----------------------------
        ///      ReadAllRecords tests
        /// -----------------------------
        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readGoodData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" + "\r\n" + "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" + "\r\n" + "|PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|" + "\r\n" + "|SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            List<AllEmployees.Employee> sampleRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            AllEmployees.ContractEmployee CTEmp = new AllEmployees.ContractEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);
            AllEmployees.FulltimeEmployee FTEmp = new AllEmployees.FulltimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);
            AllEmployees.ParttimeEmployee PTEmp = new AllEmployees.ParttimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);
            AllEmployees.SeasonalEmployee SNEmp = new AllEmployees.SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "Summer", 10);

            sampleRecords.Add(CTEmp);
            sampleRecords.Add(FTEmp);
            sampleRecords.Add(PTEmp);
            sampleRecords.Add(SNEmp);

            Assert.IsTrue(((AllEmployees.ContractEmployee)EmpRecords[0]).ToString() == CTEmp.ToString());
            Assert.IsTrue(((AllEmployees.FulltimeEmployee)EmpRecords[1]).ToString() == FTEmp.ToString());
            Assert.IsTrue(((AllEmployees.ParttimeEmployee)EmpRecords[2]).ToString() == PTEmp.ToString());
            Assert.IsTrue(((AllEmployees.SeasonalEmployee)EmpRecords[3]).ToString() == SNEmp.ToString());
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|123456!@#$%^|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|123456!@#$%^|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|123456!@#$%^|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|123456!@#$%^|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|54347589|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|Davies|54347589|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|3993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|123456!@#$%^|123456789|3993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|1993-04-24|1000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNSeasonData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|123456!@#$%^|123456789|1993-04-24|datTimeOvYearDoe|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|1004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadSNPiecePayData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|123456!@#$%^|123456789|1993-04-24|Summer|-10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadCTfixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadFTfixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBadPTfixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|-18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|Davies|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|Davies|123456789|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTDateOfHireData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTDateOfHireData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|1993-04-24|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNSeasonData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|Davies|123456789|1993-04-24|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTDateOfTerminationData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTDateOfTerminationData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingSNPiecePayData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|Davies|123456789|1993-04-24|Summer|";//"|SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingCTFixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingFTSalaryData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readMissingPTHourlyRateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT||Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNFirstNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN||Davies|123456789|1993-04-24|Summer|10|";//"|SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon||933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNLastNameData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon||123456789|1993-04-24|Summer|10|";//"|SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies||1993-04-24|2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNSocialInsuranceNumberData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|Davies||1993-04-24|Summer|10|";//"|SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789||2000-12-12|2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNDateOfBirthData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|Davies|123456789||Summer|10|";//"|SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTContractStartDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTDateOfHireData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTDateOfHireData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|1993-04-24||2004-03-02|18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNSeasonData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|Davies|123456789|1993-04-24||10|";//"|SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTContractStopDateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(0001, 01, 01);
            AllEmployees.ContractEmployee CTEmp = new AllEmployees.ContractEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);

            Assert.IsTrue(((AllEmployees.ContractEmployee)EmpRecords[0]).ToString() == CTEmp.ToString());
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTDateOfTerminationData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(0001, 01, 01);
            AllEmployees.FulltimeEmployee CTEmp = new AllEmployees.FulltimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);

            Assert.IsTrue(((AllEmployees.FulltimeEmployee)EmpRecords[0]).ToString() == CTEmp.ToString());
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTDateOfTerminationData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|1993-04-24|2000-12-12||18.78|";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(0001, 01, 01);
            AllEmployees.ParttimeEmployee CTEmp = new AllEmployees.ParttimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);

            Assert.IsTrue(((AllEmployees.ParttimeEmployee)EmpRecords[0]).ToString() == CTEmp.ToString());
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankSNPiecePayData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|SN|Brandon|Davies|123456789|1993-04-24|Summer||";//"|SN|Brandon|Davies|123456789|1993-04-24|Summer|10|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankCTFixedContractAmountData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankFTSalaryData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|FT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

            Assert.IsTrue(EmpRecords.Count() == 0);
        }

        [TestMethod]
        [TestCategory("FileIO ReadAllRecords")]
        public void readBlankPTHourlyRateData()
        {
            string path = @"DBase\DBase.txt";
            File.Delete(path);//makes sure file does not exist beforehand
            string fileData = "|PT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02||";//"|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";
            StreamWriter sw = File.AppendText(path);//write data (Details Method)
            sw.WriteLine(fileData);//will append if file exists or create new if it does not already exist
            sw.Close();

            FileIO myFileIO = new FileIO();
            List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
            EmpRecords = myFileIO.ReadAllRecords(path);

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
        //    string fileData = "|CT|Brandon|Davies|933456789|1993-04-24|2000-12-12|2004-03-02|18.78|";

        //    myFileIOParse = new FileIO();
        //    List<AllEmployees.Employee> EmpRecords = new List<AllEmployees.Employee>();
        //    var privateObject = PrivateObject(myFileIOParse); 
        //    EmpRecords = myFileIOParse.ParsRecord(fileData);

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
