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
using AllEmployees;


namespace Supporting
{
    /// \class FileIO
    ///
    /// \brief <b>Brief Description</b>
    /// This class allows files to be written to, read all the data from a file, open a file for reading, open a file for writing, closing a file and parsing data from a file. 
    /// The fileIO class is realted to employee and container class
    ///
    /// \author <i>Nathan</i>
    public class FileIO
    {
        static bool wasRead = false;
        /**
        * \brief default constructor.
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public FileIO()
        {

        }

        /**
        * \brief Give file name, return list of all valid records
        *
        * \details <b>Details</b>
        *
        * \param fileName - <b>string</b> - The file path and name of file storing the records
        *
        * \return  employeeRec - <b>List<AllEmployees.Employee></b> - The list of all the employee records in the file
        */
        public static List<AllEmployees.Employee> ReadAllRecords(String fileName)
        {
            List<AllEmployees.Employee> employeeRec = new List<AllEmployees.Employee>();
            if (wasRead == false)
            {
                if (File.Exists(fileName))
                {
                    string rawEmployeeRec = File.ReadAllText(fileName);//open file and read all data to a string
                    employeeRec = ParsRecord(rawEmployeeRec);//pars data//validate data
                    Logging.Log("FileIO", "ReadAllRecords", "file read sucessfully: " + fileName);
                    wasRead = true;
                }
                else
                {
                    //string className, string methodName, string eventDetails
                    Logging.Log("FileIO", "ReadAllRecords", "file path does not exist: " + fileName);
                }
            }
            return employeeRec;//return list of valid employees
        }

