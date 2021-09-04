using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Calculations
    {
        //returns price with ITBIS
        public static decimal addITBIS(decimal price)
        {
            return price * (decimal)1.18;
        }

        public static decimal getITBIS(decimal price)
        {
            return addITBIS(price)-price;
        }

        public static decimal calculateDiscount(decimal price)
        {
            return price / (decimal)1.05;
        }

          
    }
}
