using Xamarin.Forms;

namespace PeselValidator
{
    public partial class MainPage : ContentPage
    {
        private PeselValidatorViewModel peselValidatorViewModel;

        public MainPage()
        {
            InitializeComponent();
            peselValidatorViewModel = new PeselValidatorViewModel();
            this.BindingContext = peselValidatorViewModel;
        }
    }
}
