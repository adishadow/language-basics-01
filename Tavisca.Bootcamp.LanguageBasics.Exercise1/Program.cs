using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

         public static int FindDigit(string equation)
        {
            // Add your code here.
            List<string> Numbers = new List<string>();
            string find = string.Empty;
            int exsit = -1,has=-1;
            int A, B, C;
            foreach (char letter in equation)
            {
                if (letter == '*' || letter == '=')
                {
                    
                    Numbers.Add(find);
                    exsit += 1;
                    find = string.Empty;
                }
                if (letter != '*' && letter != '=')
                    find += letter;
                if(letter=='?')
                {
                    has = exsit + 1;

                }
                
            }
            Numbers.Add(find);
           

            if (has != 0 && has != 1)
            {
                A = Int32.Parse(Numbers[0]);
                B = Int32.Parse(Numbers[1]);
                C = A * B;
                int i = Numbers[2].Length-1;
                int temp = C;
                while(temp>0)
                {
                    int rem =temp % 10;
                    if (Numbers[2][i] == '?') return rem;
                    temp = temp / 10;
                    i = i - 1;
                }
            }
            if (has != 1 && has != 2)
            {
                B = Int32.Parse(Numbers[1]);
                C = Int32.Parse(Numbers[2]);
                if (C % B != 0) return -1;
                A = C / B;
                int i = Numbers[0].Length-1;
                int temp = A;
                while (temp > 0)
                {
                    int rem = temp % 10;
                    if (Numbers[0][i] == '?') return rem;
                    temp = temp / 10;
                    i = i - 1;
                }

            }
            if (has != 0 && has != 2)
            {
                A = Int32.Parse(Numbers[0]);
                C = Int32.Parse(Numbers[2]);
                if (C % A != 0) return -1;
                B = C / A;
                int i = Numbers[1].Length-1;
                int temp = B;
                while (temp > 0)
                {
                    int rem = temp % 10;
                    if (Numbers[1][i] == '?') return rem;
                    temp = temp / 10;
                    i = i - 1;
                }
            }
            return -1;
        }
    }
}
