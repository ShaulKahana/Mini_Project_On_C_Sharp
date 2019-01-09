using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
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


        private String password;
        public String Password
        {
            get { return password; }
            set
            {
                try { password = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }


        private String familyName;
        public String FamilyName
        {
            get { return familyName; }
            set
            {
                try { familyName = value; }
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

        private DateTime birthDate = DateTime.Today;
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

        private String phoneNumber;
        public String PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                try { phoneNumber = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

   
        private String address;
        public String Address
        {
            get { return address; }
            set
            {
                try { address = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private bool elevator;
        public bool Elevator
        {
            get { return elevator; }
            set
            {
                try { elevator = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private int floor;
        public int Floor
        {
            get { return floor; }
            set
            {
                try { floor = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private int yearsOfExpirience;
        public int YearsOfExpirience
        {
            get { return yearsOfExpirience; }
            set
            {
                try { yearsOfExpirience = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private int maxChildren;
        public int MxChildren
        {
            get { return maxChildren; }
            set
            {
                try { maxChildren = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private int maxAge;
        public int MaxAge
        {
            get { return maxAge; }
            set
            {
                try { maxAge = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private int minAge;
        public int MinAge
        {
            get { return minAge; }
            set
            {
                try { minAge = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private bool byHour;
        public bool ByHour
        {
            get { return byHour; }
            set
            {
                try { byHour = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private Double costForHour;
        public Double CostForHour
        {
            get { return costForHour; }
            set
            {
                try { costForHour = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private int costForMounth;
        public int CostForMounth
        {
            get { return costForMounth; }
            set
            {
                try { costForMounth = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }


        public string[,] workHoursTimestring = 
        {
            { "00:00", "00:00",  },
            { "00:00", "00:00",  },
            { "00:00", "00:00",  },
            { "00:00", "00:00", },
            { "00:00", "00:00",  },
            { "00:00", "00:00", }
        };
 

        public string Sundaystart
        {
            get { return workHoursTimestring[0, 0]; }
            set { workHoursTimestring[0, 0] = value; }

        }
        public string Sundayfinish
        {
            get { return workHoursTimestring[0, 1]; }
            set { workHoursTimestring[0, 1] = value; }

        }
        public string Mondaystart
        {
            get { return workHoursTimestring[1, 0]; }
            set { workHoursTimestring[1, 0] = value; }

        }
        public string Mondayfinish
        {
            get { return workHoursTimestring[1, 1]; }
            set { workHoursTimestring[1, 1] = value; }

        }
        public string Tuesdaystart
        {
            get { return workHoursTimestring[2, 0]; }
            set { workHoursTimestring[2, 0] = value; }

        }
        public string Tuesdayfinish
        {
            get { return workHoursTimestring[2, 1]; }
            set { workHoursTimestring[2, 1] = value; }

        }
        public string Wednesdaystart
        {
            get { return workHoursTimestring[3, 0]; }
            set { workHoursTimestring[3, 0] = value; }

        }
        public string Wednesdayfinish
        {
            get { return workHoursTimestring[3, 1]; }
            set { workHoursTimestring[3, 1] = value; }

        }
        public string Thursdaystart
        {
            get { return workHoursTimestring[4, 0]; }
            set { workHoursTimestring[4, 0] = value; }

        }
        public string Thursdayfinish
        {
            get { return workHoursTimestring[4, 1]; }
            set { workHoursTimestring[4, 1] = value; }

        }
        public string Fridaystart
        {
            get { return workHoursTimestring[5, 0]; }
            set { workHoursTimestring[5, 0] = value; }

        }
        public string Fridayfinish
        {
            get { return workHoursTimestring[5, 1]; }
            set { workHoursTimestring[5, 1] = value; }

        }


        public bool[] dayOfWork = new bool[6];

        public bool Sunday
        {
            get { return dayOfWork[0]; }
            set { dayOfWork[0] = value; }

        }

        public bool Monday
        {
            get { return dayOfWork[1]; }
            set { dayOfWork[1] = value; }

        }

        public bool Tuesday
        {
            get { return dayOfWork[2]; }
            set { dayOfWork[2] = value; }

        }

        public bool Wednesday
        {
            get { return dayOfWork[3]; }
            set { dayOfWork[3] = value; }

        }

        public bool Thursday
        {
            get { return dayOfWork[4]; }
            set { dayOfWork[4] = value; }

        }

        public bool Friday
        {
            get { return dayOfWork[5]; }
            set { dayOfWork[5] = value; }

        }


        private bool vacationOfTamat = false;
        public bool VacationOfTamat
        {
            get { return vacationOfTamat; }
            set
            {
                try { vacationOfTamat = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private bool vacationOfMisradHinuh;
        public bool VacationOfMisradHinuh
        {
            get { return vacationOfMisradHinuh; }
            set
            {
                try { vacationOfMisradHinuh = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private string recommendations;
        public String Recommendations
        {
            get { return recommendations; }
            set
            {
                try { recommendations = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

     


        private int countChildren = 0;
        public int CountChildren
        {
            get { return countChildren; }
            set
            {
                try { countChildren = value; }
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
 
        public void Age()
        {
            DateTime PresentYear = DateTime.Now;
            TimeSpan ts = PresentYear - BirthDate;
            DateTime age = DateTime.MinValue.AddDays(ts.Days);

            ageYear = age.Year - 1;
            
        }

        public override string ToString()
        {
            return "ID: " + Id + "family name: " + familyName + "birh date: " + birthDate
                + "phone number: " + phoneNumber + "address: " + address + "elevator: " +
                elevator + "floor: " + floor + "years Of Expirience:" + yearsOfExpirience
                + "max Children: " + maxChildren + "max age: " + maxAge + "min age: " + minAge
                + "by hour: " + byHour + "cost of hour: " + costForHour + "cost For Mounth: "
                + "vacation Of Tamat: " + vacationOfTamat + "vacaTion Of Misrad Hinuh: " +
                vacationOfMisradHinuh + "recommendations: " + recommendations;
        }

        public int CompareTo(object obj)
        {
            return Id.CompareTo(((Nanny)obj).Id);
        }

    }
}
