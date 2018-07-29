using System;
using System.Linq;

namespace PeselOperationsLibrary
{
    public abstract class PeselBaseOperator
    {
        protected int CalculateCheckSum(int[] numbers)
        {
            return numbers[0] + 3 * numbers[1] + 7 * numbers[2] + 9 * numbers[3] + numbers[4] + 3 * numbers[5] + 7 * numbers[6] + 9 * numbers[7] + numbers[8] + 3 * numbers[9] + numbers[10];
        }

        protected int[] ParsePesel(String pesel)
        {
            char[] chars = pesel.ToCharArray();
            int[] numbers = chars.Select(c => Convert.ToInt32(c.ToString())).ToArray();

            return numbers;
        }

        protected bool IsLenghtValid(String pesel)
        {
            return pesel.Length == 11;
        }

        protected bool IsNumeric(String pesel)
        {
            long n;
            return long.TryParse(pesel, out n);
        }
    }
}
