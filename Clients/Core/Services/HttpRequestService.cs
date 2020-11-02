﻿using Newtonsoft.Json;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient _client;

        public HttpRequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Response<ResponseModel>> SendGet<ResponseModel>(string path) where ResponseModel : new()
        {
            HttpResponseMessage response = await _client.GetAsync(path);
            return await ParseResponse<ResponseModel>(response).ConfigureAwait(false);
        }

        public async Task<Response<ResponseModel>> SendPost<SendModel, ResponseModel>(SendModel model, string path) where SendModel : ValidateModelBase where ResponseModel : new()
        {
            if (!model.IsValid)
            {
                return BadModelStateResponse<ResponseModel>();
            }

            string myContent = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(path, content);
            return await ParseResponse<ResponseModel>(response);
        }

        public async Task<Response> SendPost<SendModel>(SendModel model, string path) where SendModel : ValidateModelBase
        {
            if (!model.IsValid)
            {
                return BadModelStateResponse();
            }

            string myContent = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(path, content);
            return await ParseResponse(response);
        }

        public async Task<Response> SendPost(string path)
        {
            HttpResponseMessage response = await _client.PostAsync(path, null);
            return await ParseResponse(response);
        }

        public async Task<Response> SendDelete(string path)
        {
            HttpResponseMessage response = await _client.DeleteAsync(path);
            return await ParseResponse(response);
        }
    }
}