using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator4
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            numbers = checkIfEmpty(numbers);

            List<string> lstDelimiters = getDelimiters(numbers);

            List<int> lstSplitNumbers = initializeSplitNumbers(numbers, lstDelimiters);

            checkForNegative(numbers, lstSplitNumbers);

            return lstSplitNumbers.Sum();
        }

        private string checkIfEmpty(string numbers)
        {
            if (numbers == "")
                numbers = "0";

            return numbers;
        }


        private string[] splitNumbersOnDelim(string numbers, List<string> delimiters)
        {
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
        }

        private List<int> initializeSplitNumbers(string numbers, List<string> delimiters)
        {
            List<int> lstSplitNumbers = new List<int>();
            int isNumeric = 0;
            string[] arrTempNumbers = splitNumbersOnDelim(numbers, delimiters);
            int workingNumber = 0;

            foreach (string s in arrTempNumbers)
            {
                if (int.TryParse(s, out isNumeric))
                {
                    workingNumber = Convert.ToInt32(s);

                    if (workingNumber < 1001)
                        lstSplitNumbers.Add(workingNumber);
                }

            }

            return lstSplitNumbers;
        }

        private List<string> getDelimiters(string numbers)
        {
            List<string> lstDelimiters = new List<string>();

            lstDelimiters.Add(",");
            lstDelimiters.Add("\n");

            string[] arrTempNumbers = splitNumbersOnDelim(numbers, lstDelimiters);

            if (arrTempNumbers[0].Contains("//") && arrTempNumbers[0].Contains("["))
            {
                lstDelimiters = getMultipleDelimiters(lstDelimiters, arrTempNumbers);
            }
            else
            {
                lstDelimiters = getSingleDelimiter(lstDelimiters, arrTempNumbers);
            }

            return lstDelimiters;
        }

        private static List<string> getSingleDelimiter(List<string> lstDelimiters, string[] arrTempNumbers)
        {
            foreach (string s in arrTempNumbers)
            {

                if (s.Contains("//"))
                    lstDelimiters.Add(s.Substring(2));
            }

            return lstDelimiters;
        }

        private static List<string> getMultipleDelimiters(List<string> lstDelimiters, string[] arrTempNumbers)
        {
            string[] tempDelimList = arrTempNumbers[0].Split('[');

            foreach (string s in tempDelimList)
            {
                if (s.Contains(']'))
                    lstDelimiters.Add(s.Substring(0, s.IndexOf(']')));
            }

            return lstDelimiters;
        }

        private void checkForNegative(string numbers, List<int> splitNumbers)
        {
            string message = "";

            if (numbers.Contains("-"))
            {
                message = buildExceptionMessage(splitNumbers);

                throw new Exception(message);
            }
        }

        private string buildExceptionMessage(List<int> lstSplitNumbers)
        {
            string message = "";

            foreach (int i in lstSplitNumbers)
            {
                if (i < 0)
                {
                    if (message == "")
                        message += "Negatives not allowed: " + i;
                }
                else
                {
                    message += "," + i;
                }
            }

            return message;
        }
    }
}
