using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    
    public class FactoryBL
    {
        static BL_imp bl = null;
        public static BL_imp getBL()
        {
            if(bl == null)
                bl = new BL_imp();
            return bl;

        }
    }
}
