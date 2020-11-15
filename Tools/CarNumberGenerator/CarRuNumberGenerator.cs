using System;
using System.Linq;
using System.Text;

namespace Tools.CarNumberGenerator
{
    public class CarRuNumberGenerator : ICarNumberGenerator
    {
        private Random random = new Random();
        private readonly string RUchars = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЭЮЯ";
        
        // ФОРМАТ НОМЕРА МАШИНЫ: [А-Я][0-9]{3}[А-Я]{2}[0-9]{2,3}
        public string Generate()
        {
            var builder = new StringBuilder(RUchars[random.Next(0, RUchars.Length)].ToString());
            builder.Append(random.Next(100, 1000).ToString());
            var twoRandChars = Enumerable
                .Repeat(RUchars, 2)
                .Select(s => s[random.Next(0, RUchars.Length)].ToString());
            builder.Append(string.Join("", twoRandChars));
            builder.Append(random.Next(10, 1000).ToString());

            return builder.ToString();
        }
    }
}