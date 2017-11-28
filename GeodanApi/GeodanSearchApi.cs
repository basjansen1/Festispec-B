using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace GeodanApi
{
    public class GeodanSearchApi : IGeodanSearchApi
    {
        private readonly string _apiKey;
        private readonly string _apiUrl;

        public GeodanSearchApi()
        {
            // TODO: Dont store this in code
            _apiUrl = "https://services.geodan.nl/geosearch/free";
            _apiKey = "19aca9fb-6705-11e7-a442-005056805b87";
        }

        /// <summary>
        /// Finds the first api result that matches the given options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public dynamic Find(GeodanApiOptions options)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(BuildUrl(options)).Result;

                dynamic json = JsonConvert.DeserializeObject(response);

                if (json.response.docs == null || json.response.docs.Count == 0)
                    return null;

                return json.response.docs[0];
            }
        }

        /// <summary>
        /// Generates the geodan api rul with the given options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public string BuildUrl(GeodanApiOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.PostalCode))
                throw new ArgumentNullException(nameof(options.PostalCode));

            if (string.IsNullOrWhiteSpace(options.HouseNumber))
                throw new ArgumentNullException(nameof(options.HouseNumber));

            var url =
                $"{_apiUrl}?q=fpostcode:{options.PostalCode}+AND+housenumber:{options.HouseNumber}&servicekey={_apiKey}";

            return url;
        }
    }
}