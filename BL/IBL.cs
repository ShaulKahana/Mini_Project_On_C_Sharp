using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BL
{
    public interface IBL
    {
        void addNanny(BE.Nanny nanny);
        void removeNanny(BE.Nanny nanny);
        void updateNanny(BE.Nanny nanny);
        BE.Nanny searchNanny(string id);
        IEnumerable<BE.Child> getChildOfNanni(BE.Nanny Nanny);
         IEnumerable<BE.Nanny> getAllNannies(Func<BE.Nanny, bool> predicat = null);

  
        void addMother(BE.Mother Mother);
        void removeMother(BE.Mother Mother);
        void updateMother(BE.Mother Mother);
        BE.Mother searchMother(string id);
        IEnumerable<BE.Child> getChildOfMother(BE.Mother Mother);
        IEnumerable<BE.Mother> getAllMothers(Func<BE.Mother, bool> predicat = null);

    
        void addChild(BE.Child child);
        void removeChild(BE.Child child);
        void updateChild(BE.Child child);
        BE.Child searchChild(string id);
        BE.Contract getContractOfChild(BE.Child Child);
        IEnumerable<BE.Child> getAllChild(Func<BE.Child, bool> predicat = null);

   
        void addContract(BE.Contract contract);
        void removeContract(BE.Contract contract);
        void updateContract(BE.Contract contract);
        BE.Contract searchContract(long contractNum);      
        IEnumerable<BE.Contract> getAllContract(Func<BE.Contract, bool> predicat = null);

        IEnumerable<BE.Nanny> closeDistanceNannies(BE.Mother mom, int distanceSlide,List<BE.Nanny> nannies = null);
        int compareMomNannies(BE.Nanny nanny, BE.Mother mom);
        List<BE.Nanny> getMatchNanniesList(BE.Mother mom);

        Double salary(BE.Contract contract);
        DateTime[,] convert(string[,] matrix);

        IEnumerable<BE.Nanny> nanniesWithTamat();
        IEnumerable<BE.Child> childrenWithoutNannis();

        IEnumerable<IGrouping<int, BE.Contract>> contractsGroupsByDistance();
        IEnumerable<IGrouping<int, BE.Nanny>> nanniesGroups(bool sort);
    }
}
