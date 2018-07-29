using PeselOperationsLibrary.Constants;
using PeselValidator.Constans;
using PeselValidator.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeselValidator
{
    class PeselValidatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _gender, _bornDate, _age, _ordinalNumber;
        private string _enteredPesel;
        public ICommand VerifyPeselCommand { get; private set; }

        private PeselOperationsService peselOperationService;
        private Color _resultTextColor, _resultFrameColor;
        private string _resultText;

        public string EnteredPesel { get => _enteredPesel; set => _enteredPesel = value; }

        public string Gender
        {
            get => _gender;
            set
            {
                OnPropertyChanged("Gender");
                _gender = value;
            }
        }

        public string BornDate
        {
            get => _bornDate;
            set
            {
                _bornDate = value;
                OnPropertyChanged("BornDate");
            }
        }

        public string OrdinalNumber
        {
            get => _ordinalNumber;
            set
            {
                _ordinalNumber = value;
                OnPropertyChanged("OrdinalNumber");
            }
        }

        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public Color ResultFrameColor
        {
            get => _resultFrameColor;
            set
            {
                _resultFrameColor = value;
                OnPropertyChanged("ResultFrameColor");
            }
        }

        public Color ResultTextColor
        {
            get => _resultTextColor;
            set
            {
                _resultTextColor = value;
                OnPropertyChanged("ResultTextColor");
            }
        }

        public string ResultText
        {
            get => _resultText;
            set
            {
                _resultText = value;
                OnPropertyChanged("ResultText");
            }
        }

        public PeselValidatorViewModel()
        {
            ResetPeselInformations();
            VerifyPeselCommand = new Command(VerifyPesel);
            peselOperationService = new PeselOperationsService();
            ResultFrameColor = PeselValidatorConstans.UNVERIFIED_RESULT_FRAME_COLOR;
            ResultTextColor = PeselValidatorConstans.UNVERIFIED_RESULT_TEXT_COLOR;
            ResultText = PeselValidatorConstans.UNVERIFIED_RESULT_TEXT;
        }

        private void VerifyPesel()
        {
            bool isPeselValid = peselOperationService.ValidatePesel(_enteredPesel);

            ChangeResultFrameState(isPeselValid);
            ChangePeselInformationsState(isPeselValid);
        }

        private void ChangePeselInformationsState(bool isPeselValid)
        {
            if (isPeselValid)
            {
                Dictionary<string, string> informations = peselOperationService.ReadPeselInformations(_enteredPesel);
                informations.TryGetValue(PeselInformations.GENDER, out string tempGender);
                Gender = tempGender;
                informations.TryGetValue(PeselInformations.AGE, out string tempAge);
                Age = tempAge;
                informations.TryGetValue(PeselInformations.BORN_DATE, out string tempBornDate);
                BornDate = tempBornDate;
                informations.TryGetValue(PeselInformations.ORDINAL_NUMBER, out string tempOrdinalNumber);
                OrdinalNumber = tempOrdinalNumber;
            }
            else
            {
                ResetPeselInformations();
            }
        }

        private void ChangeResultFrameState(bool isPeselValid)
        {
            if (isPeselValid)
            {
                ResultFrameColor = PeselValidatorConstans.VALID_RESULT_FRAME_COLOR;
                ResultTextColor = PeselValidatorConstans.VALID_RESULT_TEXT_COLOR;
                ResultText = PeselValidatorConstans.VALID_RESULT_TEXT;
            }
            else
            {
                ResultFrameColor = PeselValidatorConstans.UNVALID_RESULT_FRAME_COLOR;
                ResultTextColor = PeselValidatorConstans.UNVALID_RESULT_TEXT_COLOR;
                ResultText = PeselValidatorConstans.UNVALID_RESULT_TEXT;
            }
        }

        private void ResetPeselInformations()
        {
            Gender = Age = BornDate = OrdinalNumber = "-";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
