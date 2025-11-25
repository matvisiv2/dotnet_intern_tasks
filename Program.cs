using System;

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
                        // Task_01_Temperature_Converter();
                        Print(Fit_Title("Task_01_Temperature_Converter"));
                        Task_Cycle(Task_01_Temperature_Converter);
                        break;
                    case '2':
                        // Task_02_Age_Check();
                        Print(Fit_Title("Task_02_Age_Check"));
                        Task_Cycle(Task_02_Age_Check);
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

        // public static void Task_01_Temperature_Converter()
        // {
        //     Print(Fit_Title("Task_01_Temperature_Converter"));

        //     string input_value;
        //     double t_celsium;
        //     double t_fahrenheit;

        //     do
        //     {
        //         Print("Enter the temperature in degrees Celsius (or 'e' to exit): ");
        //         try
        //         {
        //             input_value = Console.ReadLine() ?? "";

        //             if (string.Compare(input_value, "e") == 0)
        //             {
        //                 Print("Back to main menu...\n");
        //                 break;
        //             }

        //             t_celsium = Convert.ToDouble(input_value);

        //             t_fahrenheit = (t_celsium * 9 / 5) + 32;

        //             Print($"Temperature in Fahrenheit is: {t_fahrenheit}\n");
        //         }
        //         catch
        //         {
        //             Print("Incorrect value. Try again.\n");
        //         }
        //     } while (true);
        // }

        public static string Task_01_Temperature_Converter(string input_value)
        {
            double t_celsium;
            double t_fahrenheit;

            t_celsium = Convert.ToDouble(input_value);

            t_fahrenheit = (t_celsium * 9 / 5) + 32;

            return $"Temperature in Fahrenheit is: {t_fahrenheit}\n";
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