﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class IEnumFormateExtenstion
    {
        public static string FormateLine<T>(this IEnumerable<T> collection, Func<T, string> formater, string delim)
        {
            return FormateLine(collection, formater, delim, delim);
        }

        public static string FormateLine<T>(
            this IEnumerable<T> collection,
            Func<T, string> formater,
            string innerDelim,
            string lastDelim)
        {
            StringBuilder bld = new StringBuilder();

            int size = collection.Count();
            int i = 0;
            foreach (var item in collection)
            {
                bld.Append(formater(item));
                if (i != size - 1)
                    bld.Append(innerDelim);
                else
                    bld.Append(lastDelim);
                i++;
            }
            return bld.ToString();
        }

        public static string FormateLine<T>(this IEnumerable<T> collection, Func<T, int, string> pred, string delim)
        {
            return FormateLine(collection, pred, delim, delim);
        }

        public static string FormateLine<T>(this IEnumerable<T> collection, Func<T, int, string> pred, string innerDelim, string lastDelim)
        {
            StringBuilder bld = new StringBuilder();

            int size = collection.Count();
            int i = 0;
            foreach (var item in collection)
            {
                bld.Append(pred(item, i));
                if (i != size - 1)
                    bld.Append(innerDelim);
                else
                    bld.Append(lastDelim);
                i++;
            }

            return bld.ToString();
        }

        public static string FormateLines<T>(this IEnumerable<T> collection, Func<T, string> pred)
        {
            StringBuilder bld = new StringBuilder();
            foreach (var item in collection)
            {
                bld.AppendLine(pred(item));
            }
            return bld.ToString();
        }

        public static string FormateLines<T>(this IEnumerable<T> collection, Func<T, int, string> contFormat)
        {
            StringBuilder bld = new StringBuilder();
            int i = 0;
            foreach (var item in collection)
            {
                bld.AppendLine(contFormat(item, i));
                i++;
            }
            return bld.ToString();
        }

        public static void FormateLines<T>(this IEnumerable<T> collection, TextWriter wr, Func<T, string> pred)
        {
            foreach (var item in collection)
            {
                wr.WriteLine(pred(item));
            }
        }

        public static void FormateLines<T>(this IEnumerable<T> collection, TextWriter wr, Func<T, int, string> contFormat)
        {
            int i = 0;
            foreach (var item in collection)
            {
                wr.WriteLine(contFormat(item, i));
                i++;
            }
        }

        public static void ForEachElse<T>(this IEnumerable<T> source, Func<T, bool> action, Action @else)
        {
            foreach (var i in source)
            {
                if (!action(i))
                {
                    return;
                }
            }
            @else();
        }
    }
}
