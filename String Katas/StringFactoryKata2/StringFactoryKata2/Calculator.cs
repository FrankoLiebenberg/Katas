using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFactoryKata2
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            numbers = CheckForEmpty(numbers);
            List<int> lstConvertedNumbers = ConvertNumbers(numbers);

            return lstConvertedNumbers.Sum(); ;
        }

        private static List<int> ConvertNumbers(string numbers)
        {
            string[] arrSplitNumbers = SplitNumbers(numbers);

            List<int> lstConvertedNumbers = new List<int>();

            int isNumeric = 0;
            int holdingNumber =0;

            foreach (string s in arrSplitNumbers)
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

            CheckForNegative(lstConvertedNumbers);

            return lstConvertedNumbers;
        }

        private static string[] SplitNumbers(string numbers)
        {
            DelimiterFactory factory = new ConcreteDelimiterFactory();
            IDelimiter splittingMechanism = factory.GetDelimiter(numbers);


            List<string> lstDelimiters = splittingMechanism.GetDelimiters(numbers);

            string[] arrSplitNumbers = numbers.Split(lstDelimiters.ToArray(), StringSplitOptions.None);
            return arrSplitNumbers;
        }

        private static string CheckForEmpty(string numbers)
        {
            if (numbers == "")
            {
                numbers = "0";
            }

            return numbers;
        }

        private static void CheckForNegative(List<int> lstConvertedNumbers)
        {
            if (lstConvertedNumbers.Min() < 0)
            {
                string message = "";

                foreach (int i in lstConvertedNumbers)
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

                throw new Exception(message);
            }

        }
    }
}
