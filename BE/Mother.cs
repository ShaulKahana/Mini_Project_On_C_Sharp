using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
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
      

        private string remarks;
        public String Remarks
        {
            get { return remarks; }
            set
            {
                try {remarks = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }


        //If the mother dont put here nothig, the defult area for searching nanny will be her address
        private string areaOfLookFor = null; 
        public String AreaOfLookFor
        {
            get { return areaOfLookFor; }
            set
            {
                try {  areaOfLookFor = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        public override string ToString()
        {
            return "Id:" + id + "family Name:" + familyName + "first Name:" + firstName + remarks + "area Of Look For" + areaOfLookFor;
        }

        public int CompareTo(object obj)
        {
            return id.CompareTo(((Mother)obj).id);
        }
    }
}
