﻿using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ISettingsService _settingsService;
        private readonly IHttpRequestService _httpRequestService;

        public event EventHandler AuthChanged;

        public AuthService(ISettingsService settingsService, HttpClient httpClient, IHttpRequestService httpRequestService)
        {
            _httpClient = httpClient;
            _settingsService = settingsService;
            _httpRequestService = httpRequestService;
        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            return (await _httpRequestService.SendPost<RegisterModel, RegisterResult>(registerModel, new AccountPaths().GetFullPath(AccountPaths.RegisterPath))).Content;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            Response<LoginResult> loginResponse = await _httpRequestService.SendPost<LoginModel, LoginResult>(loginModel, new AccountPaths().GetFullPath(AccountPaths.LoginPath));

            if (loginResponse.StatusCode != HttpStatusCode.OK)
            {
                return loginResponse.Content;
            }

            _settingsService.Token = Task.FromResult(loginResponse.Content.Token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponse.Content.Token);
            AuthChanged?.Invoke(this, EventArgs.Empty);
            return loginResponse.Content;
        }
    }
}