using System.IO;
using System.Reflection;

namespace ContainerKata4
{
    public interface IReader
    {
        string[] GetInput();
    }

    public class FileReader : IReader
    {
        public string[] GetInput()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input.txt");

            return File.ReadAllLines(path);
        }
    }

    public class CsvReader : IReader
    {
        public string[] GetInput()
        {
            string input = "A,CBACBACBACBACBA,CCCCBBBBAAAA,ACMICPC,end";
  
            return input.Split(',');
        }
    }
}
