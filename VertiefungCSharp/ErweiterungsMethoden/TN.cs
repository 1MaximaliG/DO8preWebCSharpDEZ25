//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ErweiterungsMethoden
//{
//    public static class Erweiterungsmethoden
//    {
//        public static string Left(this string s, int count)
//        {
//            StringBuilder result = new("");
//            char[] chars = s.ToCharArray();
//            for (int i = 0; i < count; i++)
//            {
//                result.Append(chars[i]);
//            }
//            return result.ToString();
//        }
//        public static string Right(this string s, int count)
//        {
//            StringBuilder result = new("");
//            char[] chars = s.ToCharArray();
//            for (int i = chars.Length - count; i < chars.Length; i++)
//            {
//                result.Append(chars[i]);
//            }
//            return result.ToString();
//        }
//        public static bool IsEvenNumber(this int n)
//        {
//            return n % 2 == 0;
//        }
//        public static bool IsPalindrome(this string s)
//        {
//            char[] array = s.ToCharArray();
//            return array == array.Reverse();
//        }
//        public static bool ContainsDuplicateChar(this string s)
//        {
//            char[] chars = s.ToCharArray();
//            int counter = 0;
//            foreach (char c in chars)
//            {
//                for (int i = 1 + counter; i < chars.Length; i++)
//                {
//                    if (c == chars[i])
//                    {
//                        return true;
//                    }
//                }
//                counter++;
//            }
//            return false;
//        }
//        public static string RemoveDuplicateChars(this string s)
//        {
//            StringBuilder returner = new("");
//            foreach (char c in s)
//            {
//                if (!returner.ToString().Contains(char.ToLower(c)) && !returner.ToString().Contains(char.ToUpper(c)))
//                {
//                    returner.Append(c);
//                }
//            }
//            return returner.ToString();
//        }
//        public static string CapitalizeFirstLetterAndLetterAfterChar(this string s, char[] c)
//        {
//            StringBuilder returner = new("");
//            bool capitalizeNext = true;
//            s = s.ToLower();
//            foreach (char ch in s)
//            {
//                if (capitalizeNext && char.IsLetter(ch))
//                {
//                    returner.Append(char.ToUpper(ch));
//                    capitalizeNext = false;
//                }
//                else
//                {
//                    returner.Append(char.ToLower(ch));
//                }
//                if (c.Contains(ch) || ch == ' ')
//                {
//                    capitalizeNext = true;
//                }
//            }
//            return returner.ToString();
//        }
//    }
//    internal class TN
//    {
//        public static void TNDoMain()
//        {
//            char[] chars = { 'e', 'r', 'l' };
//            Console.WriteLine($"Hello, World!".CapitalizeFirstLetterAndLetterAfterChar(chars));
//            string s = "Hello World!";
//            Console.WriteLine(s.Right(6));
//            Console.WriteLine(s.Left(5));
//            Console.WriteLine(5.IsEvenNumber());
//            Console.WriteLine(4.IsEvenNumber());
//            Console.WriteLine("Otto".IsPalindrome());
//            Console.WriteLine("Otto".ContainsDuplicateChar());
//            Console.WriteLine("Otto".RemoveDuplicateChars());
//            Console.WriteLine("Hinter eines Baumes Rinde wohnt die Made mit dem Kinde".CapitalizeFirstLetterAndLetterAfterChar(['i','s']));
//        }
//    }
//}
