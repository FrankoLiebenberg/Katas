using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator5
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            numbers = checkForEmpty(numbers);

            checkForNegative(numbers);

            List<int> lstConvertedNumbers = extractNumbers(numbers);

            return lstConvertedNumbers.Sum();
        }

        private static List<int> extractNumbers(string numbers)
        {
            List<int> lstConvertedNumbers = new List<int>();
            string[] arrSplitNumbers = splitNumbers(numbers);
            int isNumeric = 0;

            foreach (string s in arrSplitNumbers)
            {
                if (int.TryParse(s, out isNumeric))
                {
                    lstConvertedNumbers.Add(Convert.ToInt32(s));
                }
            }

            return lstConvertedNumbers;
        }

        private static string[] splitNumbers(string numbers)
        {
            List<string> lstDelimiters = getDelimiters(numbers);

            return numbers.Split(lstDelimiters.ToArray(), StringSplitOptions.None);
        }

        private static List<string> getDelimiters(string numbers)
        {
            List<string> lstDelimiters = new List<string>();
            lstDelimiters.Add(",");
            lstDelimiters.Add("\n");


            string[] arrTempSplit = numbers.Split(lstDelimiters.ToArray(), StringSplitOptions.None);

            if (arrTempSplit[0].Contains("//"))
            {
                if (arrTempSplit[0].Contains("]"))
                    lstDelimiters = getMultiDelimiters(arrTempSplit[0], lstDelimiters);

                else
                    lstDelimiters.Add(arrTempSplit[0].Substring(2));

            }

            return lstDelimiters;
        }

        private static List<string> getMultiDelimiters(string item, List<string> lstDelimiters)
        {
            string[] arrWorkingSplit = item.Split('[');

            foreach (string s in arrWorkingSplit)
            {
                if (s.Contains("]"))
                    lstDelimiters.Add(s.Substring(0, s.IndexOf("]")));
            }


            return lstDelimiters;
        }

        private static string checkForEmpty(string numbers)
        {
            if (numbers == "")
                numbers = "0";
            return numbers;
        }

        private static void checkForNegative(string numbers)
        {
            if (numbers.Contains("-"))
            {
                string message = formatMessage(numbers);

                throw new Exception(message);
            }
        }

        private static string formatMessage(string numbers)
        {
            List<int> lstExtractedNumbers = extractNumbers(numbers);
            string message = "";

            foreach (int i in lstExtractedNumbers)
            {
                if (i < 0)
                {
                    if (message == "")
                        message = "Negatives not allowed: " + i;

                    else
                        message += "," + i;
                }
            }


            return message;
        }
    }
}
