using PeselOperationsLibrary.Constants;
using System;
using System.Collections.Generic;

namespace PeselOperationsLibrary
{
    public class PeselInformationReader : PeselBaseOperator
    {
        public Dictionary<string, string> RetriveInformationsMap(String pesel)
        {
            var informations = new Dictionary<string, string>();

            if (IsNumeric(pesel) && IsLenghtValid(pesel))
            {
                int[] numbers = ParsePesel(pesel);

                informations.Add(PeselInformations.GENDER, RetriveGender(numbers));
                informations.Add(PeselInformations.AGE, RetriveAge(numbers));
                informations.Add(PeselInformations.BORN_DATE, RetriveBornDate(numbers));
                informations.Add(PeselInformations.ORDINAL_NUMBER, RetriveOrdinalNumber(numbers));
                return informations;
            }
            else
            {
                return null;
            }
        }

        private string RetriveOrdinalNumber(int[] numbers)
        {
            //TO DO: Find prettier solution
            return string.Format("{0}{1}{2}{3}", numbers[PeselStructure.ORDINAL_NUMBER_BEGINNING_POSITION - 1], numbers[PeselStructure.ORDINAL_NUMBER_BEGINNING_POSITION], numbers[PeselStructure.ORDINAL_NUMBER_BEGINNING_POSITION + 1], numbers[PeselStructure.ORDINAL_NUMBER_BEGINNING_POSITION + 2]);
        }

        private int RetriveBornCentury(int[] numbers)
        {
            switch (numbers[PeselStructure.CENTURY_NUMBER_POSITION - 1])
            {
                case 8:
                case 9:
                    return 18;
                case 0:
                case 1:
                    return 19;
                case 2:
                case 3:
                    return 20;
                case 4:
                case 5:
                    return 21;
                case 6:
                case 7:
                    return 22;
                default:
                    return 00;
            }
        }

        private int RetriveBornYear(int[] numbers)
        {
            int year = Convert.ToInt32(string.Format("{0}{1}", numbers[0], numbers[1]));
            return Convert.ToInt32(string.Format("{0}{1}", RetriveBornCentury(numbers), year));
        }

        private string RetriveBornDate(int[] numbers)
        {
            int year = RetriveBornYear(numbers);
            int month_first_digit = numbers[PeselStructure.CENTURY_NUMBER_POSITION - 1] % 2 != 0 ? 1 : 0;
            int month_second_digit = numbers[PeselStructure.MONTH_NUMBER_POSITION - 1];
            int day = Convert.ToInt32(string.Format("{0}{1}", numbers[PeselStructure.DAY_NUMBER_BEGINNING_POSITION - 1], numbers[PeselStructure.DAY_NUMBER_BEGINNING_POSITION])); ;

            return string.Format("{0}/{1}{2}/{3}", day, month_first_digit, month_second_digit, year);
        }

        private string RetriveAge(int[] numbers)
        {
            int currentYear = DateTime.Now.Year;
            int bornYear = RetriveBornYear(numbers);
            return (currentYear - bornYear).ToString();
        }

        private string RetriveGender(int[] numbers)
        {
            if (numbers[PeselStructure.GENDER_NUMBER_POSITION - 1] % 2 == 0)
            {
                return GenderConstans.FEMALE;
            }
            else
            {
                return GenderConstans.MALE;
            }
        }
    }
}
