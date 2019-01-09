using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Threading;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using DAL;

namespace BL
{

  
    public class BL_imp : IBL
    {

        DAL.Dal_XML_imp dal = new Dal_XML_imp();

        //public BL_imp()
        //{
        //    init();
        //}
        public void addNanny(BE.Nanny nanny)
        {
            nanny.Age();
            if (nanny.AgeYear < 18)
                throw (new Exception("nanny need to be at least 18 years old"));

            if (searchNanny(nanny.Id) != null)
                throw (new Exception("the nanny is already exist in the nanny list"));

            dal.addNanny(nanny);
        }
        public void removeNanny(BE.Nanny nanny)
        {
            foreach (var item in getChildOfNanni(nanny))
            {
                removeContract(getContractOfChild(item));
                item.IdOfNanny = "0";
                updateChild(item);
            }
            dal.removeNanny(nanny);
        }
        public BE.Nanny searchNanny(string id)
        {
            return (dal.searchNanny(id));
        }
        public void updateNanny(BE.Nanny nanny)
        {
            dal.updateNanny(nanny);
        }
        public IEnumerable<BE.Child> getChildOfNanni(BE.Nanny Nanny)
        {
            IEnumerable<BE.Child> temp = getAllChild();
           
            var child = from ch in temp
                        where ch.IdOfNanny == Nanny.Id
                        select ch;
            return child;
        }






        public void addMother(BE.Mother mother)
        {
            if (searchMother(mother.Id) != null)
                throw (new Exception("the Mother is already exist in the Mother list"));


            if (mother.AreaOfLookFor == null)
                mother.AreaOfLookFor = mother.Address;


            dal.addMother(mother);
           
        }
        public void removeMother(BE.Mother mother)
        {
            foreach (var item in getChildOfMother(mother))
            {
                removeContract(getContractOfChild(item));
                removeChild(item);
            }
            dal.removeMother(mother);
        }
        public BE.Mother searchMother(string id)
        {
            return (dal.searchMother(id));
        }
        public void updateMother(BE.Mother Mother)
        {
            dal.updateMother(Mother);
        }
        public IEnumerable<BE.Child> getChildOfMother(BE.Mother Mother)
        {
            IEnumerable<BE.Child> temp = getAllChild();

            var child = from ch in temp
                        where ch.IdOfMom == Mother.Id
                        select ch;
            return child;
        }

 


        public void addChild(BE.Child child)
        {
            if (searchMother(child.IdOfMom) == null)
                throw (new Exception("You can not add a child Without a mother"));

            if (searchChild(child.Id) != null)
                throw (new Exception("You can not add a child who is alredy xsist on the child list"));

            child.Age();
            dal.addChild(child);
        }
        public void removeChild(BE.Child child)
        {         
            if (child.ContractNum != 0)
                removeContract(getContractOfChild(child));
          
            dal.removeChild(child);
        }
        public void updateChild(BE.Child child)
        {
            child.Age();
            dal.updateChild(child);
        }
        public BE.Child searchChild(string id)
        {
            return dal.searchChild(id);
        }

        public BE.Contract getContractOfChild(BE.Child Child)
        {
            return(searchContract(Child.ContractNum));
        }

      
        


