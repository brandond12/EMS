using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Supporting
{
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
            //open file
            //read all data to a string
            //pars data
            //validate data
            //return list of valid employees
            List<AllEmployees.Employee> employeeRec = new List<AllEmployees.Employee>();
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
            //open file 
            //write data (Details Method)
            //close file
        }

        /**
        * \brief Give file name, return list of all valid records
        *
        * \details <b>Details</b>
        *
        * \param fileName - <b>string</b> - The file path and name of file storing the records
        *
        * \return readFile - <b>FileStream</b> - The opened file to be read
        */
        private FileStream OpenFileForRead(String fileName)
        {
            FileStream readFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            return readFile;
        }

        /**
        * \brief Give file name, return list of all valid records
        *
        * \details <b>Details</b>
        *
        * \param fileName - <b>string</b> - The file path and name of file storing the records
        *
        * \return writeFile - <b>FileStream</b> - The opened file to be written to
        */
        private FileStream OpenFileForWrite(String fileName)
        {
            FileStream writeFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            return writeFile;
        }

        /**
        * \brief Closes the file
        *
        * \details <b>Details</b>
        *
        * \param file - <b>FileStream</b> - The file to be closed
        *
        * \return  n/a
        */
        private void CloseFile(FileStream file)
        {

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
            //loop through string of data
            //parsing data
            //save all records to list
            List<AllEmployees.Employee> employeeRec = new List<AllEmployees.Employee>();
            return employeeRec;
        }
    }
}
