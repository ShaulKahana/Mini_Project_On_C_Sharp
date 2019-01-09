using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
namespace DAL
{
    public class Dal_XML_imp : Idal
    {

        XElement nanniesRoot;
        string nanniesPath = @"nanniesXml.xml";

        XElement mothersRoot;
        string mothersPath = @"mothersXml.xml";

        XElement contractsRoot;
        string contractsPath = @"contractsXml.xml";

        XElement childrenRoot;
        string childrenPath = @"childrenXml.xml";

        XElement configrRoot;
        string configrPath = @"configrXml.xml";

        public Dal_XML_imp()
        {
            if (!File.Exists(nanniesPath))
                CreateFiles();
            else
                LoadData();


            if (!File.Exists(mothersPath))
                CreateFiles();
            else
                LoadData();


            if (!File.Exists(contractsPath))
                CreateFiles();
            else
                LoadData();

            if (!File.Exists(childrenPath))
                CreateFiles();
            else
                LoadData();
          

            if (!File.Exists(configrPath))
                CreateFiles();
            else
                LoadData();
        }

        private void CreateFiles()
        {
            nanniesRoot = new XElement("nannies");
            nanniesRoot.Save(nanniesPath);

            mothersRoot = new XElement("mothers");
            mothersRoot.Save(mothersPath);

            contractsRoot = new XElement("contracts");
            contractsRoot.Save(contractsPath);

            childrenRoot = new XElement("children");
            childrenRoot.Save(childrenPath);

            configrRoot = new XElement("contNum");
            configrRoot.SetValue("111111111");
            configrRoot.Save(configrPath);
        }

