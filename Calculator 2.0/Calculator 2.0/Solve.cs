using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator_2._0
{
    internal class Solve
    {
        public static string Power(string string_to_calculate) //Kod för att beräkna exponenter 
        {
            string_to_calculate = string_to_calculate.Replace(".", ","); //Konvertera till , för Math.Pow beräkning
            int index = string_to_calculate.IndexOf("(^");
                int numberStartIndex = index - 1; //Första index på nummret
                int powerStartIndex = index + 2; //Första index på exponent

                int powerEndIndex = powerStartIndex; //Sista index på exponent är från början samma som första index på exponent
                while (powerEndIndex < string_to_calculate.Length && char.IsDigit(string_to_calculate[powerEndIndex])) 
                {
                    powerEndIndex++;
                }
                powerEndIndex--; //Kompenserar eftersom att den kör loopen en gång för mycket

                string power = string_to_calculate.Substring(powerStartIndex, powerEndIndex - powerStartIndex + 1); //Sparar hela exponenten, alla siffror mellan första och sista index

                if (int.TryParse(power, out int power_int))
                {
                    while (numberStartIndex >= 0 && (char.IsDigit(string_to_calculate[numberStartIndex]) || string_to_calculate[numberStartIndex] == ','))
                    {
                        numberStartIndex--;
                    }
                    numberStartIndex++; //Kompenserar eftersom att den kör loopen en gång för mycket

                    string number = string_to_calculate.Substring(numberStartIndex, index - numberStartIndex); //Sparar hela nummret, alla siffror från första till sista index 

                    if (double.TryParse(number, out double number_double))
                    {
                        double result = Math.Pow(number_double, power_int); //Beräknar resultatet
                        string calculated_input = result.ToString();
                        string output = string_to_calculate.Replace(number + "(^" + power + ")", calculated_input); //Byter ut exponenten och talet till det uträknade resultatet och behåller alla annan input
                        output = output.Replace(",", "."); //Byter tillbaka till . eftersom att användaren skriver med . och programmet utgår från det
                    return output;
                    }
                }
            return string_to_calculate; //Om numret eller exponeten inte är koreckt angivet skickas inputen tillbakas vilket kommer läsas av som error
        }
    
        public static string Root(string string_to_calculate) //Kod för att beräkna roten ur 
        {
            string_to_calculate = string_to_calculate.Replace(".", ",");  //Byter ut . mot , för att tillåta Math.Sqrt beräkning
            int index = string_to_calculate.IndexOf("√");
            int rootNumberStartIndex = index + 1;
            int rootNumberEndIndex = rootNumberStartIndex; //Sista index på talet är från början samma som första index
            while (rootNumberEndIndex < string_to_calculate.Length && (char.IsDigit(string_to_calculate[rootNumberEndIndex]) || string_to_calculate[rootNumberEndIndex] == ','))
            {
                rootNumberEndIndex++;
            }
            rootNumberEndIndex--; //Kompenserar eftersom att den kör loopen en gång för mycket

            string rootNumber = string_to_calculate.Substring(rootNumberStartIndex, rootNumberEndIndex - rootNumberStartIndex+1); //Sparar hela numret, från första til sista index
            
            double rootNumberDouble;
            if (double.TryParse(rootNumber, out rootNumberDouble))
            {}
            string result = Math.Sqrt(rootNumberDouble).ToString();
            string output = string_to_calculate.Replace("√" + rootNumber, result); //Byter ut roten ur tecken + givet nummer och behåller all annan information i inputen
            output = output.Replace(",", "."); //Byter tillbaka till . eftersom att användaren skriver med . och programmet utgår från det
            return output;
        }
    }
}
