namespace CSharpLessons
{   
    class MyProgram
    {
        readonly static string[] TaskText = {
            "Задача 34: " + 
                "\nБыл задан массив, заполненный случайными положительными трёхзначными числами. " + 
                "\nПрограмма покажет количество чётных чисел в массиве.", 
            "Задача 35: " +
                "\nБыл задан одномерный массив из 123 случайных чисел. " + 
                "\nПрограмма найдет количество элементов массива, " + 
                "\nзначения которых лежат в отрезке [10,99].",
            "Задача 36: " +
                "\nБыл задан одномерный массив, заполненный случайными числами. " +
                "\nПрограмма найдет сумму элементов, стоящих на нечётных позициях.",
            "Задача 38: " +
                "\nС клавиатуры будет задан массив вещественных (double) чисел. " +
                "\nПрограмма найдет разницу между Max и Min элементов массива."
        };

        private static Random rnd = new Random();

        private static bool MyRead(out int result, string whatToRead = "целое число")
        {
            Console.Write($"Введите {whatToRead}: ");
            string _temp = Console.ReadLine();
            return (Int32.TryParse(_temp, out result));
        }

        private static bool MyRead(out double result, string whatToRead = "дробное число")
        {
            Console.Write($"Введите {whatToRead}: ");
            string _temp = Console.ReadLine();
            return (Double.TryParse(_temp, out result));
        }

        private static int GetNumberOfEvens(int[] array)
        {
            int _result = 0;
            foreach(int i in array)
            {
                if (i % 2 == 0)
                    _result++;
            }
            return _result;
        }

        private static int TaskOne()
        {
            if (MyRead(out int arraySize, "размер массива"))
            {
                Console.Write("Массив: ");
                int[] _arrayOfInt = new int[arraySize];
                for (int i = 0; i < _arrayOfInt.Length; i++)
                {
                    _arrayOfInt[i] = rnd.Next(100, 999);
                    Console.Write(_arrayOfInt[i]);
                    if (i == _arrayOfInt.Length - 1)
                        Console.WriteLine(".");
                    else
                        Console.Write(", ");
                }
                return GetNumberOfEvens(_arrayOfInt);
            }
            return 0;
        }

        private static int TaskTwo()
        {
            int _result = 0;
            const int ARRAY_SIZE = 123;
            int[] _arrayOfInt = new int[ARRAY_SIZE];
            Console.Write("Массив: ");
            for (int i = 0; i < _arrayOfInt.Length; i++)
            {
                _arrayOfInt[i] = rnd.Next(1, 100);
                if (Enumerable.Range(10, 99).Contains(_arrayOfInt[i]))
                {
                    _result++;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(_arrayOfInt[i]);
                Console.ResetColor();
                if (i == _arrayOfInt.Length - 1)
                    Console.WriteLine(".");
                else
                    Console.Write(", ");
            }
            return _result;
        }

        private static int TaskThree()
        {
            if (MyRead(out int arraySize, "размер массива"))
            {
                int _result = 0;
                int[] _arrayOfInt = new int[arraySize];
                Console.Write("Массив: ");
                for (int i = 0; i < _arrayOfInt.Length; i++)
                {
                    _arrayOfInt[i] = rnd.Next(1, 100);
                    if (i % 2 == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

_result += _arrayOfInt[i];
                    }
                    Console.Write(_arrayOfInt[i]);
                    Console.ResetColor();
                    if (i == _arrayOfInt.Length - 1)
                        Console.WriteLine(".");
                    else
                        Console.Write(", ");
                }
                return _result;
}
            return 0;
        }

        private static double TaskFour()
        {
            if (MyRead(out int arraySize, "размер массива"))
            { 
                double[] _arrayOfDouble = new double[arraySize];
                Console.WriteLine("Задайте массив: ");
                for (int i = 0; i < _arrayOfDouble.Length; i++)
                { 
                    if (MyRead(out double arrayElement, $"{i + 1}й элемент массива"))
                    {
                        _arrayOfDouble[i] = arrayElement;
                    }
                }
                return _arrayOfDouble.Max() - _arrayOfDouble.Min();
            }
            return 0d;
        }

        static void Main(string[] args)
        { 
            if (MyRead(out int taskNumber, "номер задачи"))
            {
                Console.WriteLine();

                double _result = 0d;
                Console.WriteLine(TaskText[taskNumber - 1] + "\n");
                switch (taskNumber)
                {
                    case 1:
                        _result = MyProgram.TaskOne();
                        break;
                    case 2:
                        _result = MyProgram.TaskTwo();
                        break;
                    case 3:
                        _result = MyProgram.TaskThree();
                        break;
                    case 4:
                        _result = MyProgram.TaskFour();
                        break;
                    default:
                        Console.WriteLine("Нет такой задачи!");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine($"Результат: {_result}.");
            }

            Console.Write("Для продолжения нажмите ввод...");
            Console.ReadLine();
        }
    }
}
