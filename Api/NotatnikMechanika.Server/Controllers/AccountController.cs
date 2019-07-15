﻿using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Server.Controllers
{
    [Route(AccountPaths.Name)]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost(AccountPaths.LoginPath)]
        public async Task<ActionResult<TokenModel>> LoginAsync([FromBody]AuthenticateUserModel userParam)
        {
            return Ok(await _accountService.AuthenticateAsync(userParam.UserName, userParam.Password));
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserModel value)
        {
            await _accountService.CreateAsync(value);
            return Ok();
        }

        // [Authorize(Roles = "Administrator")]
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateUserAsync(int id, [FromBody] EditUserModel value)
        {
            await _accountService.UpdateAsync(id, value);
            return Ok();
        }

        // [Authorize(Roles = "Administrator")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _accountService.DeleteAsync(id);
            return Ok();
        }
    }
}