        public void addContract(BE.Contract contract)
        {
            BE.Nanny nannyTemp = searchNanny(contract.IdOfNanny);
            BE.Mother motherTemp = searchMother(contract.IdOfMother);
            BE.Child childTemp = searchChild(contract.IdOfChild);
            contract.ContractNum = dal.configcontract();

            if (searchNanny(contract.IdOfNanny) != null)//if the nanny not exist
            {
                if (motherTemp != null)//if the mother not exist
                {
                    if (childTemp != null)//if the child not exist
                    {
                        if (nannyTemp.CountChildren == nannyTemp.MxChildren)
                            throw (new Exception("There is no room for additional children by this nanni"));

                        if (contract.ContractByHour != nannyTemp.ByHour && nannyTemp.ByHour == false)
                            throw (new Exception("Nanny dont work by hour"));

                        if (childTemp.AgeYear > nannyTemp.MaxAge || childTemp.AgeYear < nannyTemp.MinAge || childTemp.AgeMonth < 3)
                            throw (new Exception("The child is not in the age that the nanni is willing to take"));

                        if(childTemp.IdOfNanny!="0")
                            throw (new Exception("The child is alredy on the contracts list"));

                   
                        //if the contract sighned by hour, calculate the salary according the mothers hours
                        if (contract.ContractByHour == true)
                        {
                            contract.CostForHour = nannyTemp.CostForHour;
                            contract.workHoursTimestring = motherTemp.workHoursTimestring;
                            contract.dayOfWork = motherTemp.dayOfWork;
                            contract.Salary = salary(contract);
                        }
                        //if the contract sighned by month, calculate the salary according the nannys hours
                        else
                        {
                            contract.workHoursTimestring = nannyTemp.workHoursTimestring;
                            contract.dayOfWork = nannyTemp.dayOfWork;
                            contract.Salary = nannyTemp.CostForMounth;
                        }
                        //If the mother has a contract with this nanny, there is a two percent discount for each child
                        foreach (var item in getChildOfNanni(nannyTemp))
                        {
                            if (item.IdOfMom == motherTemp.Id)
                            {
                                contract.Salary -= (2 / 100) * contract.Salary;
                            }
                        }
                        nannyTemp.CountChildren++;
                        updateNanny(nannyTemp);

                        childTemp.IdOfNanny = contract.IdOfNanny;
                        childTemp.ContractNum = contract.ContractNum;
                        updateChild(childTemp);

                        contract.AddressOfNanny = nannyTemp.Address;
                        contract.AddressOfMother = motherTemp.AreaOfLookFor;
                        contract.IsTheContractBeenSigned = true;
                        dal.addContract(contract);
                    }
                    else throw (new Exception("The child is not yet on the children's list"));
                }
                else throw (new Exception("The mother is not yet on the mother's list"));
            }
            else throw (new Exception("The nanni is not yet on the nanni's list"));


        }
        public void removeContract(BE.Contract contract)
        {
            if (contract != null)
            {
                BE.Nanny nannyTemp = searchNanny(contract.IdOfNanny);
                BE.Child childTemp = searchChild(contract.IdOfChild);

              
                childTemp.IdOfNanny ="0";
                childTemp.ContractNum = 0;
                dal.updateChild(childTemp);
 
                nannyTemp.CountChildren--;
                updateNanny(nannyTemp);

                dal.removeContract(contract);
            }
        }
        public BE.Contract searchContract(long contractNum)
        {
            return dal.searchContract(contractNum);
        }
        public void updateContract(BE.Contract contract)
        {
            dal.updateContract(contract);
        }



        //Calculates the monthly salary that the mothr should give for the nanny
        public Double salary(BE.Contract contract)
        {
            DateTime[,] matrix = convert(contract.workHoursTimestring);
            Double costForHour = contract.CostForHour;
            int weekHours = 0, weekMinutes = 0;
            Double salary, temp;

            for (int i = 0; i < 6; i++)
            {
                weekHours += matrix[i, 1].Hour - matrix[i, 0].Hour;
                weekMinutes += matrix[i, 1].Minute - matrix[i, 0].Minute;
            }
            weekHours += weekMinutes / 60;
            weekMinutes %= 60;

            salary = weekHours * costForHour;
            temp = (weekMinutes / 60) * costForHour;
            salary = (salary + temp) * 4;
            return salary;

        }

        //convert and returns an array of type DateTime instead an array of type strings
        //Because it will be more comfortable to calculate remainder between different times
        public DateTime[,] convert(string[,] matrix)
        {
            DateTime[,] workHoursTime = new DateTime[6, 2];
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 2; j++)
                    workHoursTime[i, j] = Convert.ToDateTime(matrix[i, j]);
            return workHoursTime;
        }


        //Return the number of times in week that there is compatibility between nanny and mom
        public int compareMomNannies(BE.Nanny nanny, BE.Mother mom)
        {
            DateTime[,] nannyMatrix = convert(nanny.workHoursTimestring);
            DateTime[,] momMatrix = convert(nanny.workHoursTimestring);

            int count = 0;

            for (int i = 0; i < 6; i++)
                if (nanny.dayOfWork[i] && mom.dayOfWork[i])
                    if (nannyMatrix[i, 0] <= momMatrix[i, 0]
                        && nannyMatrix[i, 1] >= momMatrix[i, 1])
                        count++;

            return count;
        }

