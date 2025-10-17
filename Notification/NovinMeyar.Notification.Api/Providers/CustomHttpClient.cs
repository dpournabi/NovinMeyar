using NovinMeyar.Common;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NovinMeyar.Notification.Api.Providers
{
    public interface ICustomHttpClient
    {
        Task<ResponseModel> PostAsync(string jsonModel, string path);
    }
    public class CustomHttpClient : ICustomHttpClient
    {
        private HttpClient httpClient;
        private string baseAddress = string.Empty;

        public CustomHttpClient(string baseAddress, string tokenKey, string tokenValue)
        {
            httpClient = new HttpClient();
            this.baseAddress = baseAddress;
            httpClient.DefaultRequestHeaders.Add("ACCEPT", "application/json");
            httpClient.DefaultRequestHeaders.Add(tokenKey, tokenValue);
        }

        /// <summary>
        /// PostAsync
        /// </summary>
        /// <param name="jsonModel">Send your body as a json data</param>
        /// <param name="path">Send path without base address</param>
        /// <returns></returns>
        public async Task<ResponseModel> PostAsync(string jsonModel, string path)
        {
            var response = new ResponseModel { Succeed = false };

            try
            {
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
                string _path = $"{this.baseAddress}{path}";
                var result = await this.httpClient.PostAsync(_path, content);
                
                response.Message = result.ToString();
                response.Succeed = result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return await Task.FromResult(response);
        }
    }

    public static class SmsIrProvider
    {
        /// <summary>
        /// Volatile: 
        /// 
        /// The volatile keyword indicates that a field might be modified by
        /// multiple threads that are executing at the same time.Fields that
        /// are declared volatile are not subject to compiler optimizations that
        /// assume access by a single thread.This ensures that the most up-to-
        /// date value is present in the field at all times.
        /// </summary>
        private static volatile CustomHttpClient customHttpClient;
        private static object lockObject = new object();
        public static ICustomHttpClient GetInstance()
        {
            if (customHttpClient == null)//Double when we use volatile
            {
                lock (lockObject)
                {
                    if (customHttpClient == null)
                    {
                        customHttpClient = new CustomHttpClient("https://api.sms.ir/v1", "X-API-KEY", "dPAtgfDUwszNHBYY0ofmmaPYOGB5ZuVVVstgsxJmp6XYC2kjzg8i3gq6CjQCTeu0");
                    }
                }
            }
            return customHttpClient;
        }
    }
}
