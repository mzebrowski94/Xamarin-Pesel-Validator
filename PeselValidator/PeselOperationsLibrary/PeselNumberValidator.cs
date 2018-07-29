using System;

namespace PeselOperationsLibrary
{
    public class PeselNumberValidator : PeselBaseOperator
    {
        public bool Validate(String pesel)
        {
            if (IsNumeric(pesel) && IsLenghtValid(pesel))
            {
                int[] numbers = ParsePesel(pesel);
                return ValidateCheckSum(CalculateCheckSum(numbers));
            } else
            {
                return false;
            }
        }

        private bool ValidateCheckSum(int checkSum)
        {
            return checkSum % 10 == 0;
        }
    }
}
