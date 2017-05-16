using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator7
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            numbers = checkForEmpty(numbers);
            List<int> convertedNumbers = convertNumbers(numbers);

            return convertedNumbers.Sum();
        }

        private static List<int> convertNumbers(string numbers)
        {
            List<int> convertedNumbers = new List<int>();
            int isNumeric = 0;

            List<string> delimiters = new List<string>();

            string[] tempDelimList = numbers.Split('\n');

            foreach(string s in tempDelimList)
            {

            }

            string[] splitNumbers = numbers.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

            foreach (string s in splitNumbers)
            {
                if (int.TryParse(s, out isNumeric))
                {
                    convertedNumbers.Add(Convert.ToInt32(s));
                }
            }

            return convertedNumbers;
        }

        private static string checkForEmpty(string numbers)
        {
            if (numbers == "")
                numbers = "0";
            return numbers;
        }
    }
}
