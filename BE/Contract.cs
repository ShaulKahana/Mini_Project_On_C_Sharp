using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {


        // Initialization that will be displayed in the textBoxs before the user put her hours
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


        private long contractNum = 11111111;
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
       

        private String idOfChild;
        public String IdOfChild
        {
            get { return idOfChild; }
            set
            {
                try { idOfChild = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private String idOfNanny;
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

        private String idOfMother;
        public String IdOfMother
        {
            get { return idOfMother; }
            set
            {
                try { idOfMother = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private String addressOfNanny;
        public String AddressOfNanny
        {
            get { return addressOfNanny; }
            set
            {
                try { addressOfNanny = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private String addressOfMother;
        public String AddressOfMother
        {
            get { return addressOfMother; }
            set
            {
                try { addressOfMother = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private bool meetExisted;
        public bool MeetExisted
        {
            get { return meetExisted; }
            set
            {
                try { meetExisted = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private bool isTheContractBeenSigned = false;
        public bool IsTheContractBeenSigned
        {
            get;
            set;     
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

        private Double salary;
        public Double Salary
        {
            get;
            set;

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

        private bool contractByHour = false;
        public bool ContractByHour
        {
            get { return contractByHour; }
            set
            {
                try { contractByHour = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private DateTime startWorkDate = DateTime.Today;// The date that the contract start to be valid
        public DateTime StartWorkDate
        {
            get { return startWorkDate; }
            set
            {
                try { startWorkDate = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        private DateTime endWorkDate = DateTime.Today;// "         "          " end   "    "
        public DateTime EndWorkDate
        {
            get { return endWorkDate; }
            set
            {
                try { endWorkDate = value; }
                catch (Exception)
                {
                    throw (new Exception("incorrect input"));
                }
            }
        }

        public override string ToString()
        {
            return "contract Number" + contractNum + "id Of Nanny" + idOfNanny +
                "id Of mother" + idOfMother + "id Of Child" + idOfChild + "if a meet is Existed" + meetExisted +
                  "cost For Hour" + costForHour + "ccost For Mounth" + costForMounth +
                  "by hour Or by Mounth" + contractByHour + "start Work Date" + startWorkDate +
                  "end Work Date" + endWorkDate;
        }
    }
}

