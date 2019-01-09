using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        private String id;
        public String Id
        {
            get { return id; }
            set
            {
                try { id = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private String idOfMom;
        public String IdOfMom
        {
            get { return idOfMom; }
            set
            {
                try { idOfMom = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private String idOfNanny = "0";
        public String IdOfNanny
        {
            get { return idOfNanny; }
            set
            {
                try { idOfNanny = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }


        private String firstName;
        public String FirstName
        {
            get { return firstName; }
            set
            {
                try { firstName = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private DateTime birthDate =  DateTime.Today;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                try { birthDate = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private bool specialNeeds = false;
        public bool SpecialNeeds
        {
            get { return specialNeeds; }
            set
            {
                try { specialNeeds = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private long contractNum = 0;
        public long ContractNum
        {
            get { return contractNum; }
            set
            {
                try { contractNum = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private int ageYear;
        public int AgeYear
        {
            get { return ageYear; }
            set
            {
                try { ageYear = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private int ageMonth;
        public int AgeMonth
        {
            get { return ageMonth; }
            set
            {
                try { ageMonth = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }


        private string needs = "NO needs";
        public string Needs
        {
            get { return needs; }
            set
            {
                try { needs = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        public void Age() //calculate age of child according to birth date
        {
            DateTime PresentYear = DateTime.Now;
            TimeSpan ts = PresentYear - BirthDate;
            DateTime age = DateTime.MinValue.AddDays(ts.Days);

            ageYear = age.Year - 1;
            ageMonth = age.Month - 1+ ageYear*12;
            
        }

        public override string ToString()
        {
            return "Id" + id + "Id Of Mom" + IdOfMom + "first Name" + firstName +
                "birth Date" + birthDate + "special Needs" + specialNeeds +
                "the Special Needs" + needs + "the age of the child is: " + ageYear + "Years" + ageMonth + "Month "  + "Days";

        }

        public int CompareTo(object obj)
        {
            return id.CompareTo(((Child)obj).id);
        }
    }
}

