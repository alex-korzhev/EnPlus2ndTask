using System;

namespace EnPlus2ndTask
{

    class Program
    {
        static void Main(string[] args)
        {
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
                for (int i = 2; i <= value; i++)
                {
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
    }
}
