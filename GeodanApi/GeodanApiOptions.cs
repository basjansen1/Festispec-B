using System;
using System.Text.RegularExpressions;

namespace GeodanApi
{
    public class GeodanApiOptions
    {
        public GeodanApiOptions(string postalCode, string houseNumber)
        {
            SetPostalCode(postalCode);
            SetHouseNumberWithPossibleLetter(houseNumber);
        }

        public string PostalCode { get; private set; }

        public string HouseNumber { get; private set; }

        public string HouseLetter { get; private set; }

        public void SetPostalCode(string postalCode)
        {
            if (postalCode == null)
                throw new ArgumentNullException(nameof(postalCode));

            var cleanedPostalCode = postalCode.Replace(" ", string.Empty);

            var postalCodeRegex = new Regex("^[1-9][0-9]{3}(?!sa|sd|ss)[a-z]{2}$", RegexOptions.IgnoreCase);
            if (!postalCodeRegex.IsMatch(cleanedPostalCode))
                throw new InvalidOperationException($"{postalCode} is geen geldige postcode");

            PostalCode = postalCode;
        }

        public void SetHouseNumberWithPossibleLetter(string houseNumber)
        {
            if (houseNumber == null)
                throw new ArgumentNullException(nameof(houseNumber));

            var houseNumberWithPossibleLetter = houseNumber.Replace(" ", string.Empty);
            var houseNumberRegex = new Regex("^([1-9][0-9]{0,3})([a-z]*)$", RegexOptions.IgnoreCase);
            var houseNumberMatch = houseNumberRegex.Match(houseNumberWithPossibleLetter);
            if(!houseNumberMatch.Success || houseNumberMatch.Groups.Count < 3)
                throw new InvalidOperationException($"{houseNumber} is geen geldig huisnummer");
            
            HouseNumber = houseNumberMatch.Groups[1].Value;
            if(houseNumberMatch.Groups.Count > 2)
                HouseLetter = houseNumberMatch.Groups[2].Value;
        }
    }
}