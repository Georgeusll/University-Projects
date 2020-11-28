using System;
using System.IO;

namespace InfNums_Final
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @Path.GetFullPath(@"C:\Users\Georgeus\Downloads\infint.txt");

            string[] lines = File.ReadAllLines(path);

            InfInt number1, number2, result;
            string operation;

            for (int i = 0; i < lines.Length; i += 3)
            {
                number1 = new InfInt(lines[i]);  //read lines
                number2 = new InfInt(lines[i + 1]); 
                operation = lines[i + 2];
                //read all the lines and on 3rd like one of those operations:
                switch (operation)
                {
                    case "+":
                        result = number1.plus(number2);
                        break;
                    case "-":
                        result = number1.minus(number2);
                        break;
                    case "*":
                        result = number1.mult(number2);
                        break;
                    default:
                        result = null;
                        break;
                }

                Console.Out.WriteLine($"{number1} {operation} {number2} = {result}");
            }

            


        }
    }
}
