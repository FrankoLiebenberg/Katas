using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator2
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            numbers = checkIfEmptyString(numbers);
            int[] splitNumbers = splitAndConvert(numbers);
            checkIfNegative(splitNumbers);

            return splitNumbers.Sum();
        }

        public string checkIfEmptyString(string numbers)
        {
            if (numbers == "")
                numbers = "0";

            return numbers;
        }

        public int[] splitAndConvert(string numbers)
        {
            char delimiter = getDelimiter(numbers);
            string[] split = numbers.Split(new Char[] { ',', '\n', delimiter });
            int[] convertedNumbers = new int[split.Count()];

            for (int i = 0; i < split.Count(); i++)
            {
                if (split[i] != "//" && split[i] != "")
                    convertedNumbers[i] = Convert.ToInt32(split[i]);
            }

            return convertedNumbers;
        }

        public char getDelimiter(string numbers)
        {
            char delimiter = ',';

            if (numbers.Contains("//"))
            {
                string[] splitOnNewLine = numbers.Split('\n');
                delimiter = Convert.ToChar(splitOnNewLine[0].Substring(2));
            }

            return delimiter;
        }


        public void checkIfNegative(int[] splitNumbers)
        {
            string message = "Negatives not allowed: ";

            foreach (int num in splitNumbers)
            {
                if (num < 0)
                {
                    if (!message.Contains("-"))
                        message += Convert.ToString(num);

                    else
                        message += "," + num;
                }
            }
            if (message.Contains("-"))
                throw new CustomException(message);
        }

    }
}
