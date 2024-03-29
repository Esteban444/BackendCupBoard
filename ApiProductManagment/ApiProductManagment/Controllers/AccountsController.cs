﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Dto.RequestDto;

namespace ApiProductManagment.Controllers
{
	[Route("api/accounts")]
	[ApiController]
	[AllowAnonymous]
	public class AccountsController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AccountsController(IAuthService service)
		{
			_authService = service;
		}

		[HttpPost("register-in")]
		public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestDto registerUser)
		{
			var result = await _authService.RegisterUser(registerUser);
			return Ok(result);
		}

		[HttpPost("Login-in")]
		public async Task<IActionResult> LoginUser([FromBody] LoginRequestDto loginRequest)
		{
			var result = await _authService.LoginUser(loginRequest);
			return Ok(result);
		}
	}
}