        private void LoadData()
        {
            try
            {
                nanniesRoot = XElement.Load(nanniesPath);
                mothersRoot = XElement.Load(mothersPath);
                contractsRoot = XElement.Load(contractsPath);
                childrenRoot = XElement.Load(childrenPath);
                configrRoot = XElement.Load(configrPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }


        }


        public long configcontract()//file that contain the last contract number 
        {
            string r;
            r = configrRoot.Value;
            long a = long.Parse(r);
            a++;
            configrRoot.SetValue(a.ToString());
            configrRoot.Save(configrPath);
            return a;
        }

        //**************************************************************************************************











        //*********************************************************************************************



        XElement ConvertNanny(BE.Nanny nanny)
        {
            XElement nannyElement = new XElement("nanny");

            foreach (PropertyInfo item in typeof(BE.Nanny).GetProperties())
                nannyElement.Add
                    (
                    new XElement(item.Name, item.GetValue(nanny, null).ToString())
                    );

            return nannyElement;
        }

        BE.Nanny ConvertNanny(XElement element)
        {
            BE.Nanny nanny = new BE.Nanny();

            foreach (PropertyInfo item in typeof(BE.Nanny).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                if (item.CanWrite)
                    item.SetValue(nanny, convertValue);
            }

            return nanny;
        }



        public void addNanny(BE.Nanny nanny)
        {
            BE.Nanny nny = searchNanny(nanny.Id);
            if (nny != null)
                throw new Exception("Nanny with the same id already exists...");



            nanniesRoot.Add(ConvertNanny(nanny));

            nanniesRoot.Save(nanniesPath);

        }


        public BE.Nanny searchNanny(string id)
        {
            XElement nny = null;

            try
            {
                nny = (from item in nanniesRoot.Elements()
                       where item.Element("Id").Value == id
                       select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            if (nny == null)
                return null;

            return ConvertNanny(nny);
        }

        public void removeNanny(BE.Nanny nanny)
        {
            XElement toRemove = (from item in nanniesRoot.Elements()
                                 where item.Element("Id").Value == nanny.Id
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Nanny with the same id not found...");

            toRemove.Remove();

            nanniesRoot.Save(nanniesPath);

        }



        public void updateNanny(BE.Nanny nanny)
        {


            XElement toUpdate = (from item in nanniesRoot.Elements()
                                 where item.Element("Id").Value == nanny.Id
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Nanny with the same id not found...");

            foreach (PropertyInfo item in typeof(BE.Nanny).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(nanny).ToString());

            nanniesRoot.Save(nanniesPath);
        }





   



    //*************************************************************************************************************


            XElement ConvertContract(BE.Contract contract)
            {
                XElement contractElement = new XElement("contract");

                foreach (PropertyInfo item in typeof(BE.Contract).GetProperties())
                contractElement.Add
                        (
                        new XElement(item.Name, item.GetValue(contract, null).ToString())
                        );

                return contractElement;
            }

            BE.Contract ConvertContract(XElement element)
            {


                 BE.Contract contract = new BE.Contract();

                foreach (PropertyInfo item in typeof(BE.Contract).GetProperties())
                {
                    TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                    object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                    if (item.CanWrite)
                        item.SetValue(contract, convertValue);
                }

                return contract;
            }

            public void addContract(BE.Contract contract)
            {
                BE.Contract ctrct = searchContract(contract.ContractNum);
                if (ctrct != null)
                    throw new Exception("contract with the same contract number already exists...");
            
                contractsRoot.Add(ConvertContract(contract));

                contractsRoot.Save(contractsPath);

            }


            public BE.Contract searchContract(long num)
            {
                XElement contract = null;

                try
                {
                contract = (from item in contractsRoot.Elements()
                           where  item.Element("ContractNum").Value == num.ToString()
                           select item).FirstOrDefault();
                }
                catch (Exception)
                {
                    return null;
                }

                if (contract == null)
                    return null;

                return ConvertContract(contract);
            }

            public void removeContract(BE.Contract contract)
            {
                XElement toRemove = (from item in contractsRoot.Elements()
                                     where item.Element("ContractNum").Value == contract.ContractNum.ToString()
                                     select item).FirstOrDefault();

                if (toRemove == null)
                    throw new Exception("contract with the same contract number not found...");

                toRemove.Remove();

            contractsRoot.Save(contractsPath);

            }



            public void updateContract(BE.Contract contract)
            {


                XElement toUpdate = (from item in contractsRoot.Elements()
                                     where item.Element("ContractNum").Value == contract.ContractNum.ToString()
                                     select item).FirstOrDefault();

                if (toUpdate == null)
                    throw new Exception("contract with the same contract number not found...");

                foreach (PropertyInfo item in typeof(BE.Contract).GetProperties())
                    toUpdate.Element(item.Name).SetValue(item.GetValue(contract).ToString());

            contractsRoot.Save(contractsPath);
            }

        

    //*****************************************************************************************************************

    XElement ConvertMother(BE.Mother mother)
    {
        XElement motherElement = new XElement("mother");

        foreach (PropertyInfo item in typeof(BE.Mother).GetProperties())
            motherElement.Add
                (
                new XElement(item.Name, item.GetValue(mother, null).ToString())
                );

        return motherElement;
    }

    BE.Mother ConvertMother(XElement element)
    {


        BE.Mother mother = new BE.Mother();

        foreach (PropertyInfo item in typeof(BE.Mother).GetProperties())
        {
            TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
            object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

            if (item.CanWrite)
                item.SetValue(mother, convertValue);
        }

        return mother;
    }

    public void addMother(BE.Mother mother)
    {
        BE.Mother mom = searchMother(mother.Id);
        if (mom != null)
            throw new Exception("mother with the same id already exists...");



        mothersRoot.Add(ConvertMother(mother));

        mothersRoot.Save(mothersPath);

    }


    public BE.Mother searchMother(string id)
    {
        XElement mother = null;

        try
        {
            mother = (from item in mothersRoot.Elements()
                      where item.Element("Id").Value == id
                      select item).FirstOrDefault();
        }
        catch (Exception)
        {
            return null;
        }

        if (mother == null)
            return null;

        return ConvertMother(mother);
    }

    public void removeMother(BE.Mother mother)
    {
        XElement toRemove = (from item in mothersRoot.Elements()
                             where item.Element("Id").Value == mother.Id
                             select item).FirstOrDefault();

        if (toRemove == null)
            throw new Exception("Mother with the same id not found...");

        toRemove.Remove();

        mothersRoot.Save(mothersPath);

    }



    public void updateMother(BE.Mother mother)
    {


        XElement toUpdate = (from item in mothersRoot.Elements()
                             where item.Element("Id").Value == mother.Id
                             select item).FirstOrDefault();

        if (toUpdate == null)
            throw new Exception("Mother with the same id not found...");

        foreach (PropertyInfo item in typeof(BE.Mother).GetProperties())
            toUpdate.Element(item.Name).SetValue(item.GetValue(mother).ToString());

        mothersRoot.Save(mothersPath);
    }


        //*************************************************************************************************************


        XElement ConvertChild(BE.Child child)
        {
            XElement childElement = new XElement("child");

            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
                childElement.Add
                    (
                    new XElement(item.Name, item.GetValue(child, null).ToString())
                    );

            return childElement;
        }

        BE.Child ConvertChild(XElement element)
        {


            BE.Child child = new BE.Child();

            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                if (item.CanWrite)
                    item.SetValue(child, convertValue);
            }

            return child;
        }

        public void addChild(BE.Child child)
        {
            BE.Child cild = searchChild(child.Id);
            if (cild != null)
                throw new Exception("Child with the same id already exists...");



            childrenRoot.Add(ConvertChild(child));

            childrenRoot.Save(childrenPath);

        }


        public BE.Child searchChild(string id)
        {
            XElement child = null;

            try
            {
                child = (from item in childrenRoot.Elements()
                          where item.Element("Id").Value == id
                          select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            if (child == null)
                return null;

            return ConvertChild(child);
        }

        public void removeChild(BE.Child child)
        {
            XElement toRemove = (from item in childrenRoot.Elements()
                                 where item.Element("Id").Value == child.Id
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Child with the same id not found...");

            toRemove.Remove();

            childrenRoot.Save(childrenPath);

        }



        public void updateChild(BE.Child child)
        {


            XElement toUpdate = (from item in childrenRoot.Elements()
                                 where item.Element("Id").Value == child.Id
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Child with the same id not found...");

            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(child).ToString());

            childrenRoot.Save(childrenPath);
        }


        //*************************************************************************************************************

        public IEnumerable<BE.Child> getAllChildren()
        {
                return from item in childrenRoot.Elements()
                       select ConvertChild(item);
        }

        public IEnumerable<BE.Contract> getAllContracts()
        {

            return from item in contractsRoot.Elements()
                   select ConvertContract(item);

        }
        public IEnumerable<BE.Nanny> getAllNanny()
        {

            return from item in nanniesRoot.Elements()
                   select ConvertNanny(item);

        }
        public IEnumerable<BE.Mother> getAllMothers()
        {

            return from item in mothersRoot.Elements()
                   select ConvertMother(item);

        }


    }

}
