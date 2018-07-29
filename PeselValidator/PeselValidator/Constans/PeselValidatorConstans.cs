using Xamarin.Forms;

namespace PeselValidator.Constans
{
    static class PeselValidatorConstans
    {
        public static Color UNVERIFIED_RESULT_FRAME_COLOR = Color.FromRgb(122,125,128);
        public static Color VALID_RESULT_FRAME_COLOR = Color.FromRgb(0,102,51);
        public static Color UNVALID_RESULT_FRAME_COLOR = Color.FromRgb(207,47,47);

        public static Color UNVERIFIED_RESULT_TEXT_COLOR = Color.FromRgb(92, 95, 98);
        public static Color VALID_RESULT_TEXT_COLOR = Color.FromRgb(0, 70, 21);
        public static Color UNVALID_RESULT_TEXT_COLOR = Color.FromRgb(177, 17, 17);

        public static string UNVERIFIED_RESULT_TEXT = "Niezweryfikowany";
        public static string VALID_RESULT_TEXT = "Pesel poprawny";
        public static string UNVALID_RESULT_TEXT = "Pesel niepoprawny";
    }
}