        public List<BE.Nanny> getMatchNanniesList(BE.Mother mom)
        {
            IEnumerable<BE.Nanny> temp = dal.getAllNanny();
            List<BE.Nanny> matchNannies = new List<BE.Nanny>();
            List<BE.Nanny> fiveBest = new List<BE.Nanny>();

            int count = 0;

            for (int j = 0; j < 6; j++)
                if (mom.dayOfWork[j] == true)
                    count++;//the number days that the mom want nanny


            //groups of nannies according to compatibility to the mom days
            IEnumerable<IGrouping<int, BE.Nanny>> result = from nanny in temp
                                                           group nanny by compareMomNannies(nanny, mom);


            var newResult = from IGrouping<int, BE.Nanny> item in result
                            orderby item.Key descending
                            select item;


            int i = -1;
            foreach (IGrouping<int, BE.Nanny> items in newResult)
            {//Run on the groups. if there is group of nannies that the key is same to count, 
             //add all the nannies of its group to matchNannies list(its all the nannies that fits 
             //   perfectly to the mom. else take the 5 best
                if (items.Key == count)
                {
                    foreach (BE.Nanny item in items)
                        matchNannies.Add(item);
                    return matchNannies;
                }
                else
                {
                    foreach (BE.Nanny item in items)
                    {
                        i++;
                        if (i == 5)
                            return fiveBest;
                        fiveBest.Add(item);
                    }
                }

            }
            return fiveBest;
        }




        public static int CalculateDistance(string source, string dest)//thread to google maps
        {
            int distance = 0;
            Thread thread = new Thread(() => CalculateDistance(source, dest, ref distance));
            thread.Start();
            while (thread.IsAlive) { }
            return distance;
        }
        public static void CalculateDistance(string source, string dest, ref int distance)
        {
            try
            {
                         var drivingDirectionRequest = new DirectionsRequest
                        {
                            TravelMode = TravelMode.Walking,
                            Origin = source,
                            Destination = dest,
                        };
                        DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                        Route route = drivingDirections.Routes.First();
                        Leg leg = route.Legs.First();
                        distance = leg.Distance.Value; 
            }
            catch (Exception g)
            {
                
                throw g;
            }
          
        }



       //return list of the nannies that located in the radios that the mom choose by slider
        public IEnumerable<BE.Nanny> closeDistanceNannies(BE.Mother mom, int distanceSlide, List<BE.Nanny> nannies = null)
        {
            List<BE.Nanny> closeDistanceNannies = new List<BE.Nanny>();
            IEnumerable<BE.Nanny> allNannies ;
            string address;

            if (nannies == null)
                allNannies = dal.getAllNanny();
            else
                allNannies = nannies;

            if (mom.AreaOfLookFor == null)
                address = mom.Address;
            else address = mom.AreaOfLookFor;


            foreach (var item in allNannies)
            {
                int distance = 0;
                distance = CalculateDistance(address, item.Address);

                if (distance < distanceSlide)
                    closeDistanceNannies.Add(item);

            }


            return closeDistanceNannies;
        }






        public IEnumerable<BE.Nanny> getAllNannies(Func<BE.Nanny, bool> predicat = null)
        {
            List<BE.Nanny> ContractList = dal.getAllNanny().ToList();
            if (predicat == null)
                return ContractList;

            return ContractList.Where(predicat);
        }
        public IEnumerable<BE.Mother> getAllMothers(Func<BE.Mother, bool> predicat = null)
        {
            List<BE.Mother> ContractList = dal.getAllMothers().ToList();
            if (predicat == null)
                return ContractList;

            return ContractList.Where(predicat);
        }

        public IEnumerable<BE.Child> getAllChild(Func<BE.Child, bool> predicat = null)
        {
            List<BE.Child> ContractList = dal.getAllChildren().ToList();

            if (predicat == null)
                return ContractList;

            return ContractList.Where(predicat);
        }

        public IEnumerable<BE.Contract> getAllContract(Func<BE.Contract, bool> predicat = null)
        {
            List<BE.Contract> ContractList = dal.getAllContracts().ToList();
            if (predicat == null)
                return ContractList;

            return ContractList.Where(predicat);
        }




  

        public IEnumerable<BE.Child> childrenWithoutNannis()
        {
            return getAllChild(item => item.IdOfNanny == "0");
        }
        public IEnumerable<BE.Nanny> nanniesWithTamat()
        {
            return getAllNannies(item => item.VacationOfTamat);
        }
        public IEnumerable<BE.Contract> contractByHour()
        {
            return getAllContract(item => item.ContractByHour);
        }





