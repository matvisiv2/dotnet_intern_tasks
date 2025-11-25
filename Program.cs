using System;

namespace dotnet_intern_tasks
{
    class Program
    {
        static void Main()
        {
            Task_01_Temperature_Converter();

            // Delay();
            Print("Exit...");
        }

        public static void Task_01_Temperature_Converter()
        {
            Print(Fit_Title("Task_01_Temperature_Converter"));

            string input_data;
            double t_celsium;
            double t_fahrenheit;

            do
            {
                Print("Enter the temperature in degrees Celsius (or 'e' to exit): ");
                try
                {
                    input_data = Console.ReadLine() ?? "";

                    if (string.Compare(input_data, "e") == 0)
                    {
                        break;
                    }

                    t_celsium = Convert.ToDouble(input_data);

                    t_fahrenheit = (t_celsium * 9 / 5) + 32;

                    Print($"Temperature in Fahrenheit is: {t_fahrenheit}\n");
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