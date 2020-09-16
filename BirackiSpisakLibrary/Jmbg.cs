using System;
using System.Collections.Generic;
using System.Text;

namespace BirackiSpisakLibrary
{
    public static class Jmbg
    {
        public static bool IsOK(string jmbg)
        {
            if (jmbg.Length != 13)
            {
                return false;
            }

            int c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13;
            int sum;
            int remainder;
            int controlNumber;
            bool ok;

            ok = int.TryParse(jmbg.Substring(0, 1), out c1);
            ok = int.TryParse(jmbg.Substring(1, 1), out c2);
            ok = int.TryParse(jmbg.Substring(2, 1), out c3);
            ok = int.TryParse(jmbg.Substring(3, 1), out c4);
            ok = int.TryParse(jmbg.Substring(4, 1), out c5);
            ok = int.TryParse(jmbg.Substring(5, 1), out c6);
            ok = int.TryParse(jmbg.Substring(6, 1), out c7);
            ok = int.TryParse(jmbg.Substring(7, 1), out c8);
            ok = int.TryParse(jmbg.Substring(8, 1), out c9);
            ok = int.TryParse(jmbg.Substring(9, 1), out c10);
            ok = int.TryParse(jmbg.Substring(10, 1), out c11);
            ok = int.TryParse(jmbg.Substring(11, 1), out c12);
            ok = int.TryParse(jmbg.Substring(12, 1), out c13);

            if (!ok)
            {
                return false;
            }

            sum = c1 * 7 + c2 * 6 + c3 * 5 + c4 * 4 + c5 * 3 + c6 * 2 + c7 * 7 + c8 * 6 + c9 * 5 + c10 * 4 + c11 * 3 + c12 * 2;
            remainder = sum % 11;

            if (remainder == 1)
            {
                return false;
            }

            controlNumber = 11 - remainder;

            if (remainder == 0)
            {
                controlNumber = 0;
            }

            if (controlNumber != c13)
            {
                return false;
            }

            return true;
        }
    }
}
