using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embed.Bookshop.Common
{
    public static class Helper
    {
        public static int GeneratePurchase() => new Random().Next(1, 3);
        public static int GenerateStock() => new Random().Next(5, 20);
        public static double GeneratePrice() => (double)(new Random().Next(399, 599)) / 100.0;
        public static string GenerateISBN()
        {
            long min = 1000000000000;
            long max = 9999999999999;

            var random = new System.Random();

            if (max <= min)
                throw new ArgumentOutOfRangeException("max", "max must be > min!");

            ulong uRange = (ulong)(max - min);
            ulong ulongRand;
            do
            {
                byte[] buf = new byte[8];
                random.NextBytes(buf);
                ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
            } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

            var isbn = (long)(ulongRand % uRange) + min;

            return isbn.ToString();
        }
    }
}
