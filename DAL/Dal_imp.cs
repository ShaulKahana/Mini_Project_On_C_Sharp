using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Dal_imp : Idal
    {
        DS.DataSource ds = new DS.DataSource();

        public void addNanny(BE.Nanny nanny)
        {
            ds.nannies.Add(nanny);
        }
        public void removeNanny(BE.Nanny nanny)
        {
            ds.nannies.Remove(nanny);
        }
        public BE.Nanny searchNanny(string id)
        {
            return ds.nannies.Find(x => x.Id == id);
        }
        public void updateNanny(BE.Nanny nanny)
        {
            foreach (BE.Nanny item in ds.nannies)
            {
                if (item == nanny)
                {
                    ds.nannies.Remove(item);
                    ds.nannies.Add(nanny);
                }
            }

        }


        public void addMother(BE.Mother mother)
        {
            ds.mothers.Add(mother);
        }
        public void removeMother(BE.Mother mother)
        {
            ds.mothers.Remove(mother);
        }
        public BE.Mother searchMother(string id)
        {
            return ds.mothers.Find(x => x.Id == id);
        }
        public void updateMother(BE.Mother mother)
        {
            foreach (BE.Mother item in ds.mothers)
            {
                if (item == mother)
                {
                    ds.mothers.Remove(item);
                    ds.mothers.Add(mother);
                    break;
                }
            }

        }


        public void addChild(BE.Child child)
        {
            ds.children.Add(child);
        }
        public void removeChild(BE.Child child)
        {
            ds.children.Remove(child);
        }
        public void updateChild(BE.Child child)
        {
            ds.children.Remove(ds.children.Find(x => x.Id == child.Id));
            ds.children.Add(child);

        }
        public BE.Child searchChild(string id)
        {
            return ds.children.Find(x => x.Id == id);
        }
 

        public void addContract(BE.Contract contract)
        {
            ds.contracts.Add(contract);
        }
        public void removeContract(BE.Contract contract)
        {
            ds.contracts.Remove(contract);
        }
        public void updateContract(BE.Contract contract)
        {
            foreach (BE.Contract item in ds.contracts)
            {
                if (item == contract)
                {
                    ds.contracts.Remove(item);
                    ds.contracts.Add(contract);

                }
            }

        }
        public BE.Contract searchContract(long contractNum)
        {
            foreach (var item in ds.contracts)
            {
                if (item.ContractNum == contractNum)
                {
                    return item;
                }
            }
            return null;
        }


        public IEnumerable<BE.Nanny> getAllNanny()
        {
            List<BE.Nanny> temp = new List<BE.Nanny>();
            foreach (var item in ds.nannies)
            {
                temp.Add(item);
            }
            return temp;

        }
        public IEnumerable<BE.Mother> getAllMothers()
        {
            List<BE.Mother> temp = new List<BE.Mother>();
            foreach (var item in ds.mothers)
            {
                temp.Add(item);
            }
            return temp;

        }
        public IEnumerable<BE.Child> getAllChildren()
        {
            List<BE.Child> temp = new List<BE.Child>();
            foreach (var item in ds.children)
            {
                temp.Add(item);
            }
            return temp;

        }
        public IEnumerable<BE.Contract> getAllContracts()
        {
            List<BE.Contract> temp = new List<BE.Contract>();
            foreach (var item in ds.contracts)
            {
                temp.Add(item);
            }
            return temp;

        }
    }
}

