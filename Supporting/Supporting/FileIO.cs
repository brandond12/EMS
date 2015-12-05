﻿/*
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
                employeeRec = ParsRecord(rawEmployeeRec);//pars data//validate data
            }
            else
            {
                //string className, string methodName, string eventDetails
                Logging.Log("FileIO", "ReadAllRecords", "file path does not exist: " + fileName);
            }
            return employeeRec;//return list of valid employees
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
            string fileOutput = "";
            AllEmployees.ContractEmployee employeeData = new AllEmployees.ContractEmployee();
            fileOutput = employeeData.ToString();//test sample of gow to format
            StreamWriter sw = File.AppendText(fileName);//write data (Details Method)
            sw.WriteLine(fileOutput);//will append if file exists or create new if it does not already exist
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
            List<AllEmployees.Employee> employeeRec = new List<AllEmployees.Employee>();
            //tostringbase string employeeString = firstName + "|" + lastName + "|" + socialInsuranceNumber + "|" + dateOfBirth.Year + "-" + dateOfBirth.Month + "-" + dateOfBirth.Day + "|";
            char[] delimiterChars = { '|' };
            string[] words = fileText.Split(delimiterChars);
            int wordCounter = 0;
            while (wordCounter < words.Count())
            {
                if (words[wordCounter] == "CT")
                {
                    AllEmployees.ContractEmployee contractEmp = new AllEmployees.ContractEmployee();

                    contractEmp.SetEmployeeType(words[wordCounter]);
                    wordCounter++;
                    contractEmp.SetFirstName(words[wordCounter]);
                    wordCounter++;
                    contractEmp.SetLastName(words[wordCounter]);
                    wordCounter++;
                    contractEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[wordCounter]));//only take an int
                    wordCounter++;
                    contractEmp.SetDateOfBirth(words[wordCounter]);
                    wordCounter++;

                    contractEmp.SetContractStopDate(words[wordCounter]);
                    wordCounter++;
                    contractEmp.SetContractStartDate(words[wordCounter]);
                    wordCounter++;
                    contractEmp.SetFixedContractAmount(float.Parse(words[wordCounter], CultureInfo.InvariantCulture.NumberFormat));//only takes a float
                    wordCounter++;

                    if (contractEmp.Validate() == true)
                    {
                        employeeRec.Add(contractEmp);
                        Logging.Log("FileIO", "ParsRecord", "contract employee added");
                    }
                    else
                    {
                        Logging.Log("FileIO", "ParsRecord", "invalid employee data for a contract employee");
                    }
                }
                else if (words[wordCounter] == "FT")
                {
                    AllEmployees.FulltimeEmployee fullTimeEmp = new AllEmployees.FulltimeEmployee();

                    fullTimeEmp.SetEmployeeType(words[wordCounter]);
                    wordCounter++;
                    fullTimeEmp.SetFirstName(words[wordCounter]);
                    wordCounter++;
                    fullTimeEmp.SetLastName(words[wordCounter]);
                    wordCounter++;
                    fullTimeEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[wordCounter]));//only takes an int
                    wordCounter++;
                    fullTimeEmp.SetDateOfBirth(words[wordCounter]);
                    wordCounter++;

                    fullTimeEmp.SetDateOfHire(words[wordCounter]);
                    wordCounter++;
                    fullTimeEmp.SetDateOfTermination(words[wordCounter]);
                    wordCounter++;
                    fullTimeEmp.SetSalary(float.Parse(words[wordCounter], CultureInfo.InvariantCulture.NumberFormat));//only takes a float
                    wordCounter++;

                    if (fullTimeEmp.Validate() == true)
                    {
                        employeeRec.Add(fullTimeEmp);
                        Logging.Log("FileIO", "ParsRecord", "full time employee added");
                    }
                    else
                    {
                        Logging.Log("FileIO", "ParsRecord", "invalid employee data for a full time employee");
                    }
                }
                else if (words[wordCounter] == "PT")
                {
                    AllEmployees.ParttimeEmployee partTimeEmp = new AllEmployees.ParttimeEmployee();

                    partTimeEmp.SetEmployeeType(words[wordCounter]);
                    wordCounter++;
                    partTimeEmp.SetFirstName(words[wordCounter]);
                    wordCounter++;
                    partTimeEmp.SetLastName(words[wordCounter]);
                    wordCounter++;
                    partTimeEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[wordCounter]));//only takes an int
                    wordCounter++;
                    partTimeEmp.SetDateOfBirth(words[wordCounter]);
                    wordCounter++;

                    partTimeEmp.SetDateOfHire(words[wordCounter]);
                    wordCounter++;
                    partTimeEmp.SetDateOfTermination(words[wordCounter]);
                    wordCounter++;
                    partTimeEmp.SetHourlyRate(float.Parse(words[wordCounter], CultureInfo.InvariantCulture.NumberFormat));//only takes a float
                    wordCounter++;

                    if (partTimeEmp.Validate() == true)
                    {
                        employeeRec.Add(partTimeEmp);
                        Logging.Log("FileIO", "ParsRecord", "part time employee added");
                    }
                    else
                    {
                        Logging.Log("FileIO", "ParsRecord", "invalid employee data for a part time employee");
                    }
                }
                else if (words[wordCounter] == "SN")
                {
                    AllEmployees.SeasonalEmployee seasonalEmp = new AllEmployees.SeasonalEmployee();

                    seasonalEmp.SetEmployeeType(words[wordCounter]);
                    wordCounter++;
                    seasonalEmp.SetFirstName(words[wordCounter]);
                    wordCounter++;
                    seasonalEmp.SetLastName(words[wordCounter]);
                    wordCounter++;
                    seasonalEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[wordCounter]));//only takes an int
                    wordCounter++;
                    seasonalEmp.SetDateOfBirth(words[wordCounter]);
                    wordCounter++;

                    seasonalEmp.SetSeason(words[wordCounter]);
                    wordCounter++;
                    seasonalEmp.SetPiecePay(float.Parse(words[wordCounter], CultureInfo.InvariantCulture.NumberFormat));//only takes a float
                    wordCounter++;

                    if (seasonalEmp.Validate() == true)
                    {
                        employeeRec.Add(seasonalEmp);
                        Logging.Log("FileIO", "ParsRecord", "seasonal employee added");
                    }
                    else
                    {
                        Logging.Log("FileIO", "ParsRecord", "invalid employee data for a seasonal employee");
                    }
                }
                else
                {
                    //string className, string methodName, string eventDetails
                    Logging.Log("FileIO", "ParsRecord", "invalid employee type in file");
                }
            }           
            return employeeRec;
        }

       





















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
