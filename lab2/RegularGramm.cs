using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labs.lab2
{
    class RegularGramm
    {
        public static void Task()
        {
            Console.WriteLine("Введите выражение: ");
            string s = Console.ReadLine();

            char[] charArr = s.ToCharArray();
            int[] intArr = Array.ConvertAll(charArr, c => (int)Char.GetNumericValue(c));

            int m = 0, d = 0, check = 0, oldN = 0, newN = 0;
            double result = 0, left = 0, right = 0;

            char[] charsToTrim = { '*', '/' };

            if (Regex.IsMatch(s, @"^[\d]{1,}([\*|\/][\d]{1,}){0,}$"))
            {
                for (int i = 0; i < intArr.Length; i++)
                {
                    if (!char.IsDigit(charArr[0]))
                    {
                        Console.WriteLine("Неврный формат выражения!");
                        break;
                    }
                    if (char.IsDigit(charArr[i]))
                    {
                        d = intArr[i];
                        m = 10 * m + d;
                    }
                    if (charArr[i] == '*' || charArr[i] == '/' || i == intArr.Length - 1)
                    {
                        check++;
                        newN = i;
                        right = m;
                        if (check >= 2)
                        {
                            Console.WriteLine("charArr[n] = " + charArr[oldN]);
                            if (charArr[oldN] == '/')
                            {
                                result = left / right;
                                m = 0;
                                Console.WriteLine("res = " + result);
                            }
                            else if (charArr[oldN] == '*')
                            {
                                result = left * right;
                                m = 0;
                                Console.WriteLine("res = " + result);
                            }
                        }
                        if (check >= 2)
                        {
                            left = result;
                        }
                        else
                        {
                            if (check == 1)
                                result = right;
                            left = right;
                        }

                        m = 0;
                        oldN = newN;
                    }
                }
            }
            else
                Console.WriteLine("Неврный формат выражения!");

            //Console.WriteLine("res = " + result);

        }
    }
}
