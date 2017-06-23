using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerKata4
{
    public class Stacker
    {

        public List<string> RunInput(IReader reader)
        {
            List<string> messages = new List<string>();

            string[] inputs = reader.GetInput();
            int count = 1;

            foreach (string input in inputs)
            {
                if (input != "end")
                {
                    int result = StackContainers(input);

                    messages.Add("Case " + count + ": " + result);
                    count++;
                }
            }

            return messages;
        }

        public int StackContainers(string input)
        {
            int stackCount = 0;
            //Here we are now...
            List<char> inContainers = new List<char>();
            Dictionary<string, int> characterCounts = GetCharacterCounts(input);
            char previousCharacter = input[0];
            int currentCharacterCount = 0;

            foreach (char character in input)
            {
                SortContainers(ref stackCount, inContainers, characterCounts, ref previousCharacter, ref currentCharacterCount, character);
            }

            if (stackCount == 0)
            {
                stackCount = 1;
            }

            return stackCount;
        }

        private  void SortContainers(ref int stackCount, List<char> inContainers, Dictionary<string, int> characterCounts, ref char previousCharacter, ref int currentCharacterCount, char character)
        {
            int specificCharacterCount;
            characterCounts.TryGetValue(character.ToString(), out specificCharacterCount);

            if (character == previousCharacter && currentCharacterCount <= specificCharacterCount - 1) //Same character, still left over
            {
                currentCharacterCount++;
            }
            else if (character != previousCharacter && currentCharacterCount <= specificCharacterCount - 1)//Different character, still left over
            {
                if (!inContainers.Contains(character))
                {
                    inContainers.Add(character);
                    stackCount++;
                }

                currentCharacterCount = 0;
            }

            previousCharacter = character;
        }

        public Dictionary<string, int> GetCharacterCounts(string input)
        {

            Dictionary<string, int> characterCount = new Dictionary<string, int>();

            string distinctLetters = new String(input.Distinct().ToArray());

            foreach (char letter in distinctLetters)
            {
                characterCount.Add(letter.ToString(), input.Count(l => l == letter));
            }

            return characterCount;
        }
    }
}
