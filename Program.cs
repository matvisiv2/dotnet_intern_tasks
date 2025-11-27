using System;
using System.Text.RegularExpressions;

namespace dotnetInternTasks
{
    class Program
    {
        static void Main()
        {
            string menuInfo =
                "1. Task01TemperatureConverter;\n" +
                "2. Task02AgeCheck;\n" +
                "3. Task03MultiplicationTable;\n" +
                "4. Task04SumOfNumbersInRange;\n" +
                "5. Task05ClassBook;\n" +
                "c. Clear console;\n" +
                "e. Exit;\n";

            string option;

            do
            {
                Print(FitTitle("Main menu"));
                Print(menuInfo);

                Print("Enter your choice: ");

                option = Console.ReadLine() ?? "";

                if (option.Length == 0 || option.Length > 1)
                {
                    option = "i";
                }

                switch (option[0])
                {
                    case '1':
                        Print(FitTitle("Task01TemperatureConverter(Celsius to Fahrenheit)"));
                        Print("Tip: You need to enter the temperature in Celsius to convert it to Fahrenheit.\n");
                        TaskCycle(Task01TemperatureConverter);
                        break;
                    case '2':
                        Print(FitTitle("Task02AgeCheck"));
                        Print("Tip: You need to enter an age to see which age group the person belongs to.\n");
                        TaskCycle(Task02AgeCheck);
                        break;
                    case '3':
                        Print(FitTitle("Task03MultiplicationTable"));
                        Print("Tip: You need to enter some number to see its multiplication table.\n");
                        TaskCycle(Task03MultiplicationTable);
                        break;
                    case '4':
                        Print(FitTitle("Task04SumOfNumbersInRange"));
                        Print("Tip: You need to enter two numbers separated by a comma sign to see the sum in their range.\n");
                        Print("Tip: start value must be less than end value.\n");
                        TaskCycle(Task04SumOfNumbersInRange);
                        break;
                    case '5':
                        Print(FitTitle("Task05ClassBook"));
                        Print("Tip: You have to enter info about book in format: title, author, year.\n");
                        TaskCycle(Task05ClassBook);
                        break;
                    case 'c':
                        Console.Clear();
                        break;
                    case 'e':
                        break;
                    case 'i':
                    default:
                        Print("Incorrect input. Try again.\n\n");
                        break;
                }
            } while (option[0] != 'e');

            Print("Exit...");
        }

        public static string Task01TemperatureConverter(string inputValue)
        {
            double tCelsium;
            double tFahrenheit;

            tCelsium = Convert.ToDouble(inputValue);

            tFahrenheit = (tCelsium * 9 / 5) + 32;

            return $"{tCelsium}C{(char)176} = {tFahrenheit}F{(char)176}\n";
        }

        public static string Task02AgeCheck(string inputValue)
        {
            byte age = Convert.ToByte(inputValue);
            string ageGroup;
            string info = string.Empty;

            if (age < 10)
            {
                ageGroup = "child";
            }
            else if (age < 18)
            {
                ageGroup = "teenager";
            }
            else if (age < 80)
            {
                ageGroup = "adult";
            }
            else
            {
                ageGroup = "adult with respectable age";
            }

            if (age > 122)
            {
                info = "The oldest verified person in human history is Frenchwoman Jeanne Calment, who lived to be 122 years and 164 days old";
            }

            return $"Person with age {age} years is {ageGroup}. {info}\n";
        }

        public static string Task03MultiplicationTable(string inputValue)
        {
            int num = Convert.ToInt32(inputValue);
            string res = string.Empty;

            for (short i = 1; i <= 10; i++)
            {
                res += $"{num} x {i} = {num * i}\n";
            }

            return res + '\n';
        }

        public static string Task04SumOfNumbersInRange(string inputValue)
        {
            Regex regex = new Regex(@"^\s*(-?\d+)\s*,\s*(-?\d+)\s*$");
            Match match = regex.Match(inputValue);

            int start = int.Parse(match.Groups[1].Value);
            int end = int.Parse(match.Groups[2].Value);

            if (start >= end)
            {
                throw new Exception();
            }

            int[] range = Enumerable.Range(start, end - start + 1).ToArray();

            return $"sum({start}, {end}) = {range.Sum()}\n";
        }

        public static string Task05ClassBook(string inputValue)
        {
            Regex regex = new Regex(@"^\s*(.+?)\s*,\s*(.+?)\s*,\s*(-*\d{1,4})\s*$");
            Match match = regex.Match(inputValue);

            if (!match.Success)
            {
                throw new Exception("doesn't match");
            }

            string title = match.Groups[1].Value.Trim();
            string author = match.Groups[2].Value.Trim();
            short year = Convert.ToInt16(match.Groups[3].Value.Trim());

            Book book = new(title, author, year);
            
            return book.GetInfo();
        }

        public static void TaskCycle(Func<string, string> function)
        {
            string inputData;

            do
            {
                Print("Enter value ('c' to clear, 'e' to exit): ");

                try
                {
                    inputData = Console.ReadLine() ?? "";

                    if (inputData.Equals("c"))
                    {
                        Console.Clear();
                        continue;
                    }
                    else if (inputData.Equals("e"))
                    {
                        Print("Back to main menu...\n\n");
                        break;
                    }

                    Print(function(inputData));
                }
                catch
                {
                    Print("Incorrect value. Try again.\n");
                }
            } while (true);
        }

        public static void Print(string s)
        {
            Console.Write(s);
        }

        public static string FitTitle(string title)
        {
            return $"-----{title.PadRight(40, '-')}\n";
        }

        public static void Delay()
        {
            Print("Press enter to exit...");
            Console.ReadLine();
        }
    }
};