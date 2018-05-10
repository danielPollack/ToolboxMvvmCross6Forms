using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Base;
using Newtonsoft.Json;
using Toolbox.Core.Forms.Rest.Interfaces;

namespace Toolbox.Core.Forms.Rest.Implementations
{
    public class RestClient : IRestClient
    {
        private readonly IMvxJsonConverter _jsonConverter;

        public RestClient(IMvxJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }
        public RestClient() { }
        /// <summary>
        ///     Makes the API call.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="method">The method.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public async Task<TResult> MakeAsyncApiCall<TResult>(string url, HttpMethod method, object data = null)
            where TResult : class
        {
            url = url.Replace("http://", "https://");

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage {RequestUri = new Uri(url), Method = method})
                {
                    // add content
                    if (method != HttpMethod.Get)
                    {
                        var json = _jsonConverter.SerializeObject(data);
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    }

                    var response = new HttpResponseMessage();
                    try
                    {
                        response = await httpClient.SendAsync(request).ConfigureAwait(false);
                    }
                    catch (Exception)
                    {
                        // log error
                    }

                    var stringSerialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    // deserialize content
                    return _jsonConverter.DeserializeObject<TResult>(stringSerialized);
                }
            }
        }


        /// <summary>
        /// Makes the API call.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="method">The method.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string MakeApiCall(string url, HttpMethod method, object data = null)
        {
            var request = WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = method.Method;
            string jsonResponseString = string.Empty;
            byte[] dataToSend;
            if (method != HttpMethod.Get)
            {
                dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                request.GetRequestStream().Write(dataToSend, 0, dataToSend.Length);

            }
            var response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                 jsonResponseString = reader.ReadToEnd();
            }
            return jsonResponseString;
        }









        //public T MakeApiCall<T>(string url, HttpMethod method, object data = null)
        //{
        //    var request = HttpWebRequest.Create(url);
        //    request.ContentType = "application/json";
        //    request.Method = method.Method;
        //    byte[] dataToSend;
        //    if (method != HttpMethod.Get)
        //    {
        //         dataToSend = Encoding.UTF8.GetBytes(_jsonConverter.SerializeObject(data));
        //        request.GetRequestStream().Write(dataToSend, 0, dataToSend.Length);

        //    }

        //    var response = request.GetResponse();
        //    using (var reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
        //    {
        //        var jsonResponseString = reader.ReadToEnd();
        //    }
        //    return _jsonConverter.DeserializeObject<T>(stringSerialized);




        //using (var client = new HttpClient())
        //{
        //    using (var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method })
        //    {
        //        if (method != HttpMethod.Get)
        //        {
        //            var json = _jsonConverter.SerializeObject(data);
        //            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        //        }

        //        client.GetAsync(request)

        //        var response = client.GetAsync("http://google.com").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var responseContent = response.Content;

        //            // by calling .Result you are synchronously reading the result
        //            string responseString = responseContent.ReadAsStringAsync().Result;

        //            Console.WriteLine(responseString);
        //        }
        //    }
        //}












        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var request = new HttpRequestMessage {RequestUri = new Uri(url), Method = method})
        //        {
        //            if (method != HttpMethod.Get)
        //            {
        //                var json = _jsonConverter.SerializeObject(data);
        //                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        //            }


        //            try
        //            {






        //               var response = httpClient.SendAsync(request);
        //                if (response.Result=)
        //                {
        //                    var responseContent = response.Content;

        //                    // by calling .Result you are synchronously reading the result
        //                    string responseString = responseContent.ReadAsStringAsync().Result;

        //                    Console.WriteLine(responseString);
        //                }
        //                string responseString = responseContent.ReadAsStringAsync().Result;
        //            }
        //            catch (Exception)
        //            {
        //                // log error
        //            }
        //        }
        //    }
        //}


    }
}