﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFactoryKata1
{
    public interface IDelimiters
    {
        List<string> GetDelimiters(string numbers);
    }

    public class DefaultDelimiter : IDelimiters
    {
        public List<string> GetDelimiters(string numbers)
        {
            List<string> lstDelimiters = new List<string>();
            lstDelimiters.Add(",");

            return lstDelimiters;
        }
    }

    public class NewLineDelimiter : IDelimiters
    {
        public List<string> GetDelimiters(string numbers)
        {
            List<string> lstDelimiters = new List<string>();
            lstDelimiters.Add(",");
            lstDelimiters.Add("\n");

            return lstDelimiters;
        }
    }

    public class CustomDelimiter : IDelimiters
    {
        public List<string> GetDelimiters(string numbers)
        {
            List<string> lstDelimiters = new List<string>();
            lstDelimiters.Add("\n");

            string[] tempArrSplitNumbers = numbers.Split(lstDelimiters.ToArray(), StringSplitOptions.None);

            if(numbers.Contains("["))
            {
                if(tempArrSplitNumbers[0].Contains("]"))
                    lstDelimiters = getMultiDelimiters(tempArrSplitNumbers[0], lstDelimiters);
            }
            else
            {
                lstDelimiters.Add(tempArrSplitNumbers[0].Substring(2));
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
    }


    public abstract class DelimiterFactory
    {
        public abstract IDelimiters GetDelimiter(string numbers);

    }


    public class ConcreteDelimiterFactory : DelimiterFactory
    {
        public override IDelimiters GetDelimiter(string numbers)
        {
            string delimiter = ",";


            if (numbers.Contains("\n"))
            {
                if (numbers.Contains("//"))
                {
                    delimiter = "Custom";
                }

                else
                {
                    delimiter = "New Line";
                }
            }



            switch (delimiter)
            {
                case "New Line":
                    return new NewLineDelimiter();

                case "Custom":
                    return new CustomDelimiter();

                default:
                    return new DefaultDelimiter();
            }

        }
    }
}
