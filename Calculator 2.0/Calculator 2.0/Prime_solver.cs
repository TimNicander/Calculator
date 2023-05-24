using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_2._0
{
    internal class Prime_solver
    {
        public static (string, string) Calculate(string input)
        {
            string result_string = "false";
            string dividers = "";
            int input_int;

            if (int.TryParse(input, out input_int))
            {
                List<int> divisibleBy = new List<int>(); //Lista för att spara alla nämnare som ger jämna resultat

                for (int i = 2; i <= input_int / 2; i++)
                {
                    if (input_int % i == 0) //Dividerar och jämför resten från divisionen. Om resten = 0 innebär det att talet är jämt delbart 
                    {
                        divisibleBy.Add(i);
                    }
                }

                if (divisibleBy.Count < 1) //Om listan av nämnare är tom är talet ett primtal
                {
                    result_string = "true";
                }
                else //Lägger ihop alla nämnare till en string
                {
                    dividers = string.Join(", ", divisibleBy); 
                }
            }
            else //Om konvertering till int misslyckas är något fel med inouten
            {
                result_string = dividers = "ERROR";
            }

            return (result_string, dividers);
        }
    }
}
