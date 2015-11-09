using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    class SeasonalEmployee : Employee
    {
        private string season;
        private float piecePay;

        public SeasonalEmployee()
        {

        }

        public SeasonalEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }

        public SeasonalEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, string season, float piecePay)
            : base(firstName, lastName, socialInsuranceNumber, dateOfBirth)
        {

        }

        public new bool Validate()
        {
            return true;//temp to remove errors
        }

        //prints all employee info to the screen
        public void Details()
        {
            
        }

        ////*Setters*//////
        public bool SetSeason(string season)
        {
            return true;
        }

        public bool SetPiecePay(float piecePay)
        {
            return true;
        }

        ////*Getters*//////
        public string GetSeason()
        {
            return season;
        }

        public float GetPiecePay()
        {
            return piecePay;
        }

        //override the ToString to allow easy printing
        public override string ToString()
        {
            return base.ToString();//temp to remove errors
        }
    }
}
