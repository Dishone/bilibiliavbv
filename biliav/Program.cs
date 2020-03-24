using System;
using System.Collections.Generic;

namespace biliavbv
{
    public class biliavbv
    {
        private static string table = "fZodR9XQDSUm21yCkr6zBqiveYah8bt4xsWpHnJE7jL5VG3guMTKNPAwcF";
        private static int[] s = { 11, 10, 3, 8, 4, 6 };
        private static int xor = 177451812;
        private static long add = 8728348608;
        private static Dictionary<String, Int32?> number;

        static void Main()
        {
            Console.WriteLine(enc(170001));
            Console.WriteLine(dec("BV17x411w7KC"));
        }

        private static string topOffIndex(string before, string updated, int index)
        {
            return before.Substring(0, index) + updated + before.Substring(index + 1);
        }
        private static void IndexOf() {
            number = new Dictionary<String, Int32?>();
            for (int i = 0, size = table.Length; i < size; i++)
            {
                number.Add(getIndex(table, i), i);
            }
        }
        private static string getIndex(string str, int index)
        {
            
            return str.Substring(index, 1);
        }
        /*av转BV*/
        public static string enc(long x)
        {
            x = (x ^ xor) + add;
            string r = "BV1  4 1 7  ";
            for (int i = 0; i < 6; i++)
            {
               r = topOffIndex(r, getIndex(table, (int)((x / Math.Round(Math.Pow(58, i))) % 58)), s[i]);
            }
            return r;
        }
        /*BV转av*/
        public static long dec(string x)
        {
            IndexOf();
            int? o = 0;
            long r = 0;
            for (int i = 0; i < 6; i++)
            {
                var c = number.TryGetValue(getIndex(x, s[i]), out o);
                r += (long)o * (long)Math.Round(Math.Pow(58, i));
            }
            return (r - add) ^ xor;
        }
    }
}
