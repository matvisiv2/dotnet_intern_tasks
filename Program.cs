using System;

namespace dotnet_intern_tasks
{
    class Program
    {
        static void Main()
        {
            Task_01_Temperature_Converter();
            Delay();
        }

        public static void Task_01_Temperature_Converter()
        {
            Print(Fit_Title("Task_01_Temperature_Converter"));

            float t_celsium = float.MaxValue;
            bool incorrect_value = false;
            do
            {
                Print("Enter the temperature in degrees Celsius: ");
                try
                {
                    t_celsium = float.TryParse(Console.ReadLine(), out t_celsium) ? t_celsium : float.MaxValue;
                    incorrect_value = t_celsium >= float.MaxValue;
                    if (incorrect_value)
                    {
                        throw new Exception();
                    }
                    float t_fahrenheit = (t_celsium * 9 / 5) + 32;
                    Print($"Temperature in Fahrenheit is: {t_fahrenheit}\n");
                }
                catch
                {
                    Print("Incorrect value. Try again.\n");
                }
            } while (incorrect_value);
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