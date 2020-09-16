using System.Collections.Generic;

namespace BirackiSpisakLibrary
{
    public static class Converter
    {
        private static readonly Dictionary<string, string> letters = new Dictionary<string, string>();

        public static string LatToCyr(string text)
        {
            foreach (KeyValuePair<string, string> key in letters)
            {
                text = text.Replace(key.Key, key.Value);
            }

            return text;
        }

        public static string CyrToLat(string text)
        {
            foreach (KeyValuePair<string, string> key in letters)
            {
                text = text.Replace(key.Value, key.Key);
            }

            return text;
        }

        static Converter()
        {
            letters.Add("LJ", "Љ");
            letters.Add("Lj", "Љ");
            letters.Add("NJ", "Њ");
            letters.Add("Nj", "Њ");
            letters.Add("DŽ", "Џ");
            letters.Add("Dž", "Џ");
            letters.Add("DJ", "Ђ");
            letters.Add("Dj", "Ђ");
            letters.Add("Đ", "Ђ");
            letters.Add("A", "А");
            letters.Add("B", "Б");
            letters.Add("V", "В");
            letters.Add("G", "Г");
            letters.Add("D", "Д");
            letters.Add("E", "Е");
            letters.Add("Ž", "Ж");
            letters.Add("Z", "З");
            letters.Add("I", "И");
            letters.Add("J", "Ј");
            letters.Add("K", "К");
            letters.Add("L", "Л");
            letters.Add("M", "М");
            letters.Add("N", "Н");
            letters.Add("O", "О");
            letters.Add("P", "П");
            letters.Add("R", "Р");
            letters.Add("S", "С");
            letters.Add("T", "Т");
            letters.Add("Ć", "Ћ");
            letters.Add("U", "У");
            letters.Add("F", "Ф");
            letters.Add("H", "Х");
            letters.Add("C", "Ц");
            letters.Add("Č", "Ч");
            letters.Add("Š", "Ш");

            letters.Add("lj", "љ");
            letters.Add("nj", "њ");
            letters.Add("dž", "џ");
            letters.Add("dj", "ђ");
            letters.Add("đ", "ђ");
            letters.Add("a", "а");
            letters.Add("b", "б");
            letters.Add("v", "в");
            letters.Add("g", "г");
            letters.Add("d", "д");
            letters.Add("e", "е");
            letters.Add("ž", "ж");
            letters.Add("z", "з");
            letters.Add("i", "и");
            letters.Add("j", "ј");
            letters.Add("k", "к");
            letters.Add("l", "л");
            letters.Add("m", "м");
            letters.Add("n", "н");
            letters.Add("o", "о");
            letters.Add("p", "п");
            letters.Add("r", "р");
            letters.Add("s", "с");
            letters.Add("t", "т");
            letters.Add("ć", "ћ");
            letters.Add("u", "у");
            letters.Add("f", "ф");
            letters.Add("h", "х");
            letters.Add("c", "ц");
            letters.Add("č", "ч");
            letters.Add("š", "ш");
        }
    }
}
