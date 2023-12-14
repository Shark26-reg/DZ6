
//Доработайте класс калькулятора способным работать как с целочисленными так и с дробными числами. (возможно стоит задействовать перегрузку операций).

namespace DZ6
{ 
    internal class Program
    {
        static void Calculator_GotResult(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($"{((Calculator)sendler).Result}");
        }
        static void Main(string[] args)
        {
            ICalc calc = new Calculator();

            calc.GotResult += Calculator_GotResult;

            while (true)
            {
                Console.WriteLine("Введите команду (sum, sub, mul, div) и значение через пробел, или 'exit' для выхода:");
                string input = Console.ReadLine();

                // Проверяем, не желает ли пользователь выйти
                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit")
                {
                    break;
                }

                string[] parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Неверный формат ввода");
                    continue;
                }

                string command = parts[0].ToLower();
                if (!double.TryParse(parts[1], out double value))
                {
                    Console.WriteLine("");
                    continue;
                }

                switch (command)
                {
                    case "sum":
                        calc.Sum(value);
                        break;
                    case "sub":
                        calc.Subtruct(value);
                        break;
                    case "mul":
                        calc.Multiply(value);
                        break;
                    case "div":
                        try
                        {
                            calc.Divide(value);
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("На 0 делить не льзя");
                        }
                        break;
                    default:
                        Console.WriteLine("Не верная команда, введите: sum, sub, mul, div.");
                        break;
                }
            }
        }

    }
}

