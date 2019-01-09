using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public interface Idal 
    {
        void addNanny(BE.Nanny nanny);
        void removeNanny(BE.Nanny nanny);
        void updateNanny(BE.Nanny nanny);
        BE.Nanny searchNanny(string id);
    
        
         
        void addMother(BE.Mother Mother);
        void removeMother(BE.Mother Mother);
        void updateMother(BE.Mother Mother);
        BE.Mother searchMother(string id);


        void addChild(BE.Child child);
        void removeChild(BE.Child child);
        void updateChild(BE.Child child);
        BE.Child searchChild(string id);


        void addContract(BE.Contract contract);
        void removeContract(BE.Contract contract);
        void updateContract(BE.Contract contract);
        BE.Contract searchContract(long contractNum);


        IEnumerable<BE.Child> getAllChildren();
        IEnumerable<BE.Contract> getAllContracts();
        IEnumerable<BE.Nanny> getAllNanny();
        IEnumerable<BE.Mother> getAllMothers();
    }
}
