﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Faker
{
    internal static class StringExtensions
    {
        public static string Replace(this string str, char item, Func<char> character)
        {
            StringBuilder builder = new StringBuilder(str.Length);

            foreach (char c in str.ToCharArray())
            {
                builder.Append(c == item ? character() : c);
            }

            return builder.ToString();
        }

        public static string Numerify(this string number_string)
        {
            return number_string.Replace('#', () => new Random().Next(10).ToString().ToCharArray()[0]);
        }

        public static string Letterify(this string letter_string)
        {
            return letter_string.Replace('?', () => 'a'.To('z').Rand());
        }

        public static string Bothify(this string str)
        {
            return Letterify(Numerify(str));
        }
    }
}
