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
        //Give file name, return list of all valid records
        public List<AllEmployees.Employee> ReadAllRecords(String fileName)
        {
            //open file
            //read all data to a string
            //pars data
            //validate data
            //return list of valid employees
            return new List<AllEmployees.Employee>();//temp for removing errors
        }

        //Give employee write and file to write to
        public void WriteRecord(AllEmployees.Employee Employee, String fileName)
        {
            //open file 
            //write data (Details Method)
            //close file
        }

        private FileStream OpenFileForRead(String fileName)
        {
            IntPtr temp = new IntPtr(0);// temp to remove errors
            return new FileStream(temp, FileAccess.Read); // temp to remove errors
        }

        private FileStream OpenFileForWrite(String fileName)
        {
            IntPtr temp = new IntPtr(0);// temp to remove errors
            return new FileStream(temp, FileAccess.Write); // temp to remove errors
        }

        private void CloseFile(FileStream file)
        {

        }

        //given string from file, pars all data into list, return list valid employees
        private List<AllEmployees.Employee> ParsRecord(String fileText)
        {
            //loop through string of data
            //parsing data
            //save all records to list
            return new List<AllEmployees.Employee>();//temp for removing errors
        }
    }
}
