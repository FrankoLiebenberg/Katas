using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator1
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            int result = 0;

            numbers = checkIfEmpty(numbers);

            string delimiter = checkForDelimiter(numbers);

            numbers = stripModifiers(numbers, delimiter);

            string[] splitNumbers = splitOnDelimiter(numbers, delimiter);

            int[] convertedNumbers = convertToIntArray(splitNumbers);

            checkForNegatives(convertedNumbers);

            foreach (int number in convertedNumbers)
            {
                result += number;
            }

            return result;
        }

        public string checkForDelimiter(string numbers)
        {
            string delimiter = "";

            int slashes = numbers.IndexOf("//");
            int newLine = numbers.IndexOf("\n");

            try
            {
                if (slashes != -1)
                    delimiter = numbers.Substring(slashes + 2, newLine - (slashes + 2));
                else
                    delimiter = ",";
            }

            catch (Exception ex)
            {
                delimiter = ",";
            }

            return delimiter;
        }

        public void checkForNegatives(int[] convertedNumbers)
        {
            List<int> negativeNumbers = new List<int>();
            string message = "Negatives not allowed : ";

            foreach (int num in convertedNumbers)
            {
                if (num < 0)
                    negativeNumbers.Add(num);
            }

            if (negativeNumbers.Count > 0)
            {
                foreach (int num in negativeNumbers)
                {
                    if (!message.Contains("-"))
                        message += "" + num;

                    else
                        message += "," + num;
                }

                throw new CustomException(message);
            }




        }

        public string stripModifiers(string numbers, string delimiter)
        {
            if (numbers.IndexOf("//") != -1)
            {
                numbers = numbers.Replace("\n", "");
                numbers = numbers.Replace("//", "");

                numbers = numbers.Remove(numbers.IndexOf(delimiter), delimiter.Length);
            }

            return numbers;
        }

        public string[] splitOnDelimiter(string numbers, string delimiter)
        {
            return numbers.Split(new string[] { delimiter }, StringSplitOptions.None);
        }

        public int[] convertToIntArray(string[] splitNumbers)
        {
            int[] convertedNumbers = new int[splitNumbers.Count()];

            for (int numCount = 0; numCount < splitNumbers.Count(); numCount++)
            {
                convertedNumbers[numCount] = Convert.ToInt32(splitNumbers[numCount]);
            }

            return convertedNumbers;
        }



        public string checkIfEmpty(string numbers)
        {
            if (numbers == "")
            {
                numbers = "0";
            }

            return numbers;
        }
    }

}
