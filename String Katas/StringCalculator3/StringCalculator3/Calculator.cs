using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator3
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
                numbers = "0";
            int[] convertedNumbers = convertNumbers(numbers);

            return sumAllNumbers(convertedNumbers);
        }

        public int[] convertNumbers(string numbers)
        {
            string[] seperatedNumbers = splitNumbers(numbers);
            int isNumeric = 0;
            int[] convertedNumbers = new int[seperatedNumbers.Count()];


            for (int i = 0; i < seperatedNumbers.Count(); i++)
            {
                if (int.TryParse(seperatedNumbers[i], out isNumeric))
                    convertedNumbers[i] = Convert.ToInt32(seperatedNumbers[i]);
            }

            checkIfNegative(convertedNumbers);

            return convertedNumbers;
        }

        public string[] splitNumbers(string numbers)
        {
            List<string> delimList = getDelimiter(numbers);

            return numbers.Split(delimList.ToArray(), StringSplitOptions.None);
        }

        public List<string> getDelimiter(string numbers)
        {
            List<string> delimList = new List<string>();
            delimList.Add(",");
            delimList.Add("\n");

            string[] seperatedNumbers = numbers.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

            string workingHolder = seperatedNumbers[0];

            if (seperatedNumbers[0].Contains("//"))
            {

                if (workingHolder.Contains("]"))
                {
                    do
                    {
                        delimList.Add(workingHolder.Substring(workingHolder.IndexOf('[') +1, workingHolder.IndexOf(']') - workingHolder.IndexOf('[') - 1));

                        workingHolder = workingHolder.Substring(workingHolder.IndexOf(']') + 1, workingHolder.Length - workingHolder.IndexOf(']') - 1);

                    } while (workingHolder.Contains("]"));
                }
                else
                {
                    delimList.Add(workingHolder.Substring(2));
                }

            }

            return delimList;
        }

        public void checkIfNegative(int[] convertedNumbers)
        {
            string message = "";

            foreach (int num in convertedNumbers)
            {
                if (num < 0)
                {
                    if (message == "")
                    {
                        message += "Cannot contain negatives : " + num;
                    }
                }
            }

            if (message != "")
                throw new CustomException(message);

        }

        public int sumAllNumbers(int[] convertedNumbers)
        {
            int result = 0;

            for (int i = 0; i < convertedNumbers.Count(); i++)
            {
                if (convertedNumbers[i] < 1000)
                    result += convertedNumbers[i];
            }

            return result;
        }
    }
}