        /**
        * \brief Give employee write and file to write to
        *
        * \details <b>Details</b>
        *
        * \employeeList - <b>List<AllEmployees.Employee></b> - The employees records
        * \param fileName - <b>String</b> - The file path and name of file storing the records
        *
        * \return  umOfRecordsSaved - <b>Int</b> - The number of employees that were sucessfully saved
        */
        public static int WriteRecord(List<AllEmployees.Employee> employeeList, String fileName)
        {
            int numOfRecordsSaved = 0;
            if (wasRead == true)
            {
                File.WriteAllText(fileName, String.Empty);
            }
            foreach (Employee emp in employeeList)
            {
                string identifier = emp.GetEmployeeType();
                string fileOutput = "";

                if (identifier == "CT")
                {
                    AllEmployees.ContractEmployee employeeData = new AllEmployees.ContractEmployee();
                    employeeData = (AllEmployees.ContractEmployee)emp;
                    if (employeeData.Validate() == true)
                    {
                        fileOutput = employeeData.ToString();//test sample of gow to format
                        StreamWriter sw = File.AppendText(fileName);//write data (Details Method)
                        sw.WriteLine(fileOutput);//will append if file exists or create new if it does not already exist
                        sw.Close();
                        Logging.Log("FileIO", "WriteAllRecords", "ContractEmployee written to file");
                        numOfRecordsSaved++;
                    }
                    else
                    {
                        Logging.Log("FileIO", "WriteAllRecords", "ContractEmployee was invalid and was not written to file");
                    }
                }
                else if (identifier == "FT")
                {
                    AllEmployees.FulltimeEmployee employeeData = new AllEmployees.FulltimeEmployee();
                    employeeData = (AllEmployees.FulltimeEmployee)emp;
                    if (employeeData.Validate() == true)
                    {
                        fileOutput = employeeData.ToString();//test sample of gow to format
                        StreamWriter sw = File.AppendText(fileName);//write data (Details Method)
                        sw.WriteLine(fileOutput);//will append if file exists or create new if it does not already exist
                        sw.Close();
                        Logging.Log("FileIO", "WriteAllRecords", "FulltimeEmployee written to file");
                        numOfRecordsSaved++;
                    }
                    else
                    {
                        Logging.Log("FileIO", "WriteAllRecords", "FullTimeEmployee was invalid and was not written to file");
                    }
                }
                else if (identifier == "PT")
                {
                    AllEmployees.ParttimeEmployee employeeData = new AllEmployees.ParttimeEmployee();
                    employeeData = (AllEmployees.ParttimeEmployee)emp;
                    if (employeeData.Validate() == true)
                    {
                        fileOutput = employeeData.ToString();//test sample of gow to format
                        StreamWriter sw = File.AppendText(fileName);//write data (Details Method)
                        sw.WriteLine(fileOutput);//will append if file exists or create new if it does not already exist
                        sw.Close();
                        Logging.Log("FileIO", "WriteAllRecords", "ParttimeEmployee written to file");
                        numOfRecordsSaved++;
                    }
                    else
                    {
                        Logging.Log("FileIO", "WriteAllRecords", "PartTimeEmployee was invalid and was not written to file");
                    }
                }
                else if (identifier == "SN")
                {
                    AllEmployees.SeasonalEmployee employeeData = new AllEmployees.SeasonalEmployee();
                    employeeData = (AllEmployees.SeasonalEmployee)emp;
                    if (employeeData.Validate() == true)
                    {
                        fileOutput = employeeData.ToString();//test sample of gow to format
                        StreamWriter sw = File.AppendText(fileName);//write data (Details Method)
                        sw.WriteLine(fileOutput);//will append if file exists or create new if it does not already exist
                        sw.Close();
                        Logging.Log("FileIO", "WriteAllRecords", "SeasonalEmployee written to file");
                        numOfRecordsSaved++;
                    }
                    else
                    {
                        Logging.Log("FileIO", "WriteAllRecords", "SeasonalEmployee was invalid and was not written to file");
                    }
                }
                else
                {
                    Logging.Log("FileIO", "WriteAllRecords", "invalid unknown employee type was not written to file: " + identifier);
                }
            }
            return numOfRecordsSaved;
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
        private static List<AllEmployees.Employee> ParsRecord(String fileText)
        {
            List<AllEmployees.Employee> employeeRec = new List<AllEmployees.Employee>();
            //tostringbase string employeeString = firstName + "|" + lastName + "|" + SocialInsuranceNumber + "|" + DateOfBirth.Year + "-" + DateOfBirth.Month + "-" + DateOfBirth.Day + "|";
            char[] delimiterChars = { '|', '\n'};
            string[] words = fileText.Split(delimiterChars);
            int wordCounter = 0;
            while (wordCounter < words.Count() - 1)
            {
                if (words[wordCounter] == "CT")
                {
                    bool isValid = true;
                    if (words.Length > (wordCounter + 7))
                    {
                        //AllEmployees.ContractEmployee contractEmp = new AllEmployees.ContractEmployee(words[wordCounter], words[wordCounter+1], Convert.ToInt32(words[wordCounter+2]), words[wordCounter+3], words[wordCounter+4], words[wordCounter+5], Convert.ToDouble(words[wordCounter+6]));
                        try
                        {
                            AllEmployees.ContractEmployee contractEmp = new AllEmployees.ContractEmployee();
                            contractEmp.SetEmployeeType(words[wordCounter]);
                            wordCounter++;
                            contractEmp.SetLastName(words[wordCounter]);
                            wordCounter++;
                            wordCounter++;
                            contractEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[wordCounter]));//only take an int
                            wordCounter++;
                            contractEmp.SetDateOfBirth(words[wordCounter]);
                            wordCounter++;

                            contractEmp.SetContractStartDate(words[wordCounter]);
                            wordCounter++;
                            isValid = contractEmp.SetContractStopDate(words[wordCounter]);
                            if (words[wordCounter] == "")
                            {
                                isValid = true;
                            }
                            wordCounter++;
                            contractEmp.SetFixedContractAmount(Convert.ToDouble(words[wordCounter]));
                            wordCounter++;

                            if (contractEmp.Validate() == true && isValid == true)
                            {
                                employeeRec.Add(contractEmp);
                                Logging.Log("FileIO", "ParsRecord", "contract employee added");
                                wordCounter++;
                            }
                            else
                            {
                                Logging.Log("FileIO", "ParsRecord", "invalid employee data for a contract employee");
                                while (words[wordCounter] != "FT" && words[wordCounter] != "PT" && words[wordCounter] != "SN" && words[wordCounter] != "CT" && wordCounter < words.Count() - 1)
                                {
                                    wordCounter++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.Log("FileIO", "ParsRecord", "invalid employee data for a contract employee - Error Message: " + ex.Message);
                            while (words[wordCounter] != "FT" && words[wordCounter] != "PT" && words[wordCounter] != "SN" && words[wordCounter] != "CT" && wordCounter < words.Count() - 1)
                            {
                                wordCounter++;
                            }
                        }
                    }
                    else
                    {
                        Logging.Log("FileIO", "ParsRecord", "Not enough employee data for a contract employee");
                        break;
                    }
                }
                else if (words[wordCounter] == "FT")
                {
                    bool isValid = true;
                    if (words.Length > (wordCounter + 7))
                    {
                        AllEmployees.FulltimeEmployee fullTimeEmp = new AllEmployees.FulltimeEmployee();

                        try
                        {
                            fullTimeEmp.SetEmployeeType(words[wordCounter]);
                            wordCounter++;
                            fullTimeEmp.SetLastName(words[wordCounter]);
                            wordCounter++;
                            fullTimeEmp.SetFirstName(words[wordCounter]);
                            wordCounter++;
                            fullTimeEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[wordCounter]));//only takes an int
                            wordCounter++;
                            fullTimeEmp.SetDateOfBirth(words[wordCounter]);
                            wordCounter++;

                            fullTimeEmp.SetDateOfHire(words[wordCounter]);
                            wordCounter++;
                            isValid = fullTimeEmp.SetDateOfTermination(words[wordCounter]);
                            if (words[wordCounter] == "")
                            {
                                isValid = true;
                            }
                            wordCounter++;
                            fullTimeEmp.SetSalary(Convert.ToDouble(words[wordCounter]));//only takes a float
                            wordCounter++;

                            if (fullTimeEmp.Validate() == true && isValid == true)
                            {
                                wordCounter++;
                                employeeRec.Add(fullTimeEmp);
                                Logging.Log("FileIO", "ParsRecord", "full time employee added");
                            }
                            else
                            {
                                Logging.Log("FileIO", "ParsRecord", "invalid employee data for a full time employee");
                                while (words[wordCounter] != "FT" && words[wordCounter] != "PT" && words[wordCounter] != "SN" && words[wordCounter] != "CT" && wordCounter < words.Count() - 1)
                                {
                                    wordCounter++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.Log("FileIO", "ParsRecord", "invalid employee data for a full time employee - Error Message: " + ex.Message);
                            while (words[wordCounter] != "FT" && words[wordCounter] != "PT" && words[wordCounter] != "SN" && words[wordCounter] != "CT" && wordCounter < words.Count() - 1)
                            {
                                wordCounter++;
                            }
                        }
                    }

                    else
                    {
                        Logging.Log("FileIO", "ParsRecord", "Not enough employee data for a full time employee");
                        break;
                    }
                }
                else if (words[wordCounter] == "PT")
                {
                    if (words.Length > (wordCounter + 7))
                    {
                        bool isValid = true;
                        AllEmployees.ParttimeEmployee partTimeEmp = new AllEmployees.ParttimeEmployee();

                        try
                        {
                            partTimeEmp.SetEmployeeType(words[wordCounter]);
                            wordCounter++;
                            partTimeEmp.SetLastName(words[wordCounter]);
                            wordCounter++;
                            partTimeEmp.SetFirstName(words[wordCounter]);
                            wordCounter++;
                            partTimeEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[wordCounter]));//only takes an int
                            wordCounter++;
                            partTimeEmp.SetDateOfBirth(words[wordCounter]);
                            wordCounter++;

                            partTimeEmp.SetDateOfHire(words[wordCounter]);
                            wordCounter++;
                            isValid = partTimeEmp.SetDateOfTermination(words[wordCounter]);
                            if (words[wordCounter] == "")
                            {
                                isValid = true;
                            }
                            wordCounter++;
                            partTimeEmp.SetHourlyRate(Convert.ToDouble(words[wordCounter]));//only takes a float
                            wordCounter++;

                            if (partTimeEmp.Validate() == true && isValid == true)
                            {
                                wordCounter++;
                                employeeRec.Add(partTimeEmp);
                                Logging.Log("FileIO", "ParsRecord", "part time employee added");
                            }
                            else
                            {
                                Logging.Log("FileIO", "ParsRecord", "invalid employee data for a part time employee");
                                while (words[wordCounter] != "FT" && words[wordCounter] != "PT" && words[wordCounter] != "SN" && words[wordCounter] != "CT" && wordCounter < words.Count() - 1)
                                {
                                    wordCounter++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.Log("FileIO", "ParsRecord", "invalid employee data for a part time employee - Error Message: " + ex.Message);
                            while (words[wordCounter] != "FT" && words[wordCounter] != "PT" && words[wordCounter] != "SN" && words[wordCounter] != "CT" && wordCounter < words.Count() - 1)
                            {
                                wordCounter++;
                            }
                        }
                    }
                    else
                    {
                        Logging.Log("FileIO", "ParsRecord", "Not enough employee data for a part time employee");
                        break;
                    }
                }
                else if (words[wordCounter] == "SN")
                {
                    if (words.Length > (wordCounter + 6))
                    {
                        AllEmployees.SeasonalEmployee seasonalEmp = new AllEmployees.SeasonalEmployee();

                        try
                        {


                            seasonalEmp.SetEmployeeType(words[wordCounter]);
                            wordCounter++;
                            seasonalEmp.SetLastName(words[wordCounter]);
                            wordCounter++;
                            seasonalEmp.SetFirstName(words[wordCounter]);
                            wordCounter++;
                            seasonalEmp.SetSocialInsuranceNumber(Convert.ToInt32(words[wordCounter]));//only takes an int
                            wordCounter++;
                            seasonalEmp.SetDateOfBirth(words[wordCounter]);
                            wordCounter++;

                            seasonalEmp.SetSeason(words[wordCounter]);
                            wordCounter++;
                            seasonalEmp.SetPiecePay(Convert.ToDouble(words[wordCounter]));//only takes a float
                            wordCounter++;

                            if (seasonalEmp.Validate() == true)
                            {
                                wordCounter++;
                                employeeRec.Add(seasonalEmp);
                                Logging.Log("FileIO", "ParsRecord", "seasonal employee added");
                            }
                            else
                            {
                                Logging.Log("FileIO", "ParsRecord", "invalid employee data for a seasonal employee");
                                while (words[wordCounter] != "FT" && words[wordCounter] != "PT" && words[wordCounter] != "SN" && words[wordCounter] != "CT" && wordCounter < words.Count() - 1)
                                {
                                    wordCounter++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.Log("FileIO", "ParsRecord", "invalid employee data for a seasonal employee - Error Message: " + ex.Message);
                            while (words[wordCounter] != "FT" && words[wordCounter] != "PT" && words[wordCounter] != "SN" && words[wordCounter] != "CT" && wordCounter < words.Count() - 1)
                            {
                                wordCounter++;
                            }
                        }

                    }
                    else
                    {
                        Logging.Log("FileIO", "ParsRecord", "Not enough employee data for a seasonal employee");
                        break;
                    }
                }
                else
                {
                    //string className, string methodName, string eventDetails
                    Logging.Log("FileIO", "ParsRecord", "invalid employee type in file");
                    while (words[wordCounter] != "FT" && words[wordCounter] != "PT" && words[wordCounter] != "SN" && words[wordCounter] != "CT" && wordCounter < words.Count() - 1)
                    {
                        wordCounter++;
                    }
                }
            }
            return employeeRec;
        }

    }
}

/**
* \brief description of unit test here
* 
* \<b>Name of Method/b>
* Name of method being test here
* 
* \<b>How test is Conducted/b>
* description of how the test is conducted (automatic / manual + special instructions)
* 
* \<b>Type of Test</b>
* type fo test here
* 
* \<b>Sample Data Sets</b>
* Sample data sets (where possible)
* 
* \<b>Expected Result</b>
* expected result here
* 
* \<b>Actual Result</b>
* Actual Test result (to be completed at Project completion)
*/

/*
 * Name of Test

 * Brief description of purpose of test

 * Brief description of how the test is conducted (automatic / manual + special instructions)

 * Type of Test (Normal/Functional, Fault/Exception, Boundary, Stress, etc.)

 * Sample data sets (where possible)

 * Expected outcome

 * Actual Test result (to be completed at Project completion)*/