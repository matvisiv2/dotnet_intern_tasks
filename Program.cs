using System;
using System.Text.RegularExpressions;

namespace dotnet_intern_tasks
{
    class Program
    {
        static void Main()
        {
            string option;
            do
            {
                Print(Fit_Title("Main menu"));
                Print("Choose option:\n");
                Print("1. Task_01_Temperature_Converter;\n");
                Print("2. Task_02_Age_Check;\n");
                Print("3. Task_03_Multiplication_Table;\n");
                Print("4. Task_04_Sum_Of_Numbers_In_Range;\n");
                Print("c. Clear console;\n");
                Print("e. Exit;\n\n");

                Print("Enter your choice: ");

                option = Console.ReadLine() ?? "";

                if (option.Length == 0 || option.Length > 1)
                {
                    option = "i";
                }

                switch (option[0])
                {
                    case '1':
                        Print(Fit_Title("Task_01_Temperature_Converter(Celsius to Fahrenheit)"));
                        Print("Tip: You need to enter the temperature in Celsius to convert it to Fahrenheit.\n");
                        Task_Cycle(Task_01_Temperature_Converter);
                        break;
                    case '2':
                        Print(Fit_Title("Task_02_Age_Check"));
                        Print("Tip: You need to enter an age to see which age group the person belongs to.\n");
                        Task_Cycle(Task_02_Age_Check);
                        break;
                    case '3':
                        Print(Fit_Title("Task_03_Multiplication_Table"));
                        Print("Tip: You need to enter some number to see its multiplication table.\n");
                        Task_Cycle(Task_03_Multiplication_Table);
                        break;
                    case '4':
                        Print(Fit_Title("Task_04_Sum_Of_Numbers_In_Range"));
                        Print("Tip: You need to enter two numbers separated by a comme sign to see the sum in their range.\n");
                        Print("Tip: start value must be less than end value.\n");
                        Task_Cycle(Task_04_Sum_Of_Numbers_In_Range);
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

        public static string Task_01_Temperature_Converter(string input_value)
        {
            double t_celsium;
            double t_fahrenheit;

            t_celsium = Convert.ToDouble(input_value);

            t_fahrenheit = (t_celsium * 9 / 5) + 32;

            return $"{t_celsium}C{(char)176} = {t_fahrenheit}F{(char)176}\n";
        }

        public static string Task_02_Age_Check(string input_value)
        {
            byte age = Convert.ToByte(input_value);
            string age_group;
            string info = "";

            if (age < 10)
            {
                age_group = "child";
            }
            else if (age < 18)
            {
                age_group = "teenager";
            }
            else if (age < 80)
            {
                age_group = "adult";
            }
            else
            {
                age_group = "adult with respectable age";
            }

            if (age > 122)
            {
                info = "The oldest verified person in human history is Frenchwoman Jeanne Calment, who lived to be 122 years and 164 days old";
            }

            return $"Person with age {age} years is {age_group}. {info}\n";
        }

        public static string Task_03_Multiplication_Table(string input_value)
        {
            int num = Convert.ToInt32(input_value);
            string res = "";

            for (short i = 1; i <= 10; i++)
            {
                res += $"{num} x {i} = {num * i}\n";
            }

            return res + '\n';
        }

        public static string Task_04_Sum_Of_Numbers_In_Range(string input_value)
        {
            Regex regex = new Regex(@"^\s*(-?\d+)\s*,\s*(-?\d+)\s*$");
            Match match = regex.Match(input_value);

            int start = int.Parse(match.Groups[1].Value);
            int end = int.Parse(match.Groups[2].Value);

            if (start >= end)
            {
                throw new Exception();
            }

            int[] range = Enumerable.Range(start, end - start + 1).ToArray();

            return $"sum({start}, {end}) = {range.Sum()}\n";
        }

        public static void Task_Cycle(Func<string, string> function)
        {
            string input_data;

            do
            {
                Print("Enter value ('c' to clear, 'e' to exit): ");
                try
                {
                    input_data = Console.ReadLine() ?? "";

                    if (string.Compare(input_data, "c") == 0)
                    {
                        Console.Clear();
                        continue;
                    }
                    else if (string.Compare(input_data, "e") == 0)
                    {
                        Print("Back to main menu...\n\n");
                        break;
                    }

                    Print(function(input_data));
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

        public static string Fit_Title(string title)
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