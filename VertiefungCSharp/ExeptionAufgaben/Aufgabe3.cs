using System;
using System.Collections.Generic;
using System.Text;

namespace ExeptionAufgaben
{
    public static class Aufgabe3
    {
        //powerd by https://github.com/SteffenKloempges
        public static void CreateCopyright(this string text)
        {
            string[] textToArr = text.Split(" ");
            for (int i = 0; i < textToArr.Length; i++)
            {
                if (i == 0 || i % 10 == 0)
                {
                    System.Console.Write("Bitlc Dortmund ");
                }
                else
                {
                    System.Console.Write(textToArr[i] + " ");
                }
            }
        }
        static class CopyrightClass
        {
        }
    }
}
