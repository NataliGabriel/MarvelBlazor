using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MarvelApi.Data
{
    public class MarvelAPIService
    {
        private const string BaseUrl = "https://gateway.marvel.com/v1/public/";
        private const string PublicKey = "fbb485d3da2fb3a3ae43e7e1dae49944";
        private const string PrivateKey = "b47a0c2fd2b39ccc7c5e6df0eea97b662d7236e4";

        private readonly HttpClient _httpClient;

        public MarvelAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }
        private string GerarHash(
            string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }
        public ResponseData GetCharacterData()
        {
            var timestamp = DateTime.Now.Ticks.ToString();
            var hash = GerarHash(timestamp, PublicKey, PrivateKey);
            var url = $"{BaseUrl}characters?ts={timestamp}&apikey={PublicKey}&hash={hash}";
            var response = _httpClient.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<ResponseData>(response);
        }
    }

}
