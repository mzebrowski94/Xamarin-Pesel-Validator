using PeselOperationsLibrary;
using System.Collections.Generic;

namespace PeselValidator.Services
{
    class PeselOperationsService
    {
        private PeselNumberValidator peselNumberValidator;
        private PeselInformationReader peselInformationReader;

        public PeselOperationsService()
        {
            peselNumberValidator = new PeselNumberValidator();
            peselInformationReader = new PeselInformationReader();
        }

        public bool ValidatePesel(string peselNumber)
        {
            return peselNumberValidator.Validate(peselNumber);
        }

        public Dictionary<string, string> ReadPeselInformations(string peselNumber)
        {
            return peselInformationReader.RetriveInformationsMap(peselNumber);
        }
    }
}
