using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContainerKata1
{
    public class Sorter
    {

        public string[] GetFile()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Input.txt");
            return File.ReadAllLines(path);
        }


        public List<string> Sort(string[] arrFileContents)
        {
            List<string> lstMessages = new List<string>();
            int caseCount = 1;

            foreach (string item in arrFileContents)
            {
                if (item.ToUpper().Equals("END"))
                {
                    break;
                }

                string uniqueCharacters = "";
                

                Dictionary<char, int> dicUniqueCount = GetUniqueLetterCount(item, out uniqueCharacters);

                List<Stack<char>> lstStacks = new List<Stack<char>>();

                foreach (char currentLetter in item)
                {
                    if (lstStacks.Count > 0)
                    {
                        lstStacks = CheckStack(lstStacks, currentLetter, dicUniqueCount);
                    }
                    else
                    {
                        lstStacks = AddStack(lstStacks, currentLetter);
                    }
                }

                lstMessages.Add("Case " + caseCount + ": " + lstStacks.Count());
                caseCount++;

            }

            return lstMessages;
        }

        public List<Stack<char>> AddStack(List<Stack<char>> lstStacks, char currentLetter)
        {
            lstStacks.Add(new Stack<char>());
            lstStacks[lstStacks.Count - 1].Push(currentLetter);

            return lstStacks;
        }

        public List<Stack<char>> CheckStack(List<Stack<char>> lstStacks, char currentLetter, Dictionary<char, int> dicUniqueCount)
        {
            bool inStack = false;
            foreach (Stack<char> workingStack in lstStacks)
            {
                if (currentLetter <= workingStack.Peek() && inStack == false)
                {
                    workingStack.Push(currentLetter);
                    inStack = true;
                }

            }

            if (!inStack)
            {
                lstStacks = AddStack(lstStacks, currentLetter);
            }


            return lstStacks;
        }

        private static Dictionary<char, int> GetUniqueLetterCount(string item, out string uniqueCharacters)
        {
            uniqueCharacters = new string(item.Distinct().ToArray());
            Dictionary<char, int> dicUniqueCount = new Dictionary<char, int>();

            foreach (char letter in uniqueCharacters)
            {
                dicUniqueCount.Add(letter, item.Count(x => x == letter));
            }

            return dicUniqueCount;
        }
    }
}
