using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class Helper
    {
        public static async Task<double> CalculTaxe(double sum, string type)
        {
            switch (type)
            {
                case "TVA5%":
                    return sum * 0.8 + 12.2;
                    break;
                case "TVA12%":
                    return sum * 0.9 + 22.2;
                    break;
                default:
                    return sum;
                    break;
            }
        }

        public static async Task<int> CalculZileLibere(string employeeType)
        {
            if(employeeType == "manager")
            {
                return 23;
            }
            else
            {
                return 18;
            }
        }
    }
}
