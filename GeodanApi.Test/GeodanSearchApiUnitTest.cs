using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeodanApi.Test
{
    [TestClass]
    public class GeodanSearchApiUnitTest
    {
        [TestMethod]
        public void BuildUrlValid()
        {
            // 1. Arrange
            var geodanSearchApi = new GeodanSearchApi();
            var geodanApiOptions = new GeodanApiOptions {PostalCode = "1079MB", HouseNumber = "1"};

            // 2. Act
            var url = geodanSearchApi.BuildUrl(geodanApiOptions);

            // 3. Assert
            Assert.AreEqual(url,
                "https://services.geodan.nl/geosearch/free?q=fpostcode:1079MB+AND+housenumber:1&servicekey=19aca9fb-6705-11e7-a442-005056805b87");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildUrlInvalidNoPostalCode()
        {
            // 1. Arrange
            var geodanSearchApi = new GeodanSearchApi();
            var geodanApiOptions = new GeodanApiOptions {HouseNumber = "1"};

            // 2. Act
            var url = geodanSearchApi.BuildUrl(geodanApiOptions);

            // 3. Assert that an exception is thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildUrlInvalidNoHouseNumber()
        {
            // 1. Arrange
            var geodanSearchApi = new GeodanSearchApi();
            var geodanApiOptions = new GeodanApiOptions {PostalCode = "1079MB" };

            // 2. Act
            var url = geodanSearchApi.BuildUrl(geodanApiOptions);
            
            // 3. Assert that an exception is thrown
        }
    }
}