        //Returns sorted  groups by of nannies that sorted by age of children
        public IEnumerable<IGrouping<int, BE.Nanny>> nanniesGroups(bool sort)
        {
            List<BE.Nanny> temp = dal.getAllNanny().ToList();

            
            IEnumerable<IGrouping<int, BE.Nanny>> result = from nanny in temp
                                                           from child in getChildOfNanni(nanny)
                                                           group nanny by child.AgeYear;

            if (sort)
            {
                result = from IGrouping<int, BE.Nanny> item in result
                         orderby item.Key
                         select item;
            }
         
            return result;
        }

        public IEnumerable<IGrouping<int, BE.Contract>> contractsGroupsByDistance()
        {
            IEnumerable<BE.Contract> temp = dal.getAllContracts();

            IEnumerable<IGrouping<int, BE.Contract>> cont = from contract in temp
                                                            group contract by
                                                            CalculateDistance(contract.AddressOfMother, contract.AddressOfNanny)
                                                            / 1000;//distance in kilometer
            return cont;

        }






    
    















        void init()
        {
            this.addMother
                (new BE.Mother
                {
                    Id = "032555154",
                    Password = "1234",
                    FirstName = "אסתר",
                    FamilyName = "כהן",
                    PhoneNumber = "0548423981",
                    Address = "ארץ חפץ 112, ירושלים, ישראל",

                    Sundaystart = "08:00",
                    Sundayfinish = "13:30",
                    Mondaystart = "08:00",
                    Mondayfinish = "13:30",
                    Tuesdaystart = "08:00",
                    Tuesdayfinish = "13:30",
                    Wednesdaystart = "08:00",
                    Wednesdayfinish = "13:30",
                    Thursdaystart = "08:00",
                    Thursdayfinish = "13:30",
                    Fridaystart = "08:00",
                    Fridayfinish = "11:30",

                    Sunday = true,
                    Monday = true,
                    Tuesday = true,
                    Wednesday = true,
                    Thursday = true,
                    Friday = true,

                    AreaOfLookFor = "ארץ חפץ 111, ירושלים, ישראל",
                    Remarks = "no Remarks"
                });
            this.addMother
                 (new BE.Mother
                 {
                     Id = "021956517",
                     Password = "1234",
                     FirstName = "מלכה",
                     FamilyName = "מגן",
                     PhoneNumber = "0504056216",
                     Address = "מאה שערים 22, ירושלים, ישראל",

                     Sundaystart = "08:00",
                     Sundayfinish = "17:00",
                     Mondaystart = "00:00",
                     Mondayfinish = "00:00",
                     Tuesdaystart = "08:00",
                     Tuesdayfinish = "17:00",
                     Wednesdaystart = "00:00",
                     Wednesdayfinish = "00:00",
                     Thursdaystart = "08:00",
                     Thursdayfinish = "17:00",
                     Fridaystart = "00:00",
                     Fridayfinish = "00:00",

                     Sunday = true,
                     Monday = false,
                     Tuesday = true,
                     Wednesday = false,
                     Thursday = true,
                     Friday = false,

                     AreaOfLookFor = "מאה שערים 15, ירושלים, ישראל",
                     Remarks = "no Remarks"

                 });
            this.addMother
                 (new BE.Mother
                 {
                     Id = "011956512",
                     Password = "1234",
                     FirstName = "שולמית",
                     FamilyName = "ווינברגר",
                     PhoneNumber = "0503056316",
                     Address = "מאיר אבנר 33, ירושלים, ישראל",

                     Sundaystart = "00:00",
                     Sundayfinish = "00:00",
                     Mondaystart = "00:00",
                     Mondayfinish = "00:00",
                     Tuesdaystart = "00:00",
                     Tuesdayfinish = "00:00",
                     Wednesdaystart = "00:00",
                     Wednesdayfinish = "00:00",
                     Thursdaystart = "00:00",
                     Thursdayfinish = "00:00",
                     Fridaystart = "07:00",
                     Fridayfinish = "15:00",

                     Sunday = false,
                     Monday = false,
                     Tuesday = false,
                     Wednesday = false,
                     Thursday = false,
                     Friday = true,


                     Remarks = "no Remarks"
                 });
            this.addMother
             (new BE.Mother
             {
                 Id = "031956512",
                 Password = "1234",
                 FirstName = "ששונה",
                 FamilyName = "גרוס",
                 PhoneNumber = "0503054116",
                 Address = "עזה 12 ,ירושלים, ישראל",

                 Sundaystart = "10:00",
                 Sundayfinish = "15:45",
                 Mondaystart = "00:00",
                 Mondayfinish = "10:00",
                 Tuesdaystart = "15:45",
                 Tuesdayfinish = "00:00",
                 Wednesdaystart = "00:00",
                 Wednesdayfinish = "00:00",
                 Thursdaystart = "10:00",
                 Thursdayfinish = "15:45",
                 Fridaystart = "00:00",
                 Fridayfinish = "00:00",

                 Sunday = true,
                 Monday = true,
                 Tuesday = false,
                 Wednesday = false,
                 Thursday = true,
                 Friday = false,

                 AreaOfLookFor = "עזה 12,ירושלים, ישראל",
                 Remarks = "no Remarks"

             });
                    this.addMother
             (new BE.Mother
             {
                 Id = "041956512",
                 Password = "1234",
                 FirstName = "לאה",
                 FamilyName = "ששון",
                 PhoneNumber = "0503055116",
                 Address = "יפו 52, ירושלים, ישראל",

                 Sundaystart = "00:00",
                 Sundayfinish = "00:00",
                 Mondaystart = "13:00",
                 Mondayfinish = "19:00",
                 Tuesdaystart = "13:00",
                 Tuesdayfinish = "19:00",
                 Wednesdaystart = "00:00",
                 Wednesdayfinish = "00:00",
                 Thursdaystart = "13:00",
                 Thursdayfinish = "19:00",
                 Fridaystart = "13:00",
                 Fridayfinish = "19:00",

                 Sunday = false,
                 Monday = true,
                 Tuesday = true,
                 Wednesday = false,
                 Thursday = true,
                 Friday = true,

                 AreaOfLookFor = "הלר 15, ירושלים, ישראל",
                 Remarks = "no Remarks"

             });






            this.addNanny
               (new BE.Nanny
               {
                   Id = "032545154",
                   Password = "1234",
                   FirstName = "אסתר",
                   FamilyName = "כהנא",
                   PhoneNumber = "0548444981",
                   Address = "ארץ חפץ 115, ירושלים, ישראל",
                   BirthDate = DateTime.Parse("1986/05/13"),
                   Elevator = false,
                   Floor = 3,
                   YearsOfExpirience = 5,
                   MxChildren = 10,
                   MinAge = 1,
                   MaxAge = 3,
                   ByHour = true,
                   CostForMounth = 850,
                   VacationOfTamat = false,
                   VacationOfMisradHinuh = true,
                   CostForHour = 23.5,
                   Sundaystart = "08:00",
                   Sundayfinish = "13:30",
                   Mondaystart = "08:00",
                   Mondayfinish = "13:30",
                   Tuesdaystart = "08:00",
                   Tuesdayfinish = "13:30",
                   Wednesdaystart = "08:00",
                   Wednesdayfinish = "13:30",
                   Thursdaystart = "08:00",
                   Thursdayfinish = "13:30",
                   Fridaystart = "08:00",
                   Fridayfinish = "11:30",

                   Sunday = true,
                   Monday = true,
                   Tuesday = true,
                   Wednesday = true,
                   Thursday = true,
                   Friday = true,
                   Recommendations = "no Recommendations"
               });

            this.addNanny
               (new BE.Nanny
               {
                   Id = "021776511",
                   Password = "1234",
                   FirstName = " רבקה",
                   FamilyName = "שוורץ",
                   PhoneNumber = "0504056216",
                   Address = "מאה שערים 15, ירושלים, ישראל",

                   BirthDate = DateTime.Parse("1986/05/13"),
                   Elevator = true,
                   Floor = 2,
                   YearsOfExpirience = 5,
                   MxChildren = 3,
                   MinAge = 7,
                   ByHour = false,
                   CostForHour = 23.5,
                   CostForMounth = 850,
                   VacationOfTamat = true,
                   VacationOfMisradHinuh = false,

                   Sundaystart = "08:00",
                   Sundayfinish = "13:00",
                   Mondaystart = "00:00",
                   Mondayfinish = "00:00",
                   Tuesdaystart = "08:00",
                   Tuesdayfinish = "13:00",
                   Wednesdaystart = "00:00",
                   Wednesdayfinish = "00:00",
                   Thursdaystart = "08:00",
                   Thursdayfinish = "13:00",
                   Fridaystart = "00:00",
                   Fridayfinish = "00:00",

                   Sunday = true,
                   Monday = false,
                   Tuesday = true,
                   Wednesday = false,
                   Thursday = true,
                   Friday = false,


                   Recommendations = "no Recommendations"

               });
            this.addNanny
               (new BE.Nanny
               {
                   Id = "011776512",
                   Password = "1234",
                   FirstName = "שרה",
                   FamilyName = "חליבה",
                   PhoneNumber = "0503056316",
                   Address = "מאיר אבנר 30, ירושלים, ישראל",
                   BirthDate = DateTime.Parse("1986/05/13"),
                   Elevator = true,
                   Floor = 2,
                   YearsOfExpirience = 5,
                   MxChildren = 3,
                   MinAge = 7,
                   ByHour = false,
                   CostForHour = 23.5,
                   CostForMounth = 850,
                   VacationOfTamat = true,
                   VacationOfMisradHinuh = false,

                   Sundaystart = "00:00",
                   Sundayfinish = "00:00",
                   Mondaystart = "00:00",
                   Mondayfinish = "00:00",
                   Tuesdaystart = "00:00",
                   Tuesdayfinish = "00:00",
                   Wednesdaystart = "00:00",
                   Wednesdayfinish = "00:00",
                   Thursdaystart = "00:00",
                   Thursdayfinish = "00:00",
                   Fridaystart = "07:00",
                   Fridayfinish = "15:00",

                   Sunday = false,
                   Monday = false,
                   Tuesday = false,
                   Wednesday = false,
                   Thursday = false,
                   Friday = true,


                   Recommendations = "no Recommendations"
               });

            this.addNanny
           (new BE.Nanny
           {
               Id = "031957712",
               Password = "1234",
               FirstName = "חיה",
               FamilyName = "שמואל",
               PhoneNumber = "0503054116",
               Address = "עזה 32,ירושלים, ישראל",

               BirthDate = DateTime.Parse("1986/05/13"),
               Elevator = true,
               Floor = 2,
               YearsOfExpirience = 5,
               MxChildren = 3,
               MinAge = 7,
               ByHour = false,
               CostForHour = 23.5,
               CostForMounth = 850,
               VacationOfTamat = true,
               VacationOfMisradHinuh = false,

               Sundaystart = "10:00",
               Sundayfinish = "15:45",
               Mondaystart = "00:00",
               Mondayfinish = "10:00",
               Tuesdaystart = "15:45",
               Tuesdayfinish = "00:00",
               Wednesdaystart = "00:00",
               Wednesdayfinish = "00:00",
               Thursdaystart = "10:00",
               Thursdayfinish = "15:45",
               Fridaystart = "00:00",
               Fridayfinish = "00:00",

               Sunday = true,
               Monday = true,
               Tuesday = false,
               Wednesday = false,
               Thursday = true,
               Friday = false,

               Recommendations = "no Recommendations"

           });
            this.addNanny
            (new BE.Nanny
            {
                Id = "041957712",
                Password = "1234",
                FirstName = "ציפי",
                FamilyName = "לבני",
                PhoneNumber = "0503055116",
                Address = "יפו 110, ירושלים, ישראל",
                BirthDate = DateTime.Parse("1986/05/13"),
                Elevator = true,
                Floor = 2,
                YearsOfExpirience = 5,
                MxChildren = 3,
                MinAge = 7,
                ByHour = false,
                CostForHour = 23.5,
                CostForMounth = 850,
                VacationOfTamat = true,
                VacationOfMisradHinuh = false,

                Sundaystart = "00:00",
                Sundayfinish = "00:00",
                Mondaystart = "13:00",
                Mondayfinish = "19:00",
                Tuesdaystart = "13:00",
                Tuesdayfinish = "19:00",
                Wednesdaystart = "00:00",
                Wednesdayfinish = "00:00",
                Thursdaystart = "13:00",
                Thursdayfinish = "19:00",
                Fridaystart = "13:00",
                Fridayfinish = "19:00",

                Sunday = false,
                Monday = true,
                Tuesday = true,
                Wednesday = false,
                Thursday = true,
                Friday = true,

                Recommendations = "no Recommendations"

            });



        }
    }
}























