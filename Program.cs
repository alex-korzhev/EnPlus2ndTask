using System;

namespace EnPlus2ndTask
{

    class Program
    {
        static void Main(string[] args)
        {
            test();
        }

        public static int fib(int mode, int value)
        {
            //Числа Фибоначчи без рекурсии (гораздо быстрее работает, чем рекурсия), начиная от 0.
            if (mode == 1)
            {
                int a = 0;
                int b = 1;
                int temp;
                if (value == a) { return a; }
                if (value == b) { return b; }
                for (int i = 2; i<= value; i++){
                    temp = b;
                    b = a + b; 
                    a = temp;
                }
                return b;
            }

            /* ****************************************************************
             * ОБЪЯСНЕНИЕ (обратная задача)
             * Начиная с index = 5 (где fib(5) = 5), функция fib(n) всегда больше n
             * Соответственно, для value <= 5 нужно проверить первые 5 чисел (0, 1, 2, 3, 5)
             * Дальше, если fib(n) больше чем value, 
             * но до этого ни разу не выполнилось fib(n) == value,
             * значит value не принадлежит fib вообще.
             *******************************************************************/


            if (mode == 2)
            {
                for (int i = 0; i <= (value > 5 ? value : 5); i++)
                {
                    if (fib(1, i) == value) { return i; }
                    if (fib(1, i) > value) { return -1; }
                }
            }
            return -100; //Что-то пошло совсем не так
        }


        // ***********************************Эксперименты

        public static int fibrec(int value){ //Фибоначчи через рекурсию
            if (value < 0) { return 0; }
            if (value == 1) { return 1; }
            return (fibrec(value - 1) + fibrec(value - 2));
        }

        public static int bin(int mode, int value){ //Фибоначчи через формулу Бинета
            if (mode == 1)
            {
                double phiP(int pow) { return Math.Pow(((1 + Math.Sqrt(5)) / 2), pow); }
                double phiM(int pow) { return Math.Pow(((1 - Math.Sqrt(5)) / 2), pow); }
                return (int)((phiP(value) - phiM(value)) / Math.Sqrt(5));
            }
            if (mode == 2){
                for (int i = 0; i < value; i++)
                {
                    if (bin(1, i) == value) { return i; }
                    if (bin(1, i) > value) { return -1; }
                }
                return -1;
            }
            return -100;
        }

        public static void test(){
            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine($"Ind: {i}  ==FIB== {fib(1, i)} ==BIN== {bin(1, i)}");
            }
            Console.WriteLine($"8 = {fib(2, 8)} ==BIN== {bin(2, 8)}");
            Console.WriteLine($"13 = {fib(2, 13)} ==BIN== {bin(2, 13)}");
            Console.WriteLine($"-2 = {fib(2, -2)} ==BIN== {bin(2, -2)}");
            Console.WriteLine($"4 = {fib(2, 4)} ==BIN== {bin(2, 4)}");
            Console.WriteLine($"75025 = {fib(2, 75025)} ==BIN== {bin(2, 75025)}");
            Console.WriteLine($"75026 = {fib(2, 75026)} ==BIN== {bin(2, 75026)}");
            Console.WriteLine(bin(1, int.MaxValue - 1));
            Console.ReadLine();
        }
        

    }

    
}
