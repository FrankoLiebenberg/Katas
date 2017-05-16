using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFactoryKata1
{
    public class Calculator
    {
        public object Add(string numbers)
        {
            numbers = CheckForEmpty(numbers);

            List<int> lstConvertedNumbers = SplitAndConvert(numbers);

            return lstConvertedNumbers.Sum();
        }

        private static string CheckForEmpty(string numbers)
        {
            if (numbers == "")
            {
                numbers = "0";
            }

            return numbers;
        }

        private static List<int> SplitAndConvert(string numbers)
        {
            string[] tempArrSplitNumbers = SplitNumbers(numbers);
            List<int> lstConvertedNumbers = ConvertNumber(tempArrSplitNumbers);

            if (numbers.Contains("-"))
            {
                CheckForNegatives(lstConvertedNumbers);
            }

            return lstConvertedNumbers;
        }

        private static void CheckForNegatives(List<int> lstConvertedNumbers)
        {
            string message = "";

            foreach (int i in lstConvertedNumbers)
            {
                if (i < 0)
                {
                    if (message == "")
                    {
                        message = "Negatives not allowed: " + i;
                    }
                    else
                    {
                        message += "," + i;
                    }
                }
            }

            throw new Exception(message);
        }

        private static List<int> ConvertNumber(string[] tempArrSplitNumbers)
        {
            List<int> lstConvertedNumbers = new List<int>();
            int isNumeric = 0;
            int holdingNumber = 0;

            foreach (string s in tempArrSplitNumbers)
            {

                if (int.TryParse(s, out isNumeric))
                {
                    holdingNumber = Convert.ToInt32(s);

                    if (holdingNumber < 1001)
                    {
                        lstConvertedNumbers.Add(holdingNumber);
                    }
                }
            }

            return lstConvertedNumbers;
        }

        private static string[] SplitNumbers(string numbers)
        {
            DelimiterFactory factory = new ConcreteDelimiterFactory();
            IDelimiters splittingMechanism = factory.GetDelimiter(numbers);
            List<string> lstDelimiters = splittingMechanism.GetDelimiters(numbers);
            string[] arrSplitNumbers = numbers.Split(lstDelimiters.ToArray(), StringSplitOptions.None);

            return arrSplitNumbers;
        }
    }
}
