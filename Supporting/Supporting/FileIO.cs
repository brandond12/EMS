/*
* FILE   : FileIO.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Nathan Nickel
* FIRST VERSION : 2015-11-20
* DESCRIPTION : This is the file containing the FIleIO class. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Globalization;

namespace Supporting
{
    /// \class FileIO
    ///
    /// \brief <b>Brief Description</b>
    /// This class allows files to be written to, read all the data from a file, open a file for reading, open a file for writing, closing a file and parsing data from a file. 
    /// The fileIO class is realted to employee and container class
    ///
    /// \author <i>Nathan</i>
    class FileIO
    {
        /**
        * \brief Give file name, return list of all valid records
        *
        * \details <b>Details</b>
        *
        * \param fileName - <b>string</b> - The file path and name of file storing the records
        *
        * \return  employeeRec - <b>List<AllEmployees.Employee></b> - The list of all the employee records in the file
        */
        public List<AllEmployees.Employee> ReadAllRecords(String fileName)
        {
            List<AllEmployees.Employee> employeeRec = new List<AllEmployees.Employee>();
            if (File.Exists(fileName))
            {
                string rawEmployeeRec = File.ReadAllText(fileName);//open file and read all data to a string
                employeeRec = ParsRecord(rawEmployeeRec);//pars data
                //validate data
                //return list of valid employees


            }
            else
            {
                //string className, string methodName, string eventDetails
                Logging.Log("FileIO", "ReadAllRecords", "file path does not exist: " + fileName);
            }
            return employeeRec;
        }

        /**
        * \brief Give employee write and file to write to
        *
        * \details <b>Details</b>
        *
        * \param Employee - <b>AllEmployees.Employee</b> - The employees records
        * \param fileName - <b>String</b> - The file path and name of file storing the records
        *
        * \return  n/a
        */
        public void WriteRecord(AllEmployees.Employee Employee, String fileName)
        {
            AllEmployees.ContractEmployee employee = new AllEmployees.ContractEmployee();
            employee.ToString();//test sample of gow to format
            //write data (Details Method)
            //close file
        }



        /**
        * \brief given string from file, pars all data into list, return list valid employees
        *
        * \details <b>Details</b>
        *
        * \param fileText - <b>string</b> - The string of data containing an employees records
        *
        * \return  employeeRec - <b>List<AllEmployees.Employee></b> - The list of all the employee records in the strinng of data
        */
        private List<AllEmployees.Employee> ParsRecord(String fileText)
        {
            //tostringbase string employeeString = firstName + "|" + lastName + "|" + socialInsuranceNumber + "|" + dateOfBirth.Year + "-" + dateOfBirth.Month + "-" + dateOfBirth.Day + "|";
            char[] delimiterChars = { '|' };
            string[] words = fileText.Split(delimiterChars);
            int counter = 0;
            while (counter < words.Count())
            {
                if (words[0] == "CT")
                {
                    AllEmployees.ContractEmployee contractEmp = new AllEmployees.ContractEmployee();

                    contractEmp.SetEmployeeType(words[0]);
                    contractEmp.SetFirstName(words[1]);
                    contractEmp.SetLastName(words[2]);
                    contractEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[3]));//only take an int
                    contractEmp.SetDateOfBirth(words[4]);

                    contractEmp.SetContractStopDate(words[5]);
                    contractEmp.SetContractStartDate(words[6]);
                    contractEmp.SetFixedContractAmount(float.Parse(words[7], CultureInfo.InvariantCulture.NumberFormat));//only takes a float
                }
                else if (words[0] == "FT")
                {
                    AllEmployees.FulltimeEmployee fullTimeEmp = new AllEmployees.FulltimeEmployee();

                    fullTimeEmp.SetEmployeeType(words[0]);
                    fullTimeEmp.SetFirstName(words[1]);
                    fullTimeEmp.SetLastName(words[2]);
                    fullTimeEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[3]));//only takes an int
                    fullTimeEmp.SetDateOfBirth(words[4]);

                    fullTimeEmp.SetDateOfHire(words[5]);
                    fullTimeEmp.SetDateOfTermination(words[6]);
                    fullTimeEmp.SetSalary(float.Parse(words[7], CultureInfo.InvariantCulture.NumberFormat));//only takes a float
                }
                else if (words[0] == "PT")
                {
                    AllEmployees.ParttimeEmployee partTimeEmp = new AllEmployees.ParttimeEmployee();

                    partTimeEmp.SetEmployeeType(words[0]);
                    partTimeEmp.SetFirstName(words[1]);
                    partTimeEmp.SetLastName(words[2]);
                    partTimeEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[3]));//only takes an int
                    partTimeEmp.SetDateOfBirth(words[4]);

                    partTimeEmp.SetDateOfHire(words[5]);
                    partTimeEmp.SetDateOfTermination(words[6]);
                    partTimeEmp.SetHourlyRate(float.Parse(words[7], CultureInfo.InvariantCulture.NumberFormat));//only takes a float
                }
                else if (words[0] == "SN")
                {
                    AllEmployees.SeasonalEmployee seasonalEmp = new AllEmployees.SeasonalEmployee();

                    seasonalEmp.SetEmployeeType(words[0]);
                    seasonalEmp.SetFirstName(words[1]);
                    seasonalEmp.SetLastName(words[2]);
                    seasonalEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[3]));//only takes an int
                    seasonalEmp.SetDateOfBirth(words[4]);

                    seasonalEmp.SetSeason(words[5]);
                    seasonalEmp.SetPiecePay(float.Parse(words[6], CultureInfo.InvariantCulture.NumberFormat));//only takes a float
                }
                else
                {
                    //string className, string methodName, string eventDetails
                    Logging.Log("FileIO", "ParsRecord", "invalid employee type in file");
                }
            }
            //List<AllEmployees.ContractEmployee> contractEmp = new List<AllEmployees.ContractEmployee>();
            //List<AllEmployees.FulltimeEmployee> fullTimeEmp = new List<AllEmployees.FulltimeEmployee>();
            //List<AllEmployees.ParttimeEmployee> partTimeEmp = new List<AllEmployees.ParttimeEmployee>();
            //List<AllEmployees.SeasonalEmployee> seasonalEmp = new List<AllEmployees.SeasonalEmployee>();



            //loop through string of data
            //parsing data
            //save all records to list
            List<AllEmployees.Employee> employeeRec = new List<AllEmployees.Employee>();
            return employeeRec;
        }

        //public override string ToString()//contract employee
        //{
        //    string outputString = "CT" + "|" +
        //        ToStringBase() +
        //        GetContractStopDateString() + "|" +
        //        GetContractStartDateString() + "|" +
        //        fixedContractAmount.ToString();
        //    return outputString;
        //}

        //public override string ToString()//full time employee
        //{
        //    string outputString = "FT" + "|" +
        //        ToStringBase() +
        //        GetDateOfHireString() + "|" +
        //        GetDateOfTerminationString() + "|" +
        //        salary.ToString();
        //    return outputString;
        //}

        //public override string ToString()//part time employee
        //{
        //    string outputString = "PT" + "|" +
        //       ToStringBase() +
        //       GetDateOfHireString() + "|" +
        //       GetDateOfTerminationString() + "|" +
        //       hourlyRate.ToString();
        //    return outputString;
        //}

        //public override string ToString()//seasonal
        //{
        //    string outputString = "SN" + "|" +
        //    ToStringBase() +
        //    season + "|" +
        //    piecePay.ToString();
        //    return outputString;
        //}





















        ///**
        //* \brief Give file name, return file for reading
        //*
        //* \details <b>Details</b>
        //*
        //* \param fileName - <b>string</b> - The file path and name of file storing the records
        //*
        //* \return readFile - <b>FileStream</b> - The opened file to be read
        //*/
        //private FileStream OpenFileForRead(String fileName)
        //{
        //    FileStream readFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //    return readFile;
        //}

        ///**
        //* \brief Give file name, return file for writing
        //*
        //* \details <b>Details</b>
        //*
        //* \param fileName - <b>string</b> - The file path and name of file storing the records
        //*
        //* \return writeFile - <b>FileStream</b> - The opened file to be written to
        //*/
        //private FileStream OpenFileForWrite(String fileName)
        //{
        //    FileStream writeFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //    return writeFile;
        //}

        ///**
        //* \brief Closes the file
        //*
        //* \details <b>Details</b>
        //*
        //* \param file - <b>FileStream</b> - The file to be closed
        //*
        //* \return  n/a
        //*/
        //private void CloseFile(FileStream file)
        //{

        //}
    }
}
