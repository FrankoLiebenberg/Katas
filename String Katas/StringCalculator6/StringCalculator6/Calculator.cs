using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator6
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            numbers = checkEmpty(numbers);

            checkNegative(numbers);

            List<int> lstConvertedNumbers = convertNumbers(numbers);

            return lstConvertedNumbers.Sum();
        }

        private static List<int> convertNumbers(string numbers)
        {
            List<string> lstDelimiters = getDelimiters(numbers);

            string[] arrSplitNumbers = numbers.Split(lstDelimiters.ToArray(), StringSplitOptions.None);
            List<int> lstConvertedNumbers = new List<int>();
            int isNumeric = 0;

            foreach (string s in arrSplitNumbers)
            {
                if (int.TryParse(s, out isNumeric))
                    lstConvertedNumbers.Add(Convert.ToInt32(s));
            }

            return lstConvertedNumbers;
        }

        private void checkNegative(string numbers)
        {
            string message = "";
            if (numbers.Contains("-"))
            {
                List<int> convertedNumbers = convertNumbers(numbers);

                foreach (int i in convertedNumbers)
                {
                    if (message == "")

                        message = "Negatives not allowed: " + i;

                    else
                        message += "," + i;

                }

                throw new Exception(message);
            }
        }

        private static List<string> getDelimiters(string numbers)
        {
            List<string> lstDelimiters = new List<string>();
            lstDelimiters.Add(",");
            lstDelimiters.Add("\n");

            string[] arrTempSplitNumbers = numbers.Split(lstDelimiters.ToArray(), StringSplitOptions.None);

            if (arrTempSplitNumbers[0].Contains("//"))
            {
                lstDelimiters.Add(arrTempSplitNumbers[0].Substring(2));
            }

            return lstDelimiters;
        }

        private static string checkEmpty(string numbers)
        {
            if (numbers == "")
                numbers = "0";
            return numbers;
        }

        private List<int> checkForThousand(List<int> lstConvertedNumbers)
        {
            List<int> lstToRemove = new List<int>();

            foreach (int i in lstConvertedNumbers)
            {
                if (i > 1000)
                    lstToRemove.Add(i);
            }

            lstConvertedNumbers.Remove

            return lstConvertedNumbers;
        }
    }
}
