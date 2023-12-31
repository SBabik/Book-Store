﻿using book_store.Identity;
using book_store.Models;
using book_store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace book_store.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;
    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost]
    [Route("user")]
    public async Task<IActionResult> AddUser([FromBody]AddUserRequest user)
    {
        var result = await _userService.AddUser(user);
        if(result is null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("user/{id}")]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var result = await _userService.GetUser(id);
        if (result is null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
}
