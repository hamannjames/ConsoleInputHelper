using System;
using System.Collections.Generic;

namespace ConsoleInputHelper
{
    static public class InputHelper
    {
        public static int GetInt(string prompt = "Please enter an integer: ")
        {
            return WaitForParse<int>(int.TryParse, prompt);
        }
        public static int GetInt(string prompt, Func<int, bool> validator)
        {
            return WaitForParse<int>(int.TryParse, prompt, validator);
        }
        public static double GetDouble(string prompt = "Please enter a double: ")
        {
            return WaitForParse<double>(double.TryParse, prompt);
        }
        public static double GetDouble(string prompt, Func<double, bool> validator)
        {
            return WaitForParse<double>(double.TryParse, prompt, validator);
        }
        public static decimal GetDecimal(string prompt = "Please enter a double: ")
        {
            return WaitForParse<decimal>(decimal.TryParse, prompt);
        }
        public static decimal GetDecimal(string prompt, Func<decimal, bool> validator)
        {
            return WaitForParse<decimal>(decimal.TryParse, prompt, validator);
        }
        public static string GetText(string prompt = "Enter some text: ", bool newLine = true)
        {
            if (newLine)
            {
                Console.WriteLine(prompt);
            }
            else
            {
                Console.Write(prompt);
            }
            return Console.ReadLine();
        }
        public static void WaitForText(string prompt = "Press enter to continue...")
        {
            Console.Write(prompt);
            Console.ReadLine();
        }
        public static void WaitForText(string prompt, string text)
        {
            do
            {
                Console.WriteLine(prompt);
            } while (text != (Console.ReadLine()));
        }
        public static void WaitForText(string prompt, IEnumerable<String> values)
        {
            do
            {
                Console.WriteLine(prompt);
            } while (!CheckCollectionForText(Console.ReadLine(), values));
        }
        public static void WaitForText(string prompt, string text, Action perform, bool immediately = false)
        {
            Console.WriteLine(prompt);
            if (immediately)
                perform();
            while (text != (Console.ReadLine()))
            {
                perform();
                Console.WriteLine(prompt);
            }
        }
        private static T WaitForParse<T>(TryParseHandler<T> handler, string prompt, Func<T, bool> validator = null)
        {
            T output = default(T);
            do
            {
                InputHelper.Prompt(prompt);
            }
            while (!handler(Console.ReadLine(), out output) || !(validator != null ? validator(output) : true));
            return output;
        }
        private static bool CheckCollectionForText(string text, IEnumerable<String> collection)
        {
            foreach (string item in collection)
            {
                if (text == item)
                    return true;
            }
            return false;
        }
        public static void Prompt(string prompt)
        {
            Console.Write(prompt);
        }
        private delegate bool TryParseHandler<T>(string value, out T result);
    }
}
