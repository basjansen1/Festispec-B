using System;
using NUnit.Framework;

namespace GeodanApi.Test
{
    [TestFixture]
    public class GeodanSearchApiUnitTest
    {
        [Test]
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

        [Test]
        public void BuildUrlInvalidNoPostalCode()
        {
            // 1. Arrange
            var geodanSearchApi = new GeodanSearchApi();
            var geodanApiOptions = new GeodanApiOptions {HouseNumber = "1"};

            // 2. Act

            // 3. Assert that an exception is thrown
            Assert.Catch<ArgumentNullException>(() => geodanSearchApi.BuildUrl(geodanApiOptions));
        }

        [Test]
        public void BuildUrlInvalidNoHouseNumber()
        {
            // 1. Arrange
            var geodanSearchApi = new GeodanSearchApi();
            var geodanApiOptions = new GeodanApiOptions {PostalCode = "1079MB" };

            // 2. Act

            // 3. Assert that an exception is thrown
            Assert.Catch<ArgumentNullException>(() => geodanSearchApi.BuildUrl(geodanApiOptions));
        }

        [Test]
        public void FindValid()
        {
            // 1. Arrange
            var geodanSearchApi = new GeodanSearchApi();
            var geodanApiOptions = new GeodanApiOptions { PostalCode = "1079MB", HouseNumber = "1" };

            // 2. Act
            var data = geodanSearchApi.Find(geodanApiOptions);

            // 3. Assert
            Assert.AreEqual(data.street.ToString(), "President Kennedylaan");
            Assert.AreEqual(data.municipality.ToString(), "Amsterdam");
            Assert.AreEqual(data.type.ToString(), "address");
            Assert.AreEqual(data.city.ToString(), "Amsterdam");
            Assert.AreEqual(data.id.ToString(), "address-0363100012081613-0363200000241158");
            Assert.AreEqual(data.naturalid.ToString(), "0363200000241158");
            Assert.AreEqual(data.province.ToString(), "Noord-Holland");
            Assert.AreEqual(data.housenumber.ToString(), "1");
            Assert.AreEqual(data.postcode.ToString(), "1079MB");
            Assert.AreEqual(data.geom.ToString(), "POINT(4.91311 52.34232)");
            Assert.AreEqual(data.geom_rd.ToString(), "POINT(122692 483928)");
            Assert.AreEqual(data.displayname.ToString(), "President Kennedylaan 1, Amsterdam");
        }
    }